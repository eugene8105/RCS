using Microsoft.Extensions.Logging;
using NLog;
using RCS_Main_APP.Data;
using System;
using System.Collections.Generic;
using System.Xml;

namespace RCS_Main_APP
{
    static class Utilities
    {
        public static string FileName { get; set; }
        static public List<ConfigData> cd { get; set; }

        static ConfigData confD;

        public static string errorMsExcep;
        public static List<ConfigData> ReadConfigXmlFileSetList()
        {
            cd = new List<ConfigData>();
            FileName = "C:\\_Processes\\GIT_Work\\RCS_Project\\RCS_MonitoringApp\\RCS\\RCS_Configurations.xml";

            try
            {
                using (XmlReader reader = XmlReader.Create(FileName))
                {
                    // setting the parameters from RCS_Configuration.xml file in ConfigData class
                    confD = new ConfigData();
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            //return only when you have START tag  
                            switch (reader.Name.ToString())
                            {
                                case "Controller_ID":
                                    confD.Controller_ID = reader.ReadString();
                                    break;
                                case "System_Location":
                                    confD.System_Location = reader.ReadString();
                                    break;
                                case "Number_Subscribers":
                                    confD.Number_Subscribers = Int32.Parse(reader.ReadString());
                                    break;
                                case "subscriber_Email_Address":
                                    confD.subscriber_Email_Address = reader.ReadString().Split(',');
                                    break;
                                case "R4_hook":
                                    confD.R4_hook = reader.ReadString();
                                    break;
                                case "Robot_Support_hook":
                                    confD.Robot_Support_hook = reader.ReadString();
                                    break;
                                case "RCS_Email_Domain":
                                    confD.RCS_Email_Domain = reader.ReadString();
                                    break;
                                case "RCS_Email_Password":
                                    confD.RCS_Email_Password = reader.ReadString();
                                    break;
                            } // end of switch
                        }
                    }
                    // inserting inside of list an ConfigData object
                    cd.Add(confD);
                }
            } // end of try
            catch (Exception t)
            {
                errorMsExcep = t.Message;
            } // end of catch
            return cd;
        } // end of ReadConfigXmlFileSetList method
    } // end of class
} // end of namespace
