using Basket.API.Repositories;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

// Redis Configuration
builder.Services.AddStackExchangeRedisCache(options =>
    options.Configuration = configuration.GetValue<string>("CacheSettings:ConnectionString")
);

// General Configuration
builder.Services.AddScoped<IBasketRepository, BasketRepository>();

// Automapper Configuration
builder.Services.AddAutoMapper(typeof(Program));

// Masstransit-RabbitMQ Configuration
builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(configuration.GetValue<string>("EventBusSettings:HostAddress"));
    });
});

// No Need
//builder.Services.AddMassTransitHostedService();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
