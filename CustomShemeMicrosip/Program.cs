using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace CustomShemeMicrosip
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            

            string protocol = "microsip";
            string name = Environment.CurrentDirectory + "\\microsip.exe";
            RegisterURLProtocol(protocol, name);
            SetStartup(protocol, name);
            // RegisterURLProtocol("microsip", "D:\\Project\\pjproject\\Debug\\microsip.exe");
            // Application.Run(new Form1());


        }

        public static void RegisterURLProtocol(string protocolName, string applicationPath)
        {
            try
            {
                // Create new key for desired URL protocol

                Console.WriteLine("applicationPath :"+ applicationPath);

                var KeyTest = Registry.CurrentUser.OpenSubKey("Software", true).OpenSubKey("Classes", true);
                RegistryKey key = KeyTest.CreateSubKey(protocolName);
                key.SetValue("URL Protocol", protocolName);
                key.CreateSubKey(@"shell\open\command").SetValue("", "\"" + applicationPath + "\" \"%1\"");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        public static void SetStartup(string protocolName, string applicationPath)
        {
            try
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                rk.SetValue(protocolName, "\"" + applicationPath+ "\"");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}