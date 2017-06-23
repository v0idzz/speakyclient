using System;
using System.Net;
using Gtk;

namespace SpeakyClient
{
    class MainClass
    {
        public static double Miliseconds => DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;

        public static void Main(string[] args)
        {
			ServicePointManager.ServerCertificateValidationCallback +=
	(sender, cert, chain, sslPolicyErrors) => true;
            HtmlAgilityPack.HtmlNode.ElementsFlags.Remove("form"); //forms fix
            Application.Init();
            MainWindow win = new MainWindow();
            win.Show();
            Application.Run();
        }
    }
}
