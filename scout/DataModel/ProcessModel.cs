using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scout.DataModel
{
    class ProcessModel
    {
        public int Pid { get; set; }
        public string Name { get; set; }
        public string TypeOfProcess { get; set; }

        public ProcessModel(int pvPid, string pvName, string pvTypeOfProcess) : this(pvPid, pvName)
        {
            TypeOfProcess = pvTypeOfProcess;
        }

        public ProcessModel(int pvPid, string pvName)
        {
            Pid = pvPid;
            Name = pvName;
        }


    }
}
