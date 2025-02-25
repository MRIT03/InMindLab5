using InMindLab5.Application.Commands;
using MailKit.Net.Smtp;
using MediatR;
using MimeKit;

namespace InMindLab5.Infrastructure.BackgroundJobs;

public class BackgroundJobService : IBackgroundJobService
{
    private readonly ILogger<BackgroundJobService> _logger;
    private readonly IMediator _mediator;

    public BackgroundJobService(ILogger<BackgroundJobService> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public async Task RunHourlyJob()
    {
        _logger.LogInformation("Hourly job executed at: {Time}", DateTime.UtcNow);
        // Business logic for hourly job
        var result = await _mediator.Send(new UpdateGPACommand());
        _logger.LogInformation("Finished executing the GPA calculator task with the following result: {result}", result.IsSuccess ? result.Value : result.Error);
        _logger.LogInformation("Hourly job finished executing at: {Time}", DateTime.UtcNow);
    }

   
    public async Task SendDailyEmails()
    {
        _logger.LogInformation("Daily mailing job executed at: {Time}", DateTime.UtcNow);
        var email = new MimeMessage();
         email.From.Add(new MailboxAddress("My Website", "info@MyWebsiteDomainName.com"));
         email.To.Add(new MailboxAddress("", "recipient@example.com"));
         email.Cc.Add(new MailboxAddress("", "MyEmailID@gmail.com"));  // CC recipient
         email.Subject = "Test Email from .NET";
         email.Body = new TextPart("html")
         {
             Text = "<h1>Hello!</h1><p>This is a test email from .NET using MailKit.</p>"
         };
         using var smtp = new SmtpClient();
         try
         {
             await smtp.ConnectAsync("mail.MyWebsiteDomainName.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
             await smtp.AuthenticateAsync("info@MyWebsiteDomainName.com", "myIDPassword");
             await smtp.SendAsync(email);
             await smtp.DisconnectAsync(true);
             Console.WriteLine("Email sent successfully!");
         }
         catch (Exception ex)
         {
             Console.WriteLine($"Error sending email: {ex.Message}");
         }
    }
}