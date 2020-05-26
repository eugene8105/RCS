using RCS_Main_APP.Interfaces;

namespace RCS_Main_APP.Data
{
    class ConfigData : ISettingsConfig
    {
        public string FullPath { get; set; }
        public string BackupPath { get; set; }
        public string CntrID { get; set; }
        public string SaveToPath { get; set; }
        public string LoadFromPath { get; set; }
        public string PartDataPth { get; set; }
        public string LocationName { get; set; }
        public string[] EmailSubscribers { get; set; }
        public string NumOfSubscribers { get; set; }
        public string WebHookRobotSupport { get; set; }
        public string WebHookR4Support { get; set; }
        public string RCSEmailAddress { get; set; }
        public string RCSEmailPass { get; set; }
    }
}
