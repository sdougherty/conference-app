using ConferenceData.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.Configuration;

namespace ConferenceService.Services
{
    public class RegistrationService
    {
        public static void SendNotification(User user)
        {
            var port = Convert.ToInt32(WebConfigurationManager.AppSettings["SmtpPort"]);
            var server = WebConfigurationManager.AppSettings["SmtpServer"];
            var username = WebConfigurationManager.AppSettings["SmtpUsername"];
            var password = WebConfigurationManager.AppSettings["SmtpPassword"];
            var sender = WebConfigurationManager.AppSettings["RegistrationSender"];

            MailMessage mailMsg = new MailMessage();

            // To
            mailMsg.To.Add(new MailAddress(user.EmailAddress, String.Format("{0} {1}", user.FirstName, user.LastName)));

            // From
            mailMsg.From = new MailAddress(sender);

            // Subject and multipart/alternative body message.
            mailMsg.Subject = "2014 Guardian Life's First Annual Software Developer Conference";
            string text = "Thank you for registering for the two-day Software Developer Conference being held Wednesday, May 7th and Thursday, May 8th at 7 Hanover Sq, NYC on the 15th floor, from 8:30 to 5pm. Double-click on the attached file to add this event to your calendar. \r\n You can follow and comment on this event in Yammer. \r\n Please do not reply to this message, this mail box is not monitored. If you wish to contact the organizers use the Contact Us form at http:////glic-dev-conf.azurewebsites.net \r\n ";
            string html = @"<p>Thank you for registering for the two-day Software Developer Conference being held Wednesday, May 7th and Thursday, May 8th at 7 Hanover Sq, NYC on the 15th floor, from 8:30 to 5pm. Double-click on the attached file to add this event to your calendar.</p><p>You can follow and comment on this event in <a href='https://www.yammer.com/glic.com/#/threads/inGroup?type=in_group&feedId=4219962'>Yammer</a></p><p>Please do not reply to this message, this mail box is not monitored. If you wish to contact the organizers use the Contact Us form at <a href='http://glic-dev-conf.azurewebsites.net'>http://glic-dev-conf.azurewebsites.net</a></p>";
            mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
            mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

            // Attach iCalendar invitation file.
            string icsPath = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data", "invite.ics");
            var attachment = new Attachment(icsPath, new ContentType(MediaTypeNames.Text.Plain));
            mailMsg.Attachments.Add(attachment);

            // Init SmtpClient and send
            SmtpClient smtpClient = new SmtpClient(server, port);
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(username, password);
            smtpClient.Credentials = credentials;

            smtpClient.Send(mailMsg);
        }
    }
}