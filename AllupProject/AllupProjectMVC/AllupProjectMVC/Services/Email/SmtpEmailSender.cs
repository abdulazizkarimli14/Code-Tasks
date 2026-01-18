using System.Net;
using System.Net.Mail;

namespace AllupProjectMVC.Services.Email;

public class SmtpEmailSender : IEmailSender
{
    private readonly IConfiguration _configuration;

    public SmtpEmailSender(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string htmlMessage)
    {
        var smtpSettings = _configuration.GetSection("Smtp");

        var client = new SmtpClient
        {
            Host = smtpSettings["Host"],
            Port = int.Parse(smtpSettings["Port"]),
            EnableSsl = true,
            Credentials = new NetworkCredential(
                smtpSettings["Username"],
                smtpSettings["Password"]
            )
        };

        var mail = new MailMessage
        {
            From = new MailAddress(
                smtpSettings["FromEmail"],
                smtpSettings["FromName"]
            ),
            Subject = subject,
            Body = htmlMessage,
            IsBodyHtml = true
        };

        mail.To.Add(toEmail);

        await client.SendMailAsync(mail);
    }
}
