using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using RCS_Main_APP.Data;


namespace RCS_Main_APP.Models
{
    class SettingsConfigureModel
    {
        public string FileName { get; set; }
        public string ModuleName { get; set; }
        public List<ConfigData> cd { get; set; }
        Logger logger = null;
        public SettingsConfigureModel()
        {
            cd = new List<ConfigData>();
            FileName = "C:\\_Processes\\GIT_Work\\RCS_Project\\RCS\\RCS_Development\\RCS_Notifications_Dev\\RCS_Configurations.xml";  // RCS_Configurations.xml
            logger = NLog.Web.NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
            RCS_readConfig();
        }

        public List<ConfigData> RCS_readConfig()
        {
            try
            {
                string[] lines = File.ReadAllLines(FileName);
                cd.Add(new ConfigData
                {
                    // [0] - Comments - "Controller ID"
                    // [1] - ID   - .......
                    CntrID = lines[1],
                    // [2] - Comments - "Load Module from - path location"
                    // [3] - Path - .......
                    LoadFromPath = lines[3],
                    // [4] - Comments - "Save Module to - path location"
                    // [5] - Path - .......
                    SaveToPath = lines[5],
                    // [6] - Comments - "Save Backup path location"
                    // [7] - Path - .......
                    BackupPath = lines[7],
                    // [8] - Comments - "Path to the PartData file"
                    // [9] - Path to the part data file.
                    PartDataPth = lines[9],
                    // [10] - Comments - "Name of the location where the system and controller is set up - street name"
                    // [11] - Name - ......
                    LocationName = lines[11],
                    // [12] - Comments - "Numbers of Email Subscribers for notifications"
                    // [13] - Number - .....
                    NumOfSubscribers = lines[13],
                    // [14] - Comments - "Notifications Email Subscribers. If more than one subscriber separate them with ',' and             change the number above from 1 to number of subscribers. Example - first@email.com,second@email.com"
                    // [15] - Emails - ......
                    EmailSubscribers = lines[15].Split(','),
                    // [16] - Comments - "Slack R4 request Web hook"
                    // [17] - Slack R4 Support request Web hook
                    WebHookR4Support = lines[17],
                    // [18] - Comments - "Slack Robotic Support Web hook"
                    // [19] - Slack Robotic Support request Web hook
                    WebHookRobotSupport = lines[19],
                    // [20] - Comments - "RCS email domain"
                    // [21] - Address
                    RCSEmailAddress = lines[21],
                    // [22] - Comments - "RCS email password"
                    // [23] - Password
                    RCSEmailPass = lines[23]
                });
            }
            catch (Exception e)
            {
                logger.Error($"Problem to read from RCS configuration file. {e}");
            }
            return cd;
        } // end of RCS_readConfig method
    } // end of SettingsConfigure class
}
