using System;
using NLog;
using System.Windows.Forms;
using RCS_Main_APP.View;
using RCS_Main_APP.Presenter;
using System.Drawing;
using ABB.Robotics.Controllers;
using RCS_Main_APP.Interfaces;
using System.Threading;
using ABB.Robotics;

namespace RCS_Main_APP
{
    public partial class FormMain : Form, IMainSetup
    {
        /// <summary>
        /// Creates Log file and writes errors, infos, warns in to it.
        /// Setup location of the Log file inside of NLog.config - C:\Eugene\GIT_Work\RCS_Project
        /// </summary>
        Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
        /// <summary>
        /// Making instance of ControllerPresenter. ControllerPresenter using IControllerModel interface
        /// </summary>
        ControllerPresenter controllerPres = new ControllerPresenter();

        EventHandlerPresenter ehp = new EventHandlerPresenter();
        
        public string MainLblControllerInfo { get; set; }
        public FormMain()
        {
            logger.Info("Program started.");
            InitializeComponent();
        }
        /// <summary>
        /// exit label in the top right side of the RCS Main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            logger.Info("Program closed.");
        }
        /// <summary>
        /// minimize label in the top right side of the RCS Main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            controllerPres.SetConfig();
            this.TopMost = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // no borders - set for none. With border - FixedSingle
            //this.WindowState = FormWindowState.Maximized;
            //ConnectController();
            ControllerOnNetworkOutputOnMain();

        } // end of Form1_Load method
        /// <summary>
        /// Printing output on the Main screen on the bottom if it seeing any available controllers on the network
        /// </summary>
        public void ControllerOnNetworkOutputOnMain()
        {
            if (controllerPres.CntPresent == true)
            {
                MainLblControllerInfo = "Found controller on the network!";
                lblMainControllerAvb.Text = MainLblControllerInfo;
                lblMainControllerAvb.ForeColor = Color.Green;
            }
            else
            {
                MainLblControllerInfo = "Not found controller on the network!";
                lblMainControllerAvb.Text = MainLblControllerInfo;
                lblMainControllerAvb.ForeColor = Color.Red;
            }
        } // end of ControllerOnNetworkOutputOnMain method
       
        string newLine = Environment.NewLine;

        DateTime startTime = DateTime.Now;
        DateTime newTime = DateTime.Now;

        /// <summary>
        /// When Robot Support button clicked this method sending notification on Slack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRobotSupport_Click(object sender, EventArgs e)
        {
            SupportRequesView srv = new SupportRequesView();
            SupportRequesPresenter srp = new SupportRequesPresenter(srv);
            if (txMainTextBox.Text == "")
            {
                startTime = DateTime.Now;
            }
            newTime = DateTime.Now;
            // example of costume date and time
            //newTime = DateTime.Parse("08/10/2011 23:50:31");

            try
            {
                TimeComparing();
                srp.RoboticSupportReq();
                txMainTextBox.Text += $"{newLine}Robot support request was sent successfully. {DateTime.Now.ToString()}{newLine}";
                logger.Info("Robot Support was requested.");

            }
            catch (Exception)
            {
                logger.Error("It was a problem with your request.");
                txMainTextBox.Text = $"{newLine}It was an ERROR. Please try again.";
            }

        } // end of btnRobotSupport_Click method
        
        /// <summary>
        /// When R4 Support button clicked this method sending notification on Slack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnR4Support_Click(object sender, EventArgs e)
        {
            SupportRequesView srv = new SupportRequesView();
            SupportRequesPresenter srp = new SupportRequesPresenter(srv);
            if (txMainTextBox.Text == "")
            {
                startTime = DateTime.Now;
            }

            newTime = DateTime.Now;

            try
            {
                TimeComparing();
                srp.R4supportReq();
                txMainTextBox.Text += $"{newLine}R4 support request was sent successfully. {DateTime.Now.ToString()}{newLine}";
                logger.Info("R4 support was requested.");
            }
            catch (Exception)
            {
                logger.Error("It was a problem with your request.");
                txMainTextBox.Text = $"{newLine}It was an ERROR. Please try again.";
            }
        }
        private void TimeComparing ()
        {
            if ((newTime - startTime).TotalMinutes >= 1440) // 1440 is a minutes in 24 hours 
            {
                txMainTextBox.Text = "";
            }
        }
        private void btnStartMonitoring_Click(object sender, EventArgs e)
        {
            ehp.ProcessMonitoring();
            if (ehp.monitoringRunning)
            {
                btnStartMonitoring.BackColor = Color.Green;
                btnStartMonitoring.Text = "Monitoring is running.";
                txCntConnected.Text = "Monitoring process is started.";
                txMainTextBox.Text = $"{newLine}Output from Monitoring Process";
            }
            else
            {
                txCntConnected.Text = "Monitoring process is not running.";
                btnStartMonitoring.BackColor = Color.Red;
            }
        }
    } // end of FormMain class
} // end of namespace RCS_Main_APP
