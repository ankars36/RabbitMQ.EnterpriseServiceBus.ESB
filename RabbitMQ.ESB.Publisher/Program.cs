using MassTransit;
using RabbitMQ.ESB.Shared.Messages;

string rabbitMqUri = "amqps://joyrhfww:OrRKGmmKZv2_JULc8tyrHt6K0D3aaSpC@cow.rmq2.cloudamqp.com/joyrhfww";

string queueName = "example-queue";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory =>
{
    factory.Host(rabbitMqUri);
});

ISendEndpoint sendEndpoint = await bus.GetSendEndpoint(new($"{rabbitMqUri}/{queueName}"));

Console.Write("Gönderilecek mesaj:");
string mesaj = Console.ReadLine();

await sendEndpoint.Send<IMessage>(new ExampleMessage()
{
    Text = mesaj
});

Console.Read();