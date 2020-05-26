using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCS_Main_APP.Interfaces
{
    /// <summary>
    /// Interface with tags from RCS_Configurations.xml file
    /// </summary>
    interface IXMLConfigFileTags
    {
        string Controller_ID { get; set; }
        string System_Location { get; set; }
        int Number_Subscribers { get; set; }
        string[] subscriber_Email_Address { get; set; }
        string R4_hook { get; set; }
        string Robot_Support_hook { get; set; }
        string RCS_Email_Domain { get; set; }
        string RCS_Email_Password { get; set; }
    }
}
