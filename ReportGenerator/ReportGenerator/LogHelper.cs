/*
 * Copyright 2012 MercadoLibre, Inc.
 *
 * Changed to retrieve a well-formed json string running .ToString() method.
 * Allows to serialize scalar data at CreateFromString method.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you may
 * not use this file except in compliance with the License. You may obtain
 * a copy of the License at
 * 
 *  http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations
 * under the License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace ReportGenerator
{
    /// <summary>
    /// A representation of the Log Helper resource. 
    /// </summary>
    public class LogHelper
    {
        /// <summary>
        /// Writes a string to a log file.
        /// </summary>
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
