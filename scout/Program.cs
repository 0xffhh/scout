using Newtonsoft.Json;
using scout.DataModel;
using scout.DataModel.AuditPol;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceProcess;
using System.Text;

namespace scout
{
    class Program
    {

        private static AllSettings allSettings;

        static void PrintSectionHeader(string header)
        {
            //Console.WriteLine($"[======== {header.ToUpper()} ========]");
        }

        static void PrintSectionFooter()
        {
            //Console.WriteLine($"\n");
        }

        static void PrintItemHeader(string title)
        {
            //Console.WriteLine($"\n|-------- {title} --------|");
        }

        static void PrintItemValue(string title, object value)
        {
            //Console.WriteLine($"{title}: {value}");
        }

        static string GetJson()
        {
            return JsonConvert.SerializeObject(allSettings, Formatting.Indented);
        }

        static void GetProcesses()
        {
            PrintSectionHeader("PROCESSES");
            var processes = Process.GetProcesses(Helpers.COMPUTERNAME);
            //Console.WriteLine("PID\t\tName");
            foreach (Process process in processes.OrderBy(p => p.ProcessName))
            {
                if (Helpers.InterestingProcesses.ContainsKey(process.ProcessName))
                {
                    allSettings.processes.Add(new DataModel.ProcessModel(process.Id, process.ProcessName, Helpers.InterestingProcesses[process.ProcessName].ToString()));
                    //Console.WriteLine($"{process.Id}\t\t{process.ProcessName} [{Helpers.InterestingProcesses[process.ProcessName]}]");
                }
                else
                {
                    allSettings.processes.Add(new DataModel.ProcessModel(process.Id, process.ProcessName));
                    //Console.WriteLine($"{process.Id}\t\t{process.ProcessName}");
                }
            }
            PrintSectionFooter();
        }

        public static void ListAuditSettings()
        {
            AuditPolicy ap = new AuditPolicy();

            var categories = AuditPolicyFetcher.GetCategoryIdentifiers();
            categories.ForEach(x => ap.AddCategory(x, AuditPolicyFetcher.GetCategoryDisplayName(x)));

            //For each category, get the subcategories , lookup subcategory display name and add these pairs to the category
            ap.Categories.ForEach(c =>
            {
                var subCategories = AuditPolicyFetcher.GetSubCategoryIdentifiers(c.Identifier);
                subCategories.ForEach(sc =>
                {
                    c.AddSubCategory(sc, AuditPolicyFetcher.GetSubCategoryDisplayName(sc), AuditPolicyFetcher.GetSystemPolicy(sc));
                });
            });

            allSettings.auditSettings = ap;
            //PrintSectionHeader("Audit Settings");
            //Dictionary<string, object> settings = Helpers.GetRegValues("HKLM", "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\\Audit");
            //if ((settings != null) && (settings.Count != 0))
            //{
            //    foreach (KeyValuePair<string, object> kvp in settings)
            //    {
            //        if (kvp.Value.GetType().IsArray && (kvp.Value.GetType().GetElementType().ToString() == "System.String"))
            //        {
            //            string result = string.Join(",", (string[])kvp.Value);

            //            PrintItemValue(kvp.Key, result);
            //        }
            //        else
            //        {
            //            PrintItemValue(kvp.Key, kvp.Value);
            //        }
            //    }
            //}
            //else
            //{
            //    //Console.WriteLine("No Audit Settings Found");
            //}
            //PrintSectionFooter();
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
                        allSettings.wefSettings.Add(kvp.Key, result);
                        PrintItemValue(kvp.Key, result);
                    }
                    else
                    {
                        allSettings.wefSettings.Add(kvp.Key, kvp.Value.ToString());
                        PrintItemValue(kvp.Key, kvp.Value);
                    }
                }
            }
            else
            {
                //Console.WriteLine("No WEF Settings Found");
            }
            PrintSectionFooter();
        }

        static void GetPowerShellInformation()
        {
            PrintSectionHeader("PowerShell Settings");
            string PowerShellVersion2 = Helpers.GetRegValue("HKLM", "SOFTWARE\\Microsoft\\PowerShell\\1\\PowerShellEngine", "PowerShellVersion");
            allSettings.powershellSettings.PSv2 = PowerShellVersion2;
            PrintItemValue("PowerShell v2 Version", PowerShellVersion2);

            string PowerShellVersion5 = Helpers.GetRegValue("HKLM", "SOFTWARE\\Microsoft\\PowerShell\\3\\PowerShellEngine", "PowerShellVersion");
            allSettings.powershellSettings.PSv5 = PowerShellVersion5;
            PrintItemValue("PowerShell v5 Version", PowerShellVersion5);

            Dictionary<string, object> transcriptionSettings = Helpers.GetRegValues("HKLM", "SOFTWARE\\Policies\\Microsoft\\Windows\\PowerShell\\Transcription");
            PrintItemHeader("Transcription Settings");
            if ((transcriptionSettings != null) && (transcriptionSettings.Count != 0))
            {
                foreach (KeyValuePair<string, object> kvp in transcriptionSettings)
                {
                    allSettings.powershellSettings.TranscriptionSettings.Add(kvp.Key, kvp.Value.ToString());
                    PrintItemValue(kvp.Key, kvp.Value);
                }
            }
            else
            {
                //Console.WriteLine("No Transcription Settings Found.");
            }

            Dictionary<string, object> moduleLoggingSettings = Helpers.GetRegValues("HKLM", "SOFTWARE\\Policies\\Microsoft\\Windows\\PowerShell\\ModuleLogging");
            PrintItemHeader("Module Logging Settings");
            if ((moduleLoggingSettings != null) && (moduleLoggingSettings.Count != 0))
            {
                foreach (KeyValuePair<string, object> kvp in moduleLoggingSettings)
                {
                    allSettings.powershellSettings.ModuleLoggingSettings.Add(kvp.Key, kvp.Value.ToString());
                    PrintItemValue(kvp.Key, kvp.Value);
                }
            }
            else
            {
                //Console.WriteLine("No Module Logging Settings Found.");
            }

            Dictionary<string, object> scriptBlockSettings = Helpers.GetRegValues("HKLM", "SOFTWARE\\Policies\\Microsoft\\Windows\\PowerShell\\ScriptBlockLogging");
            PrintItemHeader("Scriptblock Logging Settings");
            if ((scriptBlockSettings != null) && (scriptBlockSettings.Count != 0))
            {
                foreach (KeyValuePair<string, object> kvp in scriptBlockSettings)
                {
                    allSettings.powershellSettings.ScriptblockLoggingSettings.Add(kvp.Key, kvp.Value.ToString());
                    PrintItemValue(kvp.Key, kvp.Value);
                }
            }
            else
            {
                //Console.WriteLine("No Script Block Settings Found.");
            }
            PrintSectionFooter();
        }

        static public void GetDotNetVersions()
        {
            PrintSectionHeader(".NET Versions");
            List<string> dotnetVersions = new List<string>();
            dotnetVersions.Add(Helpers.GetRegValue("HKLM", "SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v3", "Version"));
            allSettings.dotNetVersions.DotNetV3 = dotnetVersions.Last();
            dotnetVersions.Add(Helpers.GetRegValue("HKLM", "SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v3.5", "Version"));
            allSettings.dotNetVersions.DotNetV35 = dotnetVersions.Last();
            dotnetVersions.Add(Helpers.GetRegValue("HKLM", "SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full", "Version"));
            allSettings.dotNetVersions.DotNetV4Full = dotnetVersions.Last();
            dotnetVersions.Add(Helpers.GetRegValue("HKLM", "SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Client", "Version"));
            allSettings.dotNetVersions.DotNetV4Client = dotnetVersions.Last();
            foreach (string version in dotnetVersions)
            {
                if (!String.IsNullOrEmpty(version))
                {
                    //Console.WriteLine($"{version}");
                }
            }
            PrintSectionFooter();
        }

        static public void GetServices()
        {
            PrintSectionHeader("Services");
            var runningServices = new List<ServiceController>();
            var otherServices = new List<ServiceController>();
            var services = ServiceController.GetServices(Helpers.COMPUTERNAME);
            foreach (ServiceController service in services.OrderBy(s => s.ServiceName))
            {
                allSettings.services.Add(new Services(service.ServiceName, service.DisplayName, service.Status));
                if (service.Status == ServiceControllerStatus.Running)
                {
                    runningServices.Add(service);
                }
                else
                {
                    otherServices.Add(service);
                }
            }
            PrintItemHeader("Running Services");
            foreach (ServiceController service in runningServices)
            {
                PrintItemValue(service.ServiceName, service.DisplayName);
            }
            PrintItemHeader("Other Services");
            foreach (ServiceController service in otherServices)
            {
                PrintItemValue(service.ServiceName, $"{service.DisplayName} ({service.Status})");
            }

            PrintSectionFooter();
        }

        static void Main(string[] args)
        {
            


            if (args == null || args.Length != 1)
            {
                Helpers.COMPUTERNAME = Environment.MachineName;
            }
            else
            {
                Helpers.COMPUTERNAME = args[0];
            }
            Console.WriteLine($"[i] Running Scout against {Helpers.COMPUTERNAME}..");
            allSettings = new AllSettings();
            
            try
            {
                GetProcesses();
                GetServices();
                GetPowerShellInformation();
                GetDotNetVersions();
                ListAuditSettings();
                ListWEFSettings();
                File.WriteAllText("output.json", GetJson());
            }
            catch (Exception e)
            {
                Console.WriteLine($"[!] Error running Scout:\n\n{e}");
            }

        }
    }
}
