using System;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.Discovery;
using NLog;
using RCS_Main_APP.Models;
using RCS_Main_APP.Interfaces;
using System.Windows.Forms;
using ABB.Robotics.Controllers.IOSystemDomain;
using ABB.Robotics.Controllers.RapidDomain;
using System.Threading;
using System.IO;
using ABB.Robotics.Controllers.EventLogDomain;

namespace RCS_Main_APP.Presenter
{
    class ControllerPresenter : IControllerModel
    {
        /// <summary>
        /// setting up a AbbELog settings
        /// </summary>
        Logger logger;
        /// <summary>
        /// setting configurations about the controller, path to the modules so on ....
        /// </summary>
        SettingsConfigureModel setupConfig;

        public NetworkScanner Scanner { get; set; }
        public Controller Cntr { get; set; }
        public ABB.Robotics.Controllers.RapidDomain.Task[] Tasks { get; set; }
        public NetworkWatcher NetWatch { get; set; }
        public ControllerInfo ContrInfo { get; set; }
        public ControllerInfoCollection CntCollection { get; set; }
        public EventLog AbbELog { get;set;}
        public bool CntPresent { get; set; } = false;
        public bool Successful { get; set; } = false;
        public bool SetConfigSuccessful { get; set; } = false;
        string mdName = "";

        public ControllerPresenter()
        {
            setupConfig = new SettingsConfigureModel();
            logger = NLog.Web.NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();

            Scanner = new NetworkScanner();
            Scanner.Scan();
            if(Scanner.Controllers.Count != 0) { CntPresent = true; }
        }
        private ABB.Robotics.Controllers.RapidDomain.Task[] tasks = null;
        /// <summary>
        /// SetConfig - setting up the configuration from RCS_conf file
        /// </summary>
        public void SetConfig()
        {
            // checking and reading from RCS_conf file
            try
            {
                setupConfig.RCS_readConfig();
                SetConfigSuccessful = true;
            }
            catch (Exception e)
            {
                SetConfigSuccessful = false;
                logger.Error($"Problem with configuration. {e}");
            }
        } // end of SetConfig method
        /// <summary>
        /// scanning network and setting up the controller
        /// </summary>
        public bool ControllerSetUp()
        {
            SetConfig();
            string controllerId = "";
            foreach (var t in setupConfig.cd)
            {
                controllerId = t.CntrID;
            }
            int i = 0;
            if (SetConfigSuccessful == true)
            {
                try
                {
                    // scanning the network for a controller availability
                    this.Scanner.Scan();
                    for (i = 0; i < Scanner.Controllers.Count; i++)
                    {

                        if (Scanner.Controllers[i].Name.Equals(controllerId))
                        {
                            ContrInfo = Scanner.Controllers[i];
                            if (ContrInfo.Availability == Availability.Available)
                            {
                                if (this.Cntr != null)
                                {
                                    this.Cntr.Logoff();
                                    this.Cntr = null;
                                }

                                //DisableController();
                            }
                            this.Cntr = ControllerFactory.CreateFrom(ContrInfo);
                            this.Cntr.Logon(UserInfo.DefaultUser);
                            AbbELog = Cntr.EventLog;
                            Successful = true;
                        }
                    }
                }
                catch (Exception excp)
                {
                    logger.Error($"Problem to set up a controller {excp}");
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
        /// Assigning a mastership to the provided controller
        /// </summary>
        public void StartProgram()
        {
            mdName = "mTest_03.mod";
            try
            {
                Mastership m;
                if (this.Cntr.OperatingMode == ControllerOperatingMode.Auto)
                {
                    Tasks = Cntr.Rapid.GetTasks();
                    try
                    {
                        using (m = Mastership.Request(Cntr.Rapid))
                        {
                            if (m.IsMaster == true)
                            {
                                try
                                {
                                    //Tasks[0].LoadModuleFromFile($@"{setupConfig.LoadFromPath}\{mdName}", RapidLoadMode.Replace);

                                    // delay to make sure module is loaded inside of controller
                                    Thread.Sleep(2000);
                                    Tasks[0].Start(RegainMode.Continue, ExecutionMode.Continuous, ExecutionCycle.Once);
                                }
                                catch (Exception e)
                                {
                                    logger.Error($"Problem to start the program {e}");
                                    MessageBox.Show($"Problem to start \n{e}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            } // end of if
                        } // end of using
                    }
                    catch (ResourceHeldException t)
                    {
                        logger.Error($"Mastership was held by some one else. {t}");
                        //MessageBox.Show($"Problem with Mastership \n{t}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Automatic mode is required to start execution from a remote clientRobotSupport.", "Error", MessageBoxButtons.OK);
                }
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("Automatic mode is required to start execution from a remote clientRobotSupport.", "Error", MessageBoxButtons.OK);
            }
        }// end of BackupSetup method
        public bool StartBackup()
        {
            //if (rfs.BackupSetup()) == true)
            //{ Successful = true; }
            //else { Successful = false; }
            return Successful;
        }
        public bool BackupSetup(Controller cn, string backPath)
        {
            StartBackup();
            return false;
        }
        /// <summary>
        /// will disable controller which will be passed inside of the method 
        /// </summary>
        /// <returns></returns>
        public void DisableController()
        {
            this.Cntr.Dispose();
            this.Cntr = null;
        }
        /// <summary>
        /// Will check before connecting to the controller if controller is active and if it's active it will AbbELog off from this controller and will dispose that controller. 
        /// </summary>
        /// <returns></returns>
        public void EnableController()
        {
            if (this.Cntr != null) //if selecting a new controller
            {
                try
                {
                    using (this.Cntr)
                    {
                        this.Cntr.Logoff();
                        this.Cntr.Dispose();
                        this.Cntr = null;
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
