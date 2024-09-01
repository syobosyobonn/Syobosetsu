using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace Syobosetsu
{
    internal class PropertiesEpIp
    {

        public void Export()
        {
            string ver = VerInfo.ver;

            Properties.Settings.Default.Ver = ver;

            Properties.Settings.Default.Reload();

            string settingsFilePath = GetSettingsFilePath();

            string SyobosetsuDataPath = GetRoamingAppDataDirectory();

            string ProfilesPath = Path.Combine(SyobosetsuDataPath, "Profiles");

            if (!Directory.Exists(ProfilesPath))
            {
                Directory.CreateDirectory(ProfilesPath);
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = "*.config";
                saveFileDialog.InitialDirectory = ProfilesPath;
                saveFileDialog.Filter = "Config files (*.config)|*.config|All files (*.*)|*.*";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(settingsFilePath, saveFileDialog.FileName, true);
                }
            }
        }
        public void Import()
        {
            string SyobosetsuDataPath = GetRoamingAppDataDirectory();

            string ProfilesPath = Path.Combine(SyobosetsuDataPath, "Profiles");

            if (!Directory.Exists(ProfilesPath))
            {
                Directory.CreateDirectory(ProfilesPath);
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = ProfilesPath;
                openFileDialog.Filter = "Config files (*.config)|*.config|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var LoadOk = MessageBox.Show("設定ファイルを読み込みますか?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (LoadOk == DialogResult.Yes)
                    {

                        // ユーザー設定のファイルパスを取得
                        string userConfigPath = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;

                        // バックアップファイル名
                        string backupConfigPath = userConfigPath + ".bak";

                        try
                        {
                            // ファイルが存在するか確認
                            if (File.Exists(userConfigPath))
                            {
                                // 既存のバックアップファイルを削除（必要に応じて）
                                if (File.Exists(backupConfigPath))
                                {
                                    File.Delete(backupConfigPath);
                                }

                                // user.configをバックアップファイルにリネーム
                                File.Move(userConfigPath, backupConfigPath);
                            }
                        }
                        catch
                        {
                            
                        }

                        string settingsDirectory = Path.GetDirectoryName(GetSettingsFilePath());
                        string targetFilePath = Path.Combine(settingsDirectory, "user.config");

                        File.Copy(openFileDialog.FileName, targetFilePath, true);

                        Properties.Settings.Default.Reload();

                        string NowVer = VerInfo.ver;
                        Properties.Settings.Default.Save();

                        string FileVer = null;

                        if (Properties.Settings.Default.Ver != null || Properties.Settings.Default.Ver != "")
                        {
                            FileVer = Properties.Settings.Default.Ver;
                        }
                        else
                        {
                            FileVer = "不明";
                        }

                        if (NowVer != FileVer)
                        {
                            var loadingChack = MessageBox.Show($"読み込まれた設定ファイルは\n現在のアプリのバージョンと一致しませんでした。\nNow:\t{NowVer}\nThis file:\t{FileVer}\n不安定になる場合があります。続行しますか?","Warning",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                            if (loadingChack == DialogResult.Cancel)
                            {
                                // ユーザー設定のファイルパスを取得
                                string userConfigPath2 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;

                                // バックアップファイル名
                                string backupConfigPath2 = userConfigPath + ".bak";

                                try
                                {
                                    // ファイルが存在するか確認
                                    if (File.Exists(backupConfigPath2))
                                    {
                                        // 既存のバックアップファイルを削除（必要に応じて）
                                        if (File.Exists(userConfigPath2))
                                        {
                                            File.Delete(userConfigPath2);
                                        }

                                        // user.configをバックアップファイルにリネーム
                                        File.Move(backupConfigPath2, userConfigPath2);
                                    }
                                }
                                catch
                                {

                                }

                                Properties.Settings.Default.Reload();
                            }
                        }
                    }
                }
            }
        }
        public static string GetSettingsFilePath()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            return config.FilePath;
        }

        public static string GetRoamingAppDataDirectory()
        {
            // Get the path to the Roaming application's data directory
            string RoamingAppDataDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            // Combine with your application's specific subdirectory
            string myRoamingAppDataDirectory = Path.Combine(RoamingAppDataDirectory, "Syobosetsu");

            // Ensure the directory exists
            if (!Directory.Exists(myRoamingAppDataDirectory))
            {
                Directory.CreateDirectory(myRoamingAppDataDirectory);
            }

            return myRoamingAppDataDirectory;
        }

        public static string GetLocalAppDirectory()
        {
            // ローカルアプリケーションフォルダのパスを取得
            string LocalAppDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            // Combine with your application's specific subdirectory
            string myLocalAppDataDirectory = Path.Combine(LocalAppDataDirectory, "Syobosetsu");

            // Ensure the directory exists
            if (!Directory.Exists(myLocalAppDataDirectory))
            {
                Directory.CreateDirectory(myLocalAppDataDirectory);
            }

            return myLocalAppDataDirectory;
        }
    }
}
