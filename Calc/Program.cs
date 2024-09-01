using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Threading;

using Musasabi.ConsoleExLib;

namespace Calc
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.AssemblyResolve += OnResolveAssembly;

            MainClass main = new MainClass();

            main.Init();

            main.MainProsess();
        }
        private static Assembly OnResolveAssembly(object sender, ResolveEventArgs args)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = new AssemblyName(args.Name);

            string path = assemblyName.Name + ".dll";
            if (assemblyName.CultureInfo.Equals(CultureInfo.InvariantCulture) == false)
            {
                path = String.Format(@"{0}\{1}", assemblyName.CultureInfo, path);
            }

            using (Stream stream = executingAssembly.GetManifestResourceStream(path))
            {
                if (stream == null)
                    return null;

                byte[] assemblyRawBytes = new byte[stream.Length];
                stream.Read(assemblyRawBytes, 0, assemblyRawBytes.Length);
                return Assembly.Load(assemblyRawBytes);
            }
        }
    }

    public class MainClass
    {
        string selectedNow { get; set; } = "1";
        public string display = "0";

        string FirstTexts =
            "┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\r\n" +
            "  0\r\n" +
            "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\r\n" +
            "\r\n" +
            "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
            "│　 1　││　 2　││　 3　││　+ │\r\n" +
            "└──────┘└──────┘└──────┘└────┘\r\n" +
            "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
            "│　 4　││　 5　││　 6　││　- │\r\n" +
            "└──────┘└──────┘└──────┘└────┘\r\n" +
            "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
            "│　 7　││　 8　││　 9　││　x │\r\n" +
            "└──────┘└──────┘└──────┘└────┘\r\n" +
            "┌──────────────┐┌──────┐┌────┐\r\n" +
            "│　 　　0　　　││　 .　││　/ │\r\n" +
            "└──────────────┘└──────┘└────┘\r\n" +
            "┏━━━━━━━━━━━━━━━━━━━━━━┓┏━━━━┓\r\n" +
            "┃　　　　　 ＝ 　　　　┃┃ ← ┃\r\n" +
            "┗━━━━━━━━━━━━━━━━━━━━━━┛┗━━━━┛";
        public void MainProsess()
        {
            while (true)
            {
                Console.Clear();

                Draw(selectedNow);

                Console.WriteLine();

                bool IsEnter = Get();
                if (IsEnter)
                {
                    ChangeDisplay();
                }

            }
        }


        public void Init()
        {
            Console.Title = "Calc.";

            Console.ForegroundColor = ConsoleColor.Green;

            Thread.Sleep(100);

            Console.Beep(2000, 100);

            ConsoleEx.SingleCharWriteLine("Initalizing．．．", 7);

            /*ここに履歴消去処理を書く*/

            Thread.Sleep(50);

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("837e834e81755982b382f182cc82b182c682cd", 1);
            Console.WriteLine("82e082a4965982ea82bd82d982a482aa",1);
            Console.WriteLine("82a282a282c68e7682a282dc82b78176...", 1);

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("838b834a8175918a95cf82ed82e782b8", 1);
            Console.WriteLine("96a297fb82aa82dc82b582a282c88176...", 1);

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("8357837E817592FA82DF82AA88AB82A282E68176...",1);

            Console.WriteLine("");
            Console.WriteLine("");

            Thread.Sleep(20);

            Console.WriteLine(
                "　■■■　　　　　　　■\r\n" +
                "■　　　■　　■■　　■　　■■■\r\n" +
                "■　　　　　　　　■　■　■\r\n" +
                "■　　　　　　■■■　■　■\r\n" +
                "■　　　■　■　　■　■　■\r\n" +
                "　■■■　　　■■■　■　　■■■　■", 1);

            /*
            Console.WriteLine("　■■■　　　　　　　■");
            Console.WriteLine("■　　　■　　■■　　■　　■■■");
            Console.WriteLine("■　　　　　　　　■　■　■");
            Console.WriteLine("■　　　　　　■■■　■　■");
            Console.WriteLine("■　　　■　■　　■　■　■");
            Console.WriteLine("　■■■　　　■■■　■　　■■■　■");
            */

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("8357837E815B817581638163");
            Console.WriteLine("28814C8145");
            Console.WriteLine("81CD8145814D29");
            Console.WriteLine("816381638176...");

            Console.WriteLine("");

            ConsoleEx.SingleCharWriteLine(">>Original:JimmythumbP(ジミーサムP)", 1);

            Thread.Sleep(800);

            Console.Clear();

            Console.Beep(1000, 100);

            Console.WriteLine(FirstTexts);
        }
            
        public void Draw(string s)
        {
            /*
             case "2":
                    Console.Write(
                        "┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\r\n" +
                        $"  {display}\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\r\n" +
                        "\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 1　││　 2　││　 3　││　+ │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 4　││　 5　││　 6　││　- │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 7　││　 8　││　 9　││　x │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────────────┐┌──────┐┌────┐\r\n" +
                        "│　 　　0　　　││　 .　││　/ │\r\n" +
                        "└──────────────┘└──────┘└────┘\r\n" +
                        "┏━━━━━━━━━━━━━━━━━━━━━━┓┏━━━━┓\r\n" +
                        "┃　　　　　 ＝ 　　　　┃┃ ← ┃\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━┛┗━━━━┛");
                    return;
             */

            switch (s)
            {
                case "1":
                    Console.Write(
                        "┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\r\n" +
                        $"  {display}\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\r\n" +
                        "\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 ");

                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Green;

                    Console.Write("1");

                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write("　││　 2　││　 3　││　+ │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 4　││　 5　││　 6　││　- │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 7　││　 8　││　 9　││　x │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────────────┐┌──────┐┌────┐\r\n" +
                        "│　 　　0　　　││　 .　││　/ │\r\n" +
                        "└──────────────┘└──────┘└────┘\r\n" +
                        "┏━━━━━━━━━━━━━━━━━━━━━━┓┏━━━━┓\r\n" +
                        "┃　　　　　 ＝ 　　　　┃┃ ← ┃\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━┛┗━━━━┛");
                    return;
                case "2":
                    Console.Write(
                        "┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\r\n" +
                        $"  {display}\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\r\n" +
                        "\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 1　││　 ");

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write("2");

                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write("　││　 3　││　+ │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 4　││　 5　││　 6　││　- │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 7　││　 8　││　 9　││　x │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────────────┐┌──────┐┌────┐\r\n" +
                        "│　 　　0　　　││　 .　││　/ │\r\n" +
                        "└──────────────┘└──────┘└────┘\r\n" +
                        "┏━━━━━━━━━━━━━━━━━━━━━━┓┏━━━━┓\r\n" +
                        "┃　　　　　 ＝ 　　　　┃┃ ← ┃\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━┛┗━━━━┛");
                    return;
                case "3":
                    Console.Write(
                        "┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\r\n" +
                        $"  {display}\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\r\n" +
                        "\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 1　││　 2　││　 ");

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write("3");

                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(
                        "　││　+ │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 4　││　 5　││　 6　││　- │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 7　││　 8　││　 9　││　x │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────────────┐┌──────┐┌────┐\r\n" +
                        "│　 　　0　　　││　 .　││　/ │\r\n" +
                        "└──────────────┘└──────┘└────┘\r\n" +
                        "┏━━━━━━━━━━━━━━━━━━━━━━┓┏━━━━┓\r\n" +
                        "┃　　　　　 ＝ 　　　　┃┃ ← ┃\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━┛┗━━━━┛");
                    return;

                case "4":
                    Console.Write(
                        "┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\r\n" +
                        $"  {display}\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\r\n" +
                        "\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 1　││　 2　││　 3　││　+ │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 ");

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write("4");

                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(
                        "　││　 5　││　 6　││　- │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 7　││　 8　││　 9　││　x │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────────────┐┌──────┐┌────┐\r\n" +
                        "│　 　　0　　　││　 .　││　/ │\r\n" +
                        "└──────────────┘└──────┘└────┘\r\n" +
                        "┏━━━━━━━━━━━━━━━━━━━━━━┓┏━━━━┓\r\n" +
                        "┃　　　　　 ＝ 　　　　┃┃ ← ┃\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━┛┗━━━━┛");
                    return;
                case "5":
                    Console.Write(
                        "┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\r\n" +
                        $"  {display}\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\r\n" +
                        "\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 1　││　 2　││　 3　││　+ │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 4　││　 ");

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write("5");

                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(
                        "　││　 6　││　- │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 7　││　 8　││　 9　││　x │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────────────┐┌──────┐┌────┐\r\n" +
                        "│　 　　0　　　││　 .　││　/ │\r\n" +
                        "└──────────────┘└──────┘└────┘\r\n" +
                        "┏━━━━━━━━━━━━━━━━━━━━━━┓┏━━━━┓\r\n" +
                        "┃　　　　　 ＝ 　　　　┃┃ ← ┃\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━┛┗━━━━┛");
                    return;
                case "6":
                    Console.Write(
                        "┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\r\n" +
                        $"  {display}\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\r\n" +
                        "\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 1　││　 2　││　 3　││　+ │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 4　││　 5　││　 ");

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write("6");

                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(
                        "　││　- │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 7　││　 8　││　 9　││　x │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────────────┐┌──────┐┌────┐\r\n" +
                        "│　 　　0　　　││　 .　││　/ │\r\n" +
                        "└──────────────┘└──────┘└────┘\r\n" +
                        "┏━━━━━━━━━━━━━━━━━━━━━━┓┏━━━━┓\r\n" +
                        "┃　　　　　 ＝ 　　　　┃┃ ← ┃\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━┛┗━━━━┛");
                    return;

                case "7":
                    Console.Write(
                        "┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\r\n" +
                        $"  {display}\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\r\n" +
                        "\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 1　││　 2　││　 3　││　+ │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 4　││　 5　││　 6　││　- │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 ");

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write("7");

                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(
                        "　││　 8　││　 9　││　x │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────────────┐┌──────┐┌────┐\r\n" +
                        "│　 　　0　　　││　 .　││　/ │\r\n" +
                        "└──────────────┘└──────┘└────┘\r\n" +
                        "┏━━━━━━━━━━━━━━━━━━━━━━┓┏━━━━┓\r\n" +
                        "┃　　　　　 ＝ 　　　　┃┃ ← ┃\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━┛┗━━━━┛");
                    return;
                case "8":
                    Console.Write(
                        "┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\r\n" +
                        $"  {display}\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\r\n" +
                        "\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 1　││　 2　││　 3　││　+ │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 4　││　 5　││　 6　││　- │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 7　││　 ");

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write("8");

                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(
                            "　││　 9　││　x │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────────────┐┌──────┐┌────┐\r\n" +
                        "│　 　　0　　　││　 .　││　/ │\r\n" +
                        "└──────────────┘└──────┘└────┘\r\n" +
                        "┏━━━━━━━━━━━━━━━━━━━━━━┓┏━━━━┓\r\n" +
                        "┃　　　　　 ＝ 　　　　┃┃ ← ┃\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━┛┗━━━━┛");
                    return;
                case "9":
                    Console.Write(
                        "┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\r\n" +
                        $"  {display}\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\r\n" +
                        "\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 1　││　 2　││　 3　││　+ │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 4　││　 5　││　 6　││　- │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 7　││　 8　││　 ");

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write("9");

                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(
                        "　││　x │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────────────┐┌──────┐┌────┐\r\n" +
                        "│　 　　0　　　││　 .　││　/ │\r\n" +
                        "└──────────────┘└──────┘└────┘\r\n" +
                        "┏━━━━━━━━━━━━━━━━━━━━━━┓┏━━━━┓\r\n" +
                        "┃　　　　　 ＝ 　　　　┃┃ ← ┃\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━┛┗━━━━┛");
                    return;

                case "0":
                    Console.Write(
                        "┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\r\n" +
                        $"  {display}\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\r\n" +
                        "\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 1　││　 2　││　 3　││　+ │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 4　││　 5　││　 6　││　- │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 7　││　 8　││　 9　││　x │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────────────┐┌──────┐┌────┐\r\n" +
                        "│　 　　");

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write("0");

                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(
                        "　　　││　 .　││　/ │\r\n" +
                        "└──────────────┘└──────┘└────┘\r\n" +
                        "┏━━━━━━━━━━━━━━━━━━━━━━┓┏━━━━┓\r\n" +
                        "┃　　　　　 ＝ 　　　　┃┃ ← ┃\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━┛┗━━━━┛");
                    return;
                case ".":
                    Console.Write(
                        "┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\r\n" +
                        $"  {display}\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\r\n" +
                        "\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 1　││　 2　││　 3　││　+ │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 4　││　 5　││　 6　││　- │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 7　││　 8　││　 9　││　x │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────────────┐┌──────┐┌────┐\r\n" +
                        "│　 　　0　　　││　 ");

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write(".");

                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(
                        "　││　/ │\r\n" +
                        "└──────────────┘└──────┘└────┘\r\n" +
                        "┏━━━━━━━━━━━━━━━━━━━━━━┓┏━━━━┓\r\n" +
                        "┃　　　　　 ＝ 　　　　┃┃ ← ┃\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━┛┗━━━━┛");
                    return;

                case "=":
                    Console.Write(
                        "┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\r\n" +
                        $"  {display}\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\r\n" +
                        "\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 1　││　 2　││　 3　││　+ │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 4　││　 5　││　 6　││　- │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 7　││　 8　││　 9　││　x │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────────────┐┌──────┐┌────┐\r\n" +
                        "│　 　　0　　　││　 .　││　/ │\r\n" +
                        "└──────────────┘└──────┘└────┘\r\n" +
                        "┏━━━━━━━━━━━━━━━━━━━━━━┓┏━━━━┓\r\n" +
                        "┃　　　　　 ");

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write("＝");

                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(
                        " 　　　　┃┃ ← ┃\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━┛┗━━━━┛");
                    return;

                case "+":
                    Console.Write(
                        "┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\r\n" +
                        $"  {display}\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\r\n" +
                        "\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 1　││　 2　││　 3　││　");

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write("+");

                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(
                        " │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 4　││　 5　││　 6　││　- │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 7　││　 8　││　 9　││　x │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────────────┐┌──────┐┌────┐\r\n" +
                        "│　 　　0　　　││　 .　││　/ │\r\n" +
                        "└──────────────┘└──────┘└────┘\r\n" +
                        "┏━━━━━━━━━━━━━━━━━━━━━━┓┏━━━━┓\r\n" +
                        "┃　　　　　 ＝ 　　　　┃┃ ← ┃\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━┛┗━━━━┛");
                    return;
                case "-":
                    Console.Write(
                        "┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\r\n" +
                        $"  {display}\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\r\n" +
                        "\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 1　││　 2　││　 3　││　+ │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 4　││　 5　││　 6　││　");

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write("-");

                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(
                        " │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 7　││　 8　││　 9　││　x │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────────────┐┌──────┐┌────┐\r\n" +
                        "│　 　　0　　　││　 .　││　/ │\r\n" +
                        "└──────────────┘└──────┘└────┘\r\n" +
                        "┏━━━━━━━━━━━━━━━━━━━━━━┓┏━━━━┓\r\n" +
                        "┃　　　　　 ＝ 　　　　┃┃ ← ┃\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━┛┗━━━━┛");
                    return;
                case "x":
                    Console.Write(
                        "┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\r\n" +
                        $"  {display}\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\r\n" +
                        "\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 1　││　 2　││　 3　││　+ │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 4　││　 5　││　 6　││　- │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 7　││　 8　││　 9　││　");

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write("x");

                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(
                        " │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────────────┐┌──────┐┌────┐\r\n" +
                        "│　 　　0　　　││　 .　││　/ │\r\n" +
                        "└──────────────┘└──────┘└────┘\r\n" +
                        "┏━━━━━━━━━━━━━━━━━━━━━━┓┏━━━━┓\r\n" +
                        "┃　　　　　 ＝ 　　　　┃┃ ← ┃\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━┛┗━━━━┛");
                    return;
                case "/":
                    Console.Write(
                        "┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\r\n" +
                        $"  {display}\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\r\n" +
                        "\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 1　││　 2　││　 3　││　+ │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 4　││　 5　││　 6　││　- │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 7　││　 8　││　 9　││　x │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────────────┐┌──────┐┌────┐\r\n" +
                        "│　 　　0　　　││　 .　││　");

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write("/");

                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(
                        " │\r\n" +
                        "└──────────────┘└──────┘└────┘\r\n" +
                        "┏━━━━━━━━━━━━━━━━━━━━━━┓┏━━━━┓\r\n" +
                        "┃　　　　　 ＝ 　　　　┃┃ ← ┃\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━┛┗━━━━┛");
                    return;

                case "←":
                    Console.Write(
                        "┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓\r\n" +
                        $"  {display}\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛\r\n" +
                        "\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 1　││　 2　││　 3　││　+ │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 4　││　 5　││　 6　││　- │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────┐┌──────┐┌──────┐┌────┐\r\n" +
                        "│　 7　││　 8　││　 9　││　x │\r\n" +
                        "└──────┘└──────┘└──────┘└────┘\r\n" +
                        "┌──────────────┐┌──────┐┌────┐\r\n" +
                        "│　 　　0　　　││　 .　││　/ │\r\n" +
                        "└──────────────┘└──────┘└────┘\r\n" +
                        "┏━━━━━━━━━━━━━━━━━━━━━━┓┏━━━━┓\r\n" +
                        "┃　　　　　 ＝ 　　　　┃┃ ");

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write("←");

                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(
                        " ┃\r\n" +
                        "┗━━━━━━━━━━━━━━━━━━━━━━┛┗━━━━┛");
                    return;
            }
        }
        public bool Get()
        {
            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    switch (selectedNow)
                    {
                        case "1": return false;
                        case "2": return false;
                        case "3": return false;

                        case "4": selectedNow = "1"; return false;
                        case "5": selectedNow = "2"; return false;
                        case "6": selectedNow = "3"; return false;

                        case "7": selectedNow = "4"; return false;
                        case "8": selectedNow = "5"; return false;
                        case "9": selectedNow = "6"; return false;

                        case "0": selectedNow = "8"; return false;
                        case ".": selectedNow = "9"; return false;

                        case "=": selectedNow = "0"; return false;

                        case "+": return false;
                        case "-": selectedNow = "+"; return false;
                        case "x": selectedNow = "-"; return false;
                        case "/": selectedNow = "x"; return false;

                        case "←": selectedNow = "/"; return false;
                    }
                    return false;

                case ConsoleKey.DownArrow:
                    switch (selectedNow)
                    {
                        case "1": selectedNow = "4"; return false;
                        case "2": selectedNow = "5"; return false;
                        case "3": selectedNow = "6"; return false;

                        case "4": selectedNow = "7"; return false;
                        case "5": selectedNow = "8"; return false;
                        case "6": selectedNow = "9"; return false;

                        case "7": selectedNow = "0"; return false;
                        case "8": selectedNow = "0"; return false;
                        case "9": selectedNow = "."; return false;

                        case "+/-": selectedNow = "="; return false;
                        case "0": selectedNow = "="; return false;
                        case ".": selectedNow = "="; return false;

                        case "=": return false;

                        case "+": selectedNow = "-"; return false;
                        case "-": selectedNow = "x"; return false;
                        case "x": selectedNow = "/"; return false;
                        case "/": selectedNow = "←"; return false;

                        case "←": return false;
                    }
                    return false;

                case ConsoleKey.RightArrow:
                    switch (selectedNow)
                    {
                        case "1": selectedNow = "2"; return false;
                        case "2": selectedNow = "3"; return false;
                        case "3": selectedNow = "+"; return false;

                        case "4": selectedNow = "5"; return false;
                        case "5": selectedNow = "6"; return false;
                        case "6": selectedNow = "-"; return false;

                        case "7": selectedNow = "8"; return false;
                        case "8": selectedNow = "9"; return false;
                        case "9": selectedNow = "x"; return false;

                        case "0": selectedNow = "."; return false;
                        case ".": selectedNow = "/"; return false;

                        case "=": selectedNow = "←"; return false;

                        case "+": return false;
                        case "-": return false;
                        case "x": return false;
                        case "/": return false;

                        case "←": return false;
                    }
                    return false;

                case ConsoleKey.LeftArrow:
                    switch (selectedNow)
                    {
                        case "1": return false;
                        case "2": selectedNow = "1"; return false;
                        case "3": selectedNow = "2"; return false;

                        case "4": return false;
                        case "5": selectedNow = "4"; return false;
                        case "6": selectedNow = "5"; return false;

                        case "7": return false;
                        case "8": selectedNow = "7"; return false;
                        case "9": selectedNow = "8"; return false;

                        case "0": return false;
                        case ".": selectedNow = "0"; return false;

                        case "=": return false;

                        case "+": selectedNow = "3"; return false;
                        case "-": selectedNow = "6"; return false;
                        case "x": selectedNow = "9"; return false;
                        case "/": selectedNow = "."; return false;

                        case "←": selectedNow = "="; return false;
                    }
                    return false;

                case ConsoleKey.Enter:
                    return true;

                case ConsoleKey.T:
                    Terminal cmd = new Terminal();
                    cmd.MainTerminalProgram();

                    return false;

                case ConsoleKey.C:
                    display = "0";
                    return false;

            }
            if (key.Key == ConsoleKey.Enter)
            {
                return true;
            }
            else if (key.KeyChar == '*')
            {
                selectedNow = "x";
                ChangeDisplay();
                return false;
            }
            else if (key.Key == ConsoleKey.Backspace)
            {
                selectedNow = "←";
                ChangeDisplay();
                return false;
            }
            else if (key.KeyChar == '.')
            {
                selectedNow = ".";
                ChangeDisplay();
                return false;
            }
            else if (key.KeyChar == '=')
            {
                selectedNow = "=";
                return true;
            }
            else if (int.TryParse(key.KeyChar.ToString(), out int res))
            {
                selectedNow = key.KeyChar.ToString();
                ChangeDisplay();
                return false;
            }
            else if (key.KeyChar == '+' || key.KeyChar == '-' || key.KeyChar == '/')
            {
                selectedNow = key.KeyChar.ToString();
                ChangeDisplay();
                return false;
            }
            return false;
        }

        public void ChangeDisplay()
        {
            if (!(selectedNow == "=" || selectedNow == "←" || selectedNow == "." || selectedNow == "+" || selectedNow == "-" || selectedNow == "x" || selectedNow == "/"))
            {
                if (!(display == "0"))
                {
                    display += selectedNow;
                }
                else
                {
                    display = selectedNow;
                }
            }
            else if (selectedNow == ".")
            {
                display += selectedNow;
            }
            else if (selectedNow == "+" || selectedNow == "-" || selectedNow == "x" || selectedNow == "/")
            {
                if (!(display == "0"))
                {
                    display += " " + selectedNow + " ";
                }
                else
                {
                    display = "0 " + selectedNow + " ";
                }
            }
            else if (selectedNow == "←")
            {
                if (display.Length > 0)
                {
                    if (display[display.Length - 1].ToString() == " ")
                    {
                        display = display.Remove(display.Length - 1);
                        display = display.Remove(display.Length - 1);
                        display = display.Remove(display.Length - 1);
                    }
                    else
                    {
                        display = display.Remove(display.Length - 1);
                    }

                }

                if (display == "")
                {
                    display = "0";
                }
            }
            else if (selectedNow == "=")
            {
                Calculation();
            }
        }
        public void Calculation()
        {
            try
            {
                string inputTemp = display.Replace("x", "*"); // xを*に

                var parts = inputTemp.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length % 2 == 0)
                {
                    throw new ArgumentException("数式の形式が正しくありません。");
                }

                // 小数点が含まれているかチェック
                bool useDecimal = parts.Any(p => p.Contains("."));

                if (useDecimal)
                {
                    try
                    {
                        decimal result = ParseAndEvaluate(parts);
                        display = result.ToString("G29"); // 小数点以下の不要な0を削除
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("数値の形式が正しくありません。");
                    }
                    catch (OverflowException)
                    {
                        throw new OverflowException("数値が大きすぎるか小さすぎます。");
                    }
                }
                else
                {
                    try
                    {
                        BigInteger result = ParseAndEvaluateBigInteger(parts);
                        display = result.ToString();
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("整数の形式が正しくありません。");
                    }
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Error.");
                Console.WriteLine("Please type any key.");
                Console.WriteLine("(If you want to show error message,)");
                Console.WriteLine("(Please type \"e\".)");
                var ErrorKey = Console.ReadKey(true);

                if (ErrorKey.Key == ConsoleKey.E)
                {
                    Console.WriteLine();
                    Console.WriteLine(e.ToString());
                    Console.WriteLine();
                    Console.WriteLine("Please type any key.");
                    Console.ReadKey();
                }

                Console.ForegroundColor = ConsoleColor.Green;
            }
        }

        private decimal ParseAndEvaluate(string[] parts)
        {
            decimal result = decimal.Parse(parts[0]);

            for (int i = 1; i < parts.Length; i += 2)
            {
                string operatorSymbol = parts[i];
                decimal rightOperand = decimal.Parse(parts[i + 1]);

                switch (operatorSymbol)
                {
                    case "+": result += rightOperand; break;
                    case "-": result -= rightOperand; break;
                    case "*": result *= rightOperand; break;
                    case "/":
                        if (rightOperand == 0)
                        {
                            throw new DivideByZeroException("0で割ることはできません。");
                        }
                        result /= rightOperand;
                        break;
                    default:
                        throw new ArgumentException("無効な演算子です。");
                }
            }

            return result;
        }

        private BigInteger ParseAndEvaluateBigInteger(string[] parts)
        {
            BigInteger result = BigInteger.Parse(parts[0]);

            for (int i = 1; i < parts.Length; i += 2)
            {
                string operatorSymbol = parts[i];
                BigInteger rightOperand = BigInteger.Parse(parts[i + 1]);

                switch (operatorSymbol)
                {
                    case "+": result += rightOperand; break;
                    case "-": result -= rightOperand; break;
                    case "*": result *= rightOperand; break;
                    case "/":
                        if (rightOperand == 0)
                        {
                            throw new DivideByZeroException("0で割ることはできません。");
                        }
                        result /= rightOperand;
                        break;
                    default:
                        throw new ArgumentException("無効な演算子です。");
                }
            }

            return result;
        }

    }
    class Terminal
    {
        public void MainTerminalProgram()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write("Terminal>>>");

            string inp = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            switch (inp)
            {
                case "help":
                    Help(); break;
                case "close":
                    Close() ; break;
                case "reboot":
                    Reboot() ; break;
                case "thanks people":
                    ThanksPeople() ; break;
                /*case "settings":
                    settings() ; return;*/
            }

            Console.WriteLine("Please type any key.");
            Console.ReadKey();
            Console.Clear();
            return;
        }

        public void Help()
        {
            Console.Clear();
            
            ConsoleEx.SingleCharWriteLine(
                "□─── □\r\n" +
                "│ Help|\r\n" +
                "□─── □\r\n" +
                "\r\n" +
                "■Main\r\n" +
                "├ ・↑↓←→\t\t── Move cursor.\r\n" +
                "├ ・Enter\t\t── ENTER to cursored place.\r\n" +
                "├ ・C\t\t\t── Clear display.(result display)\r\n" +
                "└ ・T\t\t\t── Open Terminal.\r\n" +
                "\r\n" +
                "■Terminal\r\n" +
                "├ ・help\t\t── Show this help.\r\n" +
                "├ ・close\t\t── Close \"Calc..exe\".\r\n" +
                "├ ・reboot\t\t── Reboot \"Calc..exe\".\r\n" +
                "└ ・thanks people\t── Show thanks people.\r\n" +
                //"└ ・settings\t\t── Show setting window.\r\n" +
                "\r\n", 1);
        }

        public void Close()
        {
            Environment.Exit(0);
        }
        
        public void Reboot()
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string startBatPath = appDirectory + "Calc..bat";
            Process.Start(startBatPath);
            Environment.Exit(0);
        }
        
        public void ThanksPeople()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            ConsoleEx.SingleCharWriteLine(
                "This app is \"Calc.\" style calculator.\r\n" +
                "\"Calc.\" (http://www.nicovideo.jp/watch/sm12050471) is JimmythumbP(ジミーサムP)'s vocaloid song.\r\n" +
                "Thanks to JimmythumbP for making the grait song!\r\n" +
                "\r\n", 1);

            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
