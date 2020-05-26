using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCS_Main_APP.Interfaces;
using SlackBotMessages;
using SlackBotMessages.Models;

namespace RCS_Main_APP.Models
{
    class SupportRequestModel : SettingsConfigureModel, ISupportRequesModel
    {
        public string WebHookR4Support { get; set; }

        public string WebHookRobotSupport { get; set; }
        Message message { get; set; }
        SbmClient clientRobotSupport;
        SbmClient clientR4Support;
        public void SetupClients()
        {
            clientRobotSupport = new SbmClient(WebHookRobotSupport);
            clientR4Support = new SbmClient(WebHookR4Support);
        }
        /// <summary>
        /// request for robotic support function
        /// </summary>
        public void RoboticSupportRequest(string robSupportText, string webHookRobotSup)
        {
            message = new Message
            {
                Text = robSupportText
            };
            WebHookRobotSupport = webHookRobotSup;
            SetupClients();
            clientRobotSupport.Send(message);
        } // end of RoboticSupportReques method

        /// <summary>
        /// request for R4 support function
        /// </summary>
        public void R4Request(string r4SupportText, string webHookR4Sup)
        {
            message = new Message
            {
                Text = r4SupportText
            };
            WebHookR4Support = webHookR4Sup;
            SetupClients();
            clientR4Support.Send(message);
        } // end of R4Request method

    } // end of SupportRequestModel class
}
