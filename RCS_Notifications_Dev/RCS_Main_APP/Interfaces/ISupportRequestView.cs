using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCS_Main_APP.Interfaces
{
    interface ISupportRequestView
    {
        string StreetName { get; set; }
        string RobSupportText { get; set; }
        string R4SupportText { get; set; }
        string WebHookR4Support { get; set; }
        string WebHookRobotSupport { get; set; }

    } // end of ISupportRequestView interface
}
