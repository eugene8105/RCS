using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCS_Main_APP.Interfaces;
using RCS_Main_APP.Presenter;
using RCS_Main_APP.Data;
using RCS_Main_APP.Models;

namespace RCS_Main_APP.View
{
    class SupportRequesView : ISupportRequestView
    {
        SettingsConfigureModel scm = new SettingsConfigureModel();
        public string StreetName { get; set; }
        public string RobSupportText { get; set; } 
        public string R4SupportText { get; set; }
        public string WebHookR4Support { get; set; }
        public string WebHookRobotSupport { get; set; }

        public SupportRequesView()
        {
            foreach (var i in scm.cd)
            {
                StreetName = i.LocationName;
                WebHookR4Support = i.WebHookR4Support;
                WebHookRobotSupport = i.WebHookRobotSupport;
            }
            //StreetName = "Autobahn";
            RobSupportText = $"{StreetName} is requested robot support!";
            R4SupportText = $"{StreetName} is requested R4 support!";
        }
    } // end of SupportRequesView
}
