using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scout.DataModel
{
    class PowershellSettings
    {
        public string PSv2 { get; set; }
        public string PSv5 { get; set; }

        public Dictionary<string, string> TranscriptionSettings { get; set; }
        public Dictionary<string, string> ModuleLoggingSettings { get; set; }
        public Dictionary<string, string> ScriptblockLoggingSettings { get; set; }

    }
}
