namespace Core.Interfaces;

public interface ISendMailService
{
    Task SendEmailAsync(string toEmail, string toName, string subject, string message);
}
