using RCS_Main_APP.Interfaces;

namespace RCS_Main_APP.View
{
    class SupportRequesView : ISupportRequestView
    {
        public string StreetName { get; set; }
        public string RobSupportText { get; set; } 
        public string R4SupportText { get; set; }
        public string WebHookR4Support { get; set; }
        public string WebHookRobotSupport { get; set; }

        public SupportRequesView()
        {
            foreach (var i in Utilities.cd)
            {
                StreetName = i.System_Location;
                WebHookR4Support = i.R4_hook;
                WebHookRobotSupport = i.Robot_Support_hook;
            }
            //StreetName = "Autobahn";
            RobSupportText = $"{StreetName} is requested robot support!";
            R4SupportText = $"{StreetName} is requested R4 support!";
        }
    } // end of SupportRequesView
}
