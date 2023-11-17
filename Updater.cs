using Aspose.Zip;
using Aspose.Zip.Rar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace __by_iBadassCheats_
{
    internal class Updater
    {
        internal static string webrequest = "https://h4cks.de/products/";
        internal static WebClient wc = new WebClient();

        internal static string welcome_text = $@"╔╗ ┬ ┬  ┬╔╗ ┌─┐┌┬┐┌─┐┌─┐┌─┐╔═╗┬ ┬┌─┐┌─┐┌┬┐┌─┐
╠╩╗└┬┘  │╠╩╗├─┤ ││├─┤└─┐└─┐║  ├─┤├┤ ├─┤ │ └─┐
╚═╝ ┴   ┴╚═╝┴ ┴─┴┘┴ ┴└─┘└─┘╚═╝┴ ┴└─┘┴ ┴ ┴ └─┘

Hello User, This is Open Source code.
Github: iBadassCheats

No Protected File.
No Any Hidden Code.
Clean Code.
Beginner Simple.";

        internal static void Download_Extract(string game_rar)
        {
            if (Directory.Exists("Tools\\" + game_rar))
            {
                Console.WriteLine("Delete Old Files...");
                Directory.Delete("Tools\\" + game_rar, true);
            }

            Console.WriteLine("Downloading...");
            wc.DownloadFile(webrequest + game_rar + ".rar", "Tools\\" + game_rar + ".rar");
            RarArchive file = new RarArchive("Tools\\" + game_rar + ".rar");
            Console.WriteLine("Extracting File...");
            file.ExtractToDirectory("Tools\\" + game_rar);
            file.Dispose();
            File.Delete("Tools\\" + game_rar + ".rar");
            Console.WriteLine("Done, Have fun with Cheat.");
            Process.Start("explorer.exe", "Tools\\" + game_rar);
            Thread.Sleep(3000);
        }

        internal static void Update()
        {
            Console.Title = "Cheat Updater - H4cks.de";
            MessageBox.Show("Warning Turn Anti Virus OFF");

            if (!Directory.Exists("Tools"))
                Directory.CreateDirectory("Tools");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(welcome_text);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n" + wc.DownloadString(webrequest + "console.txt"));
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n   Write your Game file: ");
            var readtext = Console.ReadLine();
            Download_Extract(readtext);
        }

        internal static void Main()
        {
            Update();
        }
    }
}
