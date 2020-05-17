using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace scout
{
    class Program
    {
        static void PrintSectionHeader(string header)
        {
            Console.WriteLine($"[======== {header.ToUpper()} ========]");
        }

        static void PrintSectionFooter()
        {
           Console.WriteLine($"\n");
        }

        static void PrintItemHeader(string title)
        {
            Console.WriteLine($"\n[-------- {title} --------]");
        }

        static void PrintItemValue(string title, object value)
        {
            Console.WriteLine($"{title}: {value}");
        }

        static void GetProcesses()
        {
            PrintSectionHeader("PROCESSES");
            try
            {
                var processes = Process.GetProcesses(Helpers.COMPUTERNAME);
                Console.WriteLine("PID\t\tName");
                foreach (Process process in processes)
                {
                    if (Helpers.DefensiveProcesses.ContainsKey(process.ProcessName.ToLower()))
                    {
                        Console.WriteLine($"{process.Id}\t\t{process.ProcessName} [DEFENSIVE PROCESS]");
                    }
                    else
                    {
                        Console.WriteLine($"{process.Id}\t\t{process.ProcessName}");
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine($"[!] Error: {e}");
            }
            PrintSectionFooter();
        }

        public static void ListAuditSettings()
        {
            PrintSectionHeader("Audit Settings");
            Dictionary<string, object> settings = Helpers.GetRegValues("HKLM", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\\Audit");
            if ((settings != null) && (settings.Count != 0))
            {
                foreach (KeyValuePair<string, object> kvp in settings)
                {
                    if (kvp.Value.GetType().IsArray && (kvp.Value.GetType().GetElementType().ToString() == "System.String"))
                    {
                        string result = string.Join(",", (string[])kvp.Value);
                        PrintItemValue(kvp.Key, result);
                    }
                    else
                    {
                        PrintItemValue(kvp.Key, kvp.Value);
                    }
                }
            }
            else
            {
                Console.WriteLine("No Audit Settings Found");
            }
            PrintSectionFooter();
        }

        public static void ListWEFSettings()
        {
            PrintSectionHeader("WEF Settings");
            Dictionary<string, object> settings = Helpers.GetRegValues("HKLM", "Software\\Policies\\Microsoft\\Windows\\EventLog\\EventForwarding\\SubscriptionManager");
            if ((settings != null) && (settings.Count != 0))
            {
                foreach (KeyValuePair<string, object> kvp in settings)
                {
                    if (kvp.Value.GetType().IsArray && (kvp.Value.GetType().GetElementType().ToString() == "System.String"))
                    {
                        string result = string.Join(",", (string[])kvp.Value);
                        PrintItemValue(kvp.Key, result);
                    }
                    else
                    {
                        PrintItemValue(kvp.Key, kvp.Value);
                    }
                }
            }
            else
            {
                Console.WriteLine("No WEF Settings Found");
            }
            PrintSectionFooter();
        }

        static void GetPowerShellInformation() 
        {
            PrintSectionHeader("PowerShell Settings");
            string PowerShellVersion2 = Helpers.GetRegValue("HKLM", "SOFTWARE\\Microsoft\\PowerShell\\1\\PowerShellEngine", "PowerShellVersion");
            PrintItemValue("PowerShell v2 Version", PowerShellVersion2);

            string PowerShellVersion5 = Helpers.GetRegValue("HKLM", "SOFTWARE\\Microsoft\\PowerShell\\3\\PowerShellEngine", "PowerShellVersion");
            PrintItemValue("PowerShell v5 Version", PowerShellVersion5);

            Dictionary<string, object> transcriptionSettings = Helpers.GetRegValues("HKLM", "SOFTWARE\\Policies\\Microsoft\\Windows\\PowerShell\\Transcription");
            PrintItemHeader("Transcription Settings");
            if ((transcriptionSettings != null) && (transcriptionSettings.Count != 0))
            {
                foreach (KeyValuePair<string, object> kvp in transcriptionSettings)
                {
                    PrintItemValue(kvp.Key, kvp.Value);
                }
            }
            else
            {
                Console.WriteLine("No Transcription Settings Found.");
            }

            Dictionary<string, object> moduleLoggingSettings = Helpers.GetRegValues("HKLM", "SOFTWARE\\Policies\\Microsoft\\Windows\\PowerShell\\ModuleLogging");
            PrintItemHeader("Module Logging Settings");
            if ((moduleLoggingSettings != null) && (moduleLoggingSettings.Count != 0))
            {
                foreach (KeyValuePair<string, object> kvp in moduleLoggingSettings)
                {
                    PrintItemValue(kvp.Key, kvp.Value);
                }
            }
            else
            {
                Console.WriteLine("No Module Logging Settings Found.");
            }

            Dictionary<string, object> scriptBlockSettings = Helpers.GetRegValues("HKLM", "SOFTWARE\\Policies\\Microsoft\\Windows\\PowerShell\\ScriptBlockLogging");
            PrintItemHeader("Scriptblock Logging Settings");
            if ((scriptBlockSettings != null) && (scriptBlockSettings.Count != 0))
            {
                foreach (KeyValuePair<string, object> kvp in scriptBlockSettings)
                {
                    PrintItemValue(kvp.Key, kvp.Value);
                }
            }
            else
            {
                Console.WriteLine("No Script Block Settings Found.");
            }
            PrintSectionFooter();
        }

        static public void GetDotNetVersions()
        {
            PrintSectionHeader(".NET Versions");
            List<string> dotnetVersions = new List<string>();
            dotnetVersions.Add(Helpers.GetRegValue("HKLM", "SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v3", "Version"));
            dotnetVersions.Add(Helpers.GetRegValue("HKLM", "SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v3.5", "Version"));
            dotnetVersions.Add(Helpers.GetRegValue("HKLM", "SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full", "Version"));
            dotnetVersions.Add(Helpers.GetRegValue("HKLM", "SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Client", "Version"));
            foreach (string version in dotnetVersions)
            {
                if (!String.IsNullOrEmpty(version))
                {
                    Console.WriteLine($" {version}");
                }
            }
            PrintSectionFooter();
        }

        static public void GetServices()
        {
            PrintSectionHeader("Services");
            var services = ServiceController.GetServices(Helpers.COMPUTERNAME);
            foreach (ServiceController service in services)
            {
                PrintItemValue(service.DisplayName, service.Status);
            }
            PrintSectionFooter();
        }

        static void Main(string[] args)
        {
            if (args == null || args.Length != 1)
            {
                Console.WriteLine("[!] Usage: scout.exe <COMPUTERNAME|IPADDRESS>");
                Environment.Exit(1);
            }
            Helpers.COMPUTERNAME = args[0];
            Console.WriteLine($"[i] Running Scout against {Helpers.COMPUTERNAME}..");
            GetProcesses();
            GetServices();
            GetPowerShellInformation();
            GetDotNetVersions();
            ListAuditSettings();
            ListWEFSettings();

        }
    }
}
