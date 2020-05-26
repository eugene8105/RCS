using RCS_Main_APP.Interfaces;

namespace RCS_Main_APP.Data
{
    class ConfigData : IXMLConfigFileTags
    {
        public string Controller_ID { get; set; }
        public string System_Location { get; set; }
        public int Number_Subscribers { get; set; }
        public string[] subscriber_Email_Address { get; set; }
        public string R4_hook { get; set; }
        public string Robot_Support_hook { get; set; }
        public string RCS_Email_Domain { get; set; }
        public string RCS_Email_Password { get; set; }
    }
}
