using Microsoft.Win32;
using System;
using System.IO;
using System.Security.Cryptography;

namespace PathAuthentication
{
    internal class Program
    {
        /*
            各キー内容の例
            
            Key     → This-Is-Test-Key
            Check   → EgfagpnQLZFq58fqTTF0w3RoY+tuT5Jn5y1zmYZhSBI=
        */

        static void Main(string[] args)
        {
            // レジストリのキーと値を指定
            string registryPath = @"Software\PathAuthenticationSample\";    //レジストリキーが存在する場所を挿入
                                                                            //例:    "Software\PathAuthenticationSample\"

            string keyValueName = "Key";                                    //パスのキー名を挿入
                                                                            //例:    "Key"

            string checkValueName = "Check";                                //チェックキーのキー名を挿入
                                                                            //例:    "Check"

            // レジストリから値を取得
            string keyValue = GetRegistryValue(registryPath, keyValueName);
            string checkValue = GetRegistryValue(registryPath, checkValueName);

            if (keyValue == null || checkValue == null)
            {
                //対象のレジストリキーが見つからなかった場合のエラー処理

                Console.WriteLine("指定されたレジストリのキーが見つかりません。");
                return;
            }

            // Checkの値を鍵として使用（適切なサイズに調整）
            byte[] encryptionKey = GetAesKeyFromCheckValue(checkValue, 256);

            // Keyの値を暗号化
            string encryptedValue = EncryptString(keyValue, encryptionKey);

            //結果を検証
            if (encryptedValue == "g3hbdyC8WsnHiOL+gJHFsAm1Sw6/P84h6zyCU93WdyI=")           //""期待される結果を挿入
                                                                                            //例:    "g3hbdyC8WsnHiOL+gJHFsAm1Sw6/P84h6zyCU93WdyI="
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("NO");
            }

            Console.ReadLine();
        }

        //レジストリキーの取得関数
        static string GetRegistryValue(string keyPath, string valueName)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath))
            {
                if (key != null)
                {
                    return key.GetValue(valueName) as string;
                }
            }
            return null;
        }

        //暗号化キーを取得する関数
        static byte[] GetAesKeyFromCheckValue(string checkValue, int keySizeBits)
        {
            // Checkの値をBase64デコード
            byte[] checkBytes = Convert.FromBase64String(checkValue);
            int keySizeBytes = keySizeBits / 8;

            // 鍵サイズに合わせてチェックの値を調整
            byte[] key = new byte[keySizeBytes];
            Array.Copy(checkBytes, key, Math.Min(checkBytes.Length, keySizeBytes));
            return key;
        }

        //暗号化関数
        static string EncryptString(string plainText, byte[] key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = new byte[16]; // 初期化ベクトル（IV）は16バイト

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }
    }
}
