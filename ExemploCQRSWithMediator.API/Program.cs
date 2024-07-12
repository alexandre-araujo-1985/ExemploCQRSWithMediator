using MediatR;
using ExemploCQRSWithMediator.Domain.Repositories;
using ExemploCQRSWithMediator.Domain.Entities;
using ExemploCQRSWithMediator.Domain.Handlers;
using ExemploCQRSWithMediator.Domain.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(Program));
builder.Services.AddTransient<IRequestHandler<ObterClientesQuery, IEnumerable<Cliente>>, ObterClientesHandler>();
builder.Services.AddSingleton<FakeDataStore>();

var app = builder.Build();

app.UseSwaggerUI();
app.UseSwagger();

app.MapControllers();

app.Run();