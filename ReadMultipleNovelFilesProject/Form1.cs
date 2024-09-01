using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ReadMultipleNovelFilesProject
{
    public partial class Form1 : Form
    {
        string tempFolderPath = Path.Combine(Path.GetTempPath(), "MNFP-Temp");

        public Form1()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // フォームがロードされたときにファイルを選択
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Multiple Novel Files Projects (*.mnfp)|*.mnfp";
            openFileDialog.Title = "Select a mnfp file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog.FileName;
                ExtractZip(selectedFileName);
            }
            else
            {
                MessageBox.Show("No file selected. The application will now close.");
                Application.Exit();
            }
        }

        private void ExtractZip(string zipFilePath)
        {
            try
            {
                // 一時フォルダーをクリア
                Directory.GetFiles(tempFolderPath).ToList().ForEach(File.Delete);
            }
            catch { }
            // ZIPファイルを一時フォルダーに解凍
            ZipFile.ExtractToDirectory(zipFilePath, tempFolderPath);

            // Data.jsonの読み込み
            string jsonData = File.ReadAllText(Path.Combine(tempFolderPath, "Data.json"));
            JsonDocument jsonDoc = JsonDocument.Parse(jsonData);

            // Files要素の中身をcomboBox1に適用
            if (jsonDoc.RootElement.TryGetProperty("Files", out var filesProperty))
            {
                foreach (var element in filesProperty.EnumerateArray())
                {
                    comboBox1.Items.Add(element.GetString());
                }
            }
            else
            {
                MessageBox.Show("No 'Files' property found in the JSON document.");
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            string selectedFileName = comboBox1.SelectedItem?.ToString();
            if (selectedFileName != null)
            {
                string filePath = Path.Combine(tempFolderPath, selectedFileName);
                System.Diagnostics.Process.Start(filePath);
            }
            else
            {
                MessageBox.Show("Please select a file from the list.");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // FolderBrowserDialogを作成
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            // デフォルトのルートフォルダを設定（デスクトップなど）
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;

            // ダイアログを表示して、ユーザーがフォルダを選択する
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                // 選択されたフォルダにファイルを保存
                foreach (string file in Directory.GetFiles(tempFolderPath))
                {
                    string fileName = Path.GetFileName(file);
                    if (fileName != "Data.txt" && fileName != "Data.json")
                    {
                        string destinationFile = Path.Combine(folderBrowserDialog.SelectedPath, fileName);
                        File.Copy(file, destinationFile);
                    }
                }
                MessageBox.Show("Files saved successfully!");
            }
        }



        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // フォームが閉じられるときに一時フォルダーを削除
                Directory.Delete(tempFolderPath, true);
            }
            catch { }
        }
    }
}
