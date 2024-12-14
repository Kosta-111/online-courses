using Core.Configuration;
using Core.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace Core.Services;

public class SendMailService(SmtpConfiguration config) : ISendMailService
{
    public async Task SendEmailAsync(string toEmail, string toName, string subject, string message)
    {
        using var emailMessage = new MimeMessage();

        emailMessage.From.Add(new MailboxAddress(config.Name, config.Email));
        emailMessage.To.Add(new MailboxAddress(toName, toEmail));
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart(TextFormat.Html)
        {
            Text = message
        };

        using var client = new SmtpClient();
        await client.ConnectAsync(config.Host, config.Port, false);
        await client.AuthenticateAsync(config.Email, config.Password);
        await client.SendAsync(emailMessage);
        await client.DisconnectAsync(true);
    }
}
