using System;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.Discovery;
using NLog;
using RCS_Main_APP.Interfaces;
using ABB.Robotics.Controllers.EventLogDomain;

namespace RCS_Main_APP.Presenter
{
    static class ControllerPresenter
    {
        static Logger logger;

        static public NetworkScanner Scanner { get; set; }
        static public Controller Cntr { get; set; }
        static public ABB.Robotics.Controllers.RapidDomain.Task[] Tasks { get; set; }
        static public NetworkWatcher NetWatch { get; set; }
        static public ControllerInfo ContrInfo { get; set; }
        static public ControllerInfoCollection CntCollection { get; set; }
        static public EventLog AbbELog { get;set;}
        static public bool CntPresent { get; set; } = false;
        static public bool Successful { get; set; } = false;
        static public bool SetConfigSuccessful { get; set; } = false;
        static string controllerId = "";

        static ControllerPresenter()
        {
            logger = NLog.Web.NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();

            Scanner = new NetworkScanner();
            Scanner.Scan();
            if(Scanner.Controllers.Count != 0) { CntPresent = true; }
        }
        static private ABB.Robotics.Controllers.RapidDomain.Task[] _tasks = null;
        /// <summary>
        /// scanning network and setting up the controller
        /// </summary>
        static public bool ControllerSetUp()
        {
            try
            {
                // checking if ReadConfigXmlFileSetList returns an empty list or not
                if (Utilities.ReadConfigXmlFileSetList() != null)
                {
                    SetConfigSuccessful = true;
                }
            }
            catch (Exception)
            {
                logger.Error(Utilities.errorMsExcep);
            }
            
            foreach (var t in Utilities.cd)
            {
                controllerId = t.Controller_ID;
            }
            int i = 0;
            if (SetConfigSuccessful == true)
            {
                try
                {
                    // scanning the network for a controller availability
                    Scanner.Scan();
                    for (i = 0; i < Scanner.Controllers.Count; i++)
                    {

                        if (Scanner.Controllers[i].Name.Equals(controllerId))
                        {
                            ContrInfo = Scanner.Controllers[i];
                            if (ContrInfo.Availability == Availability.Available)
                            {
                                if (Cntr != null)
                                {
                                    Cntr.Logoff();
                                    Cntr = null;
                                }

                                //DisableController();
                            }
                            Cntr = ControllerFactory.CreateFrom(ContrInfo);
                            Cntr.Logon(UserInfo.DefaultUser);
                            AbbELog = Cntr.EventLog;
                            Successful = true;
                        }
                    }
                }
                catch (Exception excp)
                {
                    logger.Error($"Problem to set up a controller: {excp.Message}");
                    Successful = false;
                }

                if (Scanner.Controllers.Count == 0)
                {
                    Successful = false;
                    logger.Info($"Scanner did not found controllers on the network.");
                }
            }
            else
            {
                Successful = false;
            }
            return Successful;
        } // end of ControllerSetUp method
        
        /// <summary>
        /// will disable controller which will be passed inside of the method 
        /// </summary>
        /// <returns></returns>
        static public void DisableController()
        {
            Cntr.Dispose();
            Cntr = null;
        }
        /// <summary>
        /// Will check before connecting to the controller if controller is active and if it's active it will AbbELog off from this controller and will dispose that controller. 
        /// </summary>
        /// <returns></returns>
        static public void EnableController()
        {
            if (Cntr != null) //if selecting a new controller
            {
                try
                {
                    using (Cntr)
                    {
                        Cntr.Logoff();
                        Cntr.Dispose();
                        Cntr = null;
                    }

                }
                catch (Exception e)
                {
                    logger.Error($"Inside of ControllerPresenter {e}");
                }

            }
        } // end of EnableController method

    } // end of ControllerPresenter class
} // end of RCS_Main_APP.Presenter
