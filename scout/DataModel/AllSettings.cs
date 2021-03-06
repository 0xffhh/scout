﻿using scout.DataModel.AuditPol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scout.DataModel
{
    class AllSettings
    {
        public AuditPolicy auditSettings { get; set; }

        public DotNetVersions dotNetVersions { get; private set; }

        public PowershellSettings powershellSettings { get; private set; }

        public List<ProcessModel> processes { get; private set; }

        public List<Services> services { get; private set; }

        public Dictionary<string, string> wefSettings { get; private set; }

        public AllSettings()
        {
            auditSettings = new AuditPolicy();
            dotNetVersions = new DotNetVersions();
            powershellSettings = new PowershellSettings();
            processes = new List<ProcessModel>();
            services = new List<Services>();
            wefSettings = new Dictionary<string, string>();
        }

    }
}
