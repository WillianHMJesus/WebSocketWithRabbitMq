using WebSocketWithRabbitMq.API.Common;
using WebSocketWithRabbitMq.API.Models;
using WebSocketWithRabbitMq.API.MessageBrokers;
using WebSocketWithRabbitMq.API.MessageBrokers.Contracts;
using WebSocketWithRabbitMq.API.Hubs;

var PolicyToHubs = "_policyToHubs";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMassTransit(builder.Configuration);
builder.Services.AddSignalR();
builder.Services.AddDependencyInjection();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: PolicyToHubs,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .WithMethods("GET", "POST")
                .AllowCredentials();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/balance", async (UseBalanceRequest request, IMessageBrokerService service, CancellationToken cancellationToken) =>
{
    await service.SendMessage(new UseBalance(request), cancellationToken);

    Results.Accepted();

}).WithName("UseBalance");

app.MapHub<UseBalanceHub>("/useBalanceHub");

app.UseCors(PolicyToHubs);

app.Run();