using Distribt.Services.Subscriptions.Dtos;

WebApplication app = DefaultDistribtWebApplication.Create(args, webappBuilder =>
{
    //configurar apigateway. En este caso yard APIGateway
    webappBuilder.Services.AddReverseProxy()
        .LoadFromConfig(webappBuilder.Configuration.GetSection("ReverseProxy"));
    webappBuilder.Services.AddServiceBusIntegrationPublisher(webappBuilder.Configuration);
});

app.MapGet("/", () => "Hello World!");

app.MapPost("/subscribe", async (SubscriptionDto subscriptionDto) =>
{
    //generar un message tipo "productor consumidor"
    IIntegrationMessagePublisher publisher = app.Services.GetRequiredService<IIntegrationMessagePublisher>();
    await publisher.Publish(subscriptionDto, routingKey: "subscription");
});


//configurar ReverseProxy de apigateway.
app.MapReverseProxy();


DefaultDistribtWebApplication.Run(app);