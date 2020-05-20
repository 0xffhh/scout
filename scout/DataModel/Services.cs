using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace scout.DataModel
{
    class Services
    {
        public string ServiceName { get; set; }
        public string DisplayName { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ServiceControllerStatus Status { get; set; }

        public Services(string pvServiceName, string pvDisplayName, ServiceControllerStatus pvStatus)
        {
            ServiceName = pvServiceName;
            DisplayName = pvDisplayName;
            Status = pvStatus;
        }
    }
}
