using MessageAPI.Models;
using Confluent.Kafka;
using MessageAPI.Interfaces;
using MessageAPI.Concretes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IKafkaClient, KafkaClient>();
builder.Services.AddSingleton<IOrderService, OrderService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ClientPermission", policy =>
    {
        policy.AllowAnyHeader().WithOrigins("http://localhost:3000").AllowCredentials();
    });
});

builder.Services.Configure<KafkaSettings>(builder.Configuration.GetSection(KafkaSettings.Section));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("ClientPermission");

app.MapControllers();

app.Run();
