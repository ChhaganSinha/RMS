using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace RMS.Server.Services;

public class EmailSender : IEmailSender
{
    private readonly ILogger _logger;
    
    public EmailSender(ILogger<EmailSender> logger)
    {
        _logger = logger;
    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        MailMessage message = new MailMessage();
        SmtpClient smtp = new SmtpClient();
        message.From = new MailAddress("hr@credentinfotech.com");
        //message.From = new MailAddress("cs.credent@gmail.com");
        message.To.Add(new MailAddress(email));
        message.Subject = subject;
        message.IsBodyHtml = true;
        message.Body = htmlMessage;
        smtp.Port = 587; 

        //smtp.Host = "smtp.gmail.com"; // Gmail SMTP server
        smtp.Host = "smtp.office365.com";

        smtp.EnableSsl = true;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new NetworkCredential("hr@credentinfotech.com", "Non84273");
        //smtp.Credentials = new NetworkCredential("cs.credent@gmail.com", "Cs@7803063110");
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        try
        {
            await smtp.SendMailAsync(message);
        }
        catch (Exception ex)
        {
            throw;
        }

    }

}
