using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Utf8Json;

class Program
{
    public static async Task Main()
    {
        var configuration = new EndpointConfiguration("Utf8JsonSerializerSample");
        configuration.UseSerialization<Utf8JsonSerializer>();
        configuration.UseTransport<LearningTransport>();
        var endpoint = await Endpoint.Start(configuration);
        var message = new MyMessage
        {
            DateSend = DateTime.Now,
        };
        await endpoint.SendLocal(message);
        Console.WriteLine("\r\nPress any key to stop program\r\n");
        Console.Read();
        await endpoint.Stop();
    }
}