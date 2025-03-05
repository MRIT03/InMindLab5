using InMindLab5.Application.ViewModels;


namespace InMindLab5.Application.Services;

public interface IMessagePublisher
{
    void PublishCourseCreated(CourseCreatedEvent courseCreatedEvent);
}