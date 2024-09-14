using System;
using System.IO;
using System.Security.Cryptography;

namespace TestEncryption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string KeyValue = "This-Is-Test-Key";                               //Keyの文字列を挿入
                                                                                //例:    "This-Is-Test-Key"

            string CheckValue = "EgfagpnQLZFq58fqTTF0w3RoY+tuT5Jn5y1zmYZhSBI="; //Checkの文字列を挿入
                                                                                //例:    "EgfagpnQLZFq58fqTTF0w3RoY+tuT5Jn5y1zmYZhSBI="

            // Checkの値を鍵として使用（適切なサイズに調整）
            byte[] EncryptionKey = GetAesKeyFromCheckValue(CheckValue, 256);

            // Keyの値を暗号化
            string encryptedValue = EncryptString(KeyValue, EncryptionKey);

            Console.WriteLine($"Result : {encryptedValue}");
            Console.ReadLine();
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
