using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace ReportGenerator
{
    public class LogHelper
    {
        public static void WriteLine(string text)
        {
            // Set log file path
            string appPath = Path.GetDirectoryName(Assembly.GetAssembly(typeof(LogHelper)).CodeBase);
            if (appPath.Substring(appPath.Length - 1) != "\\")
            {
                appPath += "\\";
            }
            appPath = appPath.Replace("file:\\", "");
            string fileName = appPath + "logfile.txt";

            StreamWriter log;
            try
            {
                // Get file
                if (!File.Exists(fileName))
                {
                    log = new StreamWriter(fileName);
                }
                else
                {
                    log = File.AppendText(fileName);
                }

                // Write to the file:
                log.WriteLine(DateTime.Now + ": " + text);

                // Close the stream:
                log.Close();
            }
            catch
            { 
                // Silence error
            }
        }
    }
}
