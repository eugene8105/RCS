using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCS_Main_APP.Interfaces
{
    interface IMonitoringModel
    {
        string Message { get; set; }
        string StreetName { get; set; }
        string EmailSubject { get; set; }
        string Recipients { get; set; }
        bool EmailSuccess { get; set; }
        bool EmailSetup();
    } // end of IMonitoringModel
}
