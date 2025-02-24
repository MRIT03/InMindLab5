using InMindLab5.Application.Commands;
using MediatR;

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

    public async void RunHourlyJob()
    {
        _logger.LogInformation("Hourly job executed at: {Time}", DateTime.UtcNow);
        // Business logic for hourly job
        var result = await _mediator.Send(new UpdateGPACommand());
        _logger.LogInformation("Finished executing the GPA calculator task with the following result: {result}", result.IsSuccess ? result.Value : result.Error);
        _logger.LogInformation("Hourly job finished executing at: {Time}", DateTime.UtcNow);
    }

   
    public void SendDailyEmails()
    {
        _logger.LogInformation("Daily mailing job executed at: {Time}", DateTime.UtcNow);
        // Business logic for email job
    }
}