using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCS_Main_APP.Interfaces
{
    interface ISupportRequesModel
    {
        string WebHookR4Support { get; set; }
        string WebHookRobotSupport { get; set; }
        void RoboticSupportRequest(string rSupportText, string r4SupportHook);
        void R4Request(string r4SupportText, string robotSupportHook);
    } // end of ISupportRequesModel interface
}
