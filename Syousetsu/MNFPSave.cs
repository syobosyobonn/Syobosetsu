using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Syobosetsu
{
    internal class MNFP
    {
        public static void SaveToMNFP()
        {

            // ファイルを選択
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "テキストファイル(*.txt)|*.txt|すべてのファイル(*.*)|*.*";
            ofd.Title = "保存するファイルを複数または単数選択してください";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] selectedFiles = ofd.FileNames;

                // ファイル名のみを抽出
                var fileNames = selectedFiles.Select(Path.GetFileName);

                // ファイルを保存
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Multiple novel files project (*.mnfp)|*.mnfp";
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.Title = "保存する場所を選択してください";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string saveFilePath = saveFileDialog.FileName;

                    try
                    {
                        File.Delete(saveFilePath);
                    }
                    catch { }

                    // 一時フォルダを作成
                    string tempFolder = Path.Combine(Path.GetTempPath(), "FileCompressionTemp");
                    Directory.CreateDirectory(tempFolder);

                    try
                    {
                        // Data.txtを一時フォルダに保存
                        File.WriteAllText(Path.Combine(tempFolder, "Data.txt"), $"Files={selectedFiles.Length}");

                        // Data.jsonにファイル名を保存
                        var jsonData = new { Files = fileNames };
                        string jsonText = JsonSerializer.Serialize(jsonData);
                        File.WriteAllText(Path.Combine(tempFolder, "Data.json"), jsonText);

                        // 選択されたファイルを一時フォルダにコピー
                        foreach (string file in selectedFiles)
                        {
                            File.Copy(file, Path.Combine(tempFolder, Path.GetFileName(file)), true);
                        }

                        // ファイルを圧縮
                        using (ZipArchive zip = ZipFile.Open(saveFilePath, ZipArchiveMode.Create))
                        {
                            // Data.txtをzipに書き込み
                            zip.CreateEntryFromFile(Path.Combine(tempFolder, "Data.txt"), "Data.txt");

                            // Data.jsonをzipに書き込み
                            zip.CreateEntryFromFile(Path.Combine(tempFolder, "Data.json"), "Data.json");

                            // 選択されたファイルをzipに書き込み
                            foreach (string file in selectedFiles)
                            {
                                zip.CreateEntryFromFile(Path.Combine(tempFolder, Path.GetFileName(file)), Path.GetFileName(file));
                            }
                        }

                        Msgs.MsgDialog(10);
                    }
                    finally
                    {
                        // 一時フォルダを削除
                        Directory.Delete(tempFolder, true);
                    }

                }
                else
                {
                    Msgs.MsgDialog(31);
                }
            }
        }
    }
}
