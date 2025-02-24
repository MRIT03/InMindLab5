namespace InMindLab5.Infrastructure.BackgroundJobs;

public interface IBackgroundJobService
{
    public void RunHourlyJob();
    public void SendDailyEmails();
}