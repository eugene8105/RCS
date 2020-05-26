using ABB.Robotics.Controllers.EventLogDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCS_Main_APP.Models;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.RapidDomain;
using System.Xml;
using System.IO;
using NLog;

namespace RCS_Main_APP.Presenter
{
    class EventHandlerPresenter
    {
        Logger logger = null;

        public bool monitoringRunning = false;
        ControllerPresenter cp = new ControllerPresenter();
        MonitoringModel mm = new MonitoringModel();
        public void ProcessMonitoring()
        {
            cp.ControllerSetUp();
            if (cp.Successful)
            {
                monitoringRunning = true;
                cp.Cntr.EventLog.MessageWritten += _errorEventHappened;
                cp.Cntr.ConnectionChanged += new EventHandler<ConnectionChangedEventArgs>(ConnectionChanged);
                cp.Cntr.OperatingModeChanged += _ctrl_OperatingModeChanged;
                cp.Cntr.StateChanged += _ctrl_StateChanged;
                cp.Cntr.Rapid.ExecutionStatusChanged += Rapid_ExecutionStatusChanged;
            }
            else
            {
                monitoringRunning = false;
                logger.Error(message: $"Problem with an ProcessMonitoring.");
            }
        }

        private void Rapid_ExecutionStatusChanged(object sender, ExecutionStatusChangedEventArgs e)
        {
            mm.CntExecutionStatus = "Rapid_ExecutionStatusChanged: \t" + e.Status.ToString();
            logger.Error("ExecutionStatusChanged: \t" + e.Status.ToString());
        }
        private void _ctrl_StateChanged(object sender, StateChangedEventArgs e)
        {
            mm.CntStateChanged = "StateChanged: \t\t" + e.NewState.ToString();
            logger.Error("Controller State Changed: \t" + e.NewState.ToString());
        }
        private void _ctrl_OperatingModeChanged(object sender, OperatingModeChangeEventArgs e)
        {
            mm.CntOperatingModeChanged = "OperatingModeChanged: \t" + e.NewMode.ToString();
            logger.Error("Controller Operating Mode Changed \t" + e.NewMode.ToString());
        }
        public void ConnectionChanged(object sender, EventArgs e)
        {
            if (cp.Cntr.Connected == true)
            {
                //btConnect.BackColor = Color.Green;
            }
            else
            {
                //btConnect.BackColor = Color.Red;
                //ControllerOnNetworkOutputOnMain();
            }
        }
        private void _errorEventHappened(object sender, MessageWrittenEventArgs e)
        {
            var tempOutput = e.Message;
            //if (cp.Cntr.OperatingMode.ToString() == "Auto")
            if ((e.Message.Type.ToString() == "Error") && (cp.Cntr.OperatingMode.ToString() == "Auto"))
            {
                //mm.Description = "Description";
                mm.ErrorCode = tempOutput.Number.ToString();
                mm.Title = tempOutput.Title.ToString();
                mm.ErrorType = tempOutput.Type.ToString();
                mm.ErrorTime = tempOutput.Timestamp.ToString();
                mm.BodyText = tempOutput.Body.ToString();
                tempOutput.Dispose();

                // formating a string from all HTML/XML tags

                //lpp.TextEditor(mm.BodyText);
                mm.XmlEditor(mm.BodyText);
                //mm.BodyText = lpp.TextEditor(mm.BodyText);
                // uncomment line below for sending emails
                mm.EmailSetup();
                logger.Error("Controller Error \t" + tempOutput.Title.ToString());
            }
        } // end of _errorEventHappened method


    } // end of EventHandlerPresenter class
}
