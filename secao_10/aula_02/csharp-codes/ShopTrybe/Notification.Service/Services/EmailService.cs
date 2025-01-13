using System.Net;
using System.Net.Mail;
using System.Text;
using Notification.Service.Models;

namespace Notification.Service.Services;

public class EmailService : MailMessage
{
  private static readonly string EMAIL_HOST = Environment.GetEnvironmentVariable("EMAIL_HOST");
  private static readonly string EMAIL_FROM = Environment.GetEnvironmentVariable("EMAIL_FROM");
  private static readonly string EMAIL_PASSWORD = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");
  private static readonly int SMTP_PORT = Convert.ToInt32(Environment.GetEnvironmentVariable("EMAIL_PORT"));
  public static void Send(Message message)
  {
    try
    {
      using (var msgMail = new MailMessage())
      {
        msgMail.From = new MailAddress(EMAIL_FROM);
        if (!string.IsNullOrEmpty(message.MailTo))
        {
          msgMail.To.Add(new MailAddress(message.MailTo));
        }
        else
        {
          throw new ArgumentNullException(nameof(message.MailTo), "MailTo cannot be null or empty.");
        }

        msgMail.Subject = message.Title;
        msgMail.Body = message.Text;
        msgMail.BodyEncoding = Encoding.UTF8;
        msgMail.IsBodyHtml = true;
        msgMail.Priority = MailPriority.Normal;

        using (var smtpClient = new SmtpClient())
        {
          smtpClient.Host = EMAIL_HOST;
          smtpClient.Port = SMTP_PORT;
          smtpClient.EnableSsl = true;
          smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
          smtpClient.Credentials = new NetworkCredential(EMAIL_FROM, EMAIL_PASSWORD);
          smtpClient.UseDefaultCredentials = false;

          smtpClient.Send(msgMail);
        }
      }
    }
    catch (SmtpFailedRecipientException ex)
    {
      Console.WriteLine("Message SMTP Fail : {0} " + ex.Message);

      return;

    }
    catch (SmtpException ex)
    {
      Console.WriteLine("Message SMPT Fail : {0} " + ex.Message);
      return;
    }
    catch (Exception ex)
    {
      Console.WriteLine("Message Exception : {0} " + ex.Message);
      return;
    }
  }
}