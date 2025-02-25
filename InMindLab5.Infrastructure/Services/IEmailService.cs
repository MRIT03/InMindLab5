namespace InMindLab5.Infrastructure.Services;

public interface IEmailService
{
    Task SendEmailAsync(string to, string subject, string body);
}