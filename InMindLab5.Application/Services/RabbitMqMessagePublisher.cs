using System.Text;
using InMindLab5.Application.ViewModels;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace InMindLab5.Application.Services;

public class RabbitMqMessagePublisher : IMessagePublisher
{
    private readonly string _hostname;
    private readonly string _exchangeName;
    private readonly ConnectionFactory _connectionFactory;

    public RabbitMqMessagePublisher(string hostname, string exchangeName)
    {
        _hostname = hostname;
        _exchangeName = exchangeName;
        _connectionFactory = new ConnectionFactory { HostName = _hostname };
    }

    public async void PublishCourseCreated(CourseCreatedEvent courseCreatedEvent)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();

        // Declare the exchange
        await channel.ExchangeDeclareAsync(exchange: _exchangeName, type: ExchangeType.Fanout, durable: false, autoDelete: false, arguments: null);

        // Serialize event to JSON
        var messageBody = JsonConvert.SerializeObject(courseCreatedEvent);
        var body = Encoding.UTF8.GetBytes(messageBody);

        // Publish the message
        await channel.BasicPublishAsync(
            exchange: _exchangeName,
            routingKey: "reee", // empty string for fanout exchange
            body: body
        );
    
        Console.WriteLine(" [x] Sent {0}", messageBody);
    }
}