using MediatR;
using ExemploCQRSWithMediator.Domain.Repositories;
using ExemploCQRSWithMediator.Domain.Entities;
using ExemploCQRSWithMediator.Domain.Handlers;
using ExemploCQRSWithMediator.Domain.Queries;
using ExemploCQRSWithMediator.Domain.Commands;
using ExemploCQRSWithMediator.Domain.Notifications;
using ExemploCQRSWithMediator.Domain.Behaviors;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddTransient<IRequestHandler<ObterClientesQuery, IEnumerable<Cliente>>, ObterClientesHandler>();
builder.Services.AddTransient<IRequestHandler<ObterClientePorIdQuery, Cliente>, ObterClientePorIdHandler>();
builder.Services.AddTransient<IRequestHandler<AdicionarClienteCommand, Cliente>, AdicionarProdutoHandler>();
builder.Services.AddTransient<INotificationHandler<ClienteAddedNotification>, EmailHandler>();
builder.Services.AddSingleton<FakeDataStore>();
builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

var app = builder.Build();

app.UseSwaggerUI();
app.UseSwagger();

app.MapControllers();

app.Run();