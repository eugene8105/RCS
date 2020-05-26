using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Office.Interop.Outlook;
using NLog;
using RCS_Main_APP.Interfaces;

namespace RCS_Main_APP.Models
{
    class MonitoringModel : IMonitoringModel, IXMLControllerLogTags, IXmlTags
    {
        Logger logger = null;
        SettingsConfigureModel scm = new SettingsConfigureModel();
        /// <summary>
        /// SmtpClient - it's a class - Simple Mail Transfer Protocol (SMTP) class
        /// </summary>
        SmtpClient client;
        
        public string ErrorCode { get; set; }
        public string Title { get; set; }
        public string ErrorType { get; set; }
        public string ErrorTime { get; set; }
        public string BodyText { get; set; }
        public string Message { get; set; }
        public string StreetName { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        public string Recipients { get; set; }
        public bool EmailSuccess { get; set; } = false;
        public string PartName { get; set; }
        public string CntExecutionStatus { get; set; }
        public string CntStateChanged { get; set; }
        public string CntOperatingModeChanged { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        // From IXmlTags
        public string TagTitle { get; set; }
        public string TagDescription { get; set; }
        public string TagConsequences { get; set; }
        public string TagCauses { get; set; }
        public string[] TagActions { get; set; }
        public string Description { get; set; }

        const string hostName = "smtp.gmail.com"; // smtp.gmail.com", port 587
        const int port = 587;  // 587


        public MonitoringModel()
        {
            logger = NLog.Web.NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
        }

        string emailSubscribersString;
        public bool EmailSetup()
        {
            foreach (var i in scm.cd)
            {
                emailSubscribersString = i.EmailSubscribers[0];
            }
            try
            {
                if (emailSubscribersString != "")
                {
                    GmailMail();
                    //OutlookMail();
                }
                else
                {
                    logger.Info(message: $"Check if RCS configuration file have email subscribers - Notifications Email Subscribers.");
                }

            }//end of try block
            catch (System.Exception ex)
            {
                logger.Error(message: $"Problem with an email setup. {ex.Message}");
                EmailSuccess = false;
            }//end of catch
            return EmailSuccess;
        }// end of EmailSetup method
        public void GmailMail()
        {
            Message = $"{ErrorTime} \n{ErrorCode}: {TagTitle}\n\n{TagDescription} \n{EmailBody}";

            MailMessage msg = new MailMessage();
            foreach (var item in scm.cd)
            {
                EmailAddress = item.RCSEmailAddress;
                Password = item.RCSEmailPass;
                for (int i = 0; i < item.EmailSubscribers.Length; i++)
                {
                    msg.To.Add(new MailAddress(item.EmailSubscribers[i]));
                }
            }
            msg.Subject = $"{StreetName} - {ErrorTime} - {Title}";
            msg.From = new MailAddress(EmailAddress);
            msg.Body = Message;
            
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = port;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential(EmailAddress, Password);
            smtp.Credentials = nc;
            smtp.Send(msg);

            EmailSuccess = true;
        }
        //List<IXmlTags> tags;
        public void XmlEditor(string xmlText)
        {
            //tags = new List<IXmlTags>();

            var doc = new XmlDocument();
            doc.LoadXml(xmlText);

            //tags.Add(new XmlTags
            //{
            TagTitle = doc.GetElementsByTagName("Title")[0].InnerText;
            TagDescription = doc.GetElementsByTagName("Description")[0].InnerText;
            TagConsequences = doc.GetElementsByTagName("Consequences")[0].InnerText;
            TagCauses = doc.GetElementsByTagName("Causes")[0].InnerText;
            TagActions = doc.GetElementsByTagName("Actions")[0].InnerText.Split(')');
            //});
            //ListScaner();
        }
        public void OutlookMail()
        {
            client = new SmtpClient(hostName, port);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(EmailAddress, Password);
            EmailSubject = $"{StreetName} - {ErrorTime} - {TagTitle}";
            Message = $"{ErrorTime} \n{ErrorCode}: {TagTitle}\n\n{TagDescription} \n{EmailBody}";
            // Add a recipient.
            foreach (var item in scm.cd)
            {
                EmailAddress = item.RCSEmailPass;
                Password = item.RCSEmailPass;
                for (int i = 0; i < item.EmailSubscribers.Length; i++)
                {
                    if (Recipients != null)
                    {
                        Recipients += ";";
                    }
                    Recipients += $"{item.EmailSubscribers[i]}";
                }
                
                StreetName = item.LocationName;
            }
            client.Send(EmailAddress, Recipients, EmailSubject, Message);
            EmailSuccess = true;
        }
    } // end of MonitoringModel class
}
