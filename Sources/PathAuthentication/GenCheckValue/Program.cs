using System;
using System.Security.Cryptography;

namespace GenCheckValue
{
    class Program
    {
        static void Main()
        {
            // 256ビットのキーを生成（32バイト）
            byte[] key = new byte[32];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }

            // Base64文字列に変換
            string checkValue = Convert.ToBase64String(key);

            // Checkの値を表示
            Console.WriteLine("Check Value (Base64):");
            Console.WriteLine(checkValue);

            Console.ReadLine();
        }
    }
}
