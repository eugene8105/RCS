using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCS_Main_APP.Interfaces

{
    interface ISettingsConfig
    {
        /// <summary>
        /// CntrID - controller identification to make sure proper controller will be targeting.
        /// </summary>
        string CntrID { get; set; }
        /// <summary>
        /// SaveToPath - path where to store the module
        /// </summary>
        string SaveToPath { get; set; }
        /// <summary>
        /// LoadFromPath - path where load modules from
        /// </summary>
        string LoadFromPath { get; set; }
        /// <summary>
        /// BackupPath - path to where to make a backup
        /// </summary>
        string BackupPath { get; set; }
        /// <summary>
        /// FullPath - 
        /// </summary>
        string FullPath { get; set; }
        /// <summary>
        /// PartDataPth - 
        /// </summary>
        string PartDataPth { get; set; }
        /// <summary>
        /// LocationName - Name of the location where the system and controller is set up - street name
        /// </summary>
        string LocationName { get; set; }
        /// <summary>
        /// EmailSubscribers - notifications Email Subscribers. 
        /// If more than one subscriber separate them with ';' and change the number above from 1 to number of subscribers. 
        /// Example - first@email.com; second@email.com
        /// </summary>
        string[] EmailSubscribers { get; set; }
        /// <summary>
        /// NumOfSubscribers - Numbers of Emaile Subscribers for notifications
        /// </summary>
        string NumOfSubscribers { get; set; }
        /// <summary>
        /// WebHookRobotSupport - Slack Robot Support request Web hook
        /// </summary>
        string WebHookRobotSupport { get; set; }
        /// <summary>
        /// WebHookR4Support - Slack R4 Support request Web hook
        /// </summary>
        string WebHookR4Support { get; set; }
        string RCSEmailAddress { get; set; }
        string RCSEmailPass { get; set; }

    } // end of ISettingsConfig interface
}
