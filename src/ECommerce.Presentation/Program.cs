using ECommerce.Application;
using ECommerce.Infrastructure;
using Rebus.Config;
using Rebus.Routing.TypeBased;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ApplicationServiceContainer();
builder.Services.InfrastractureServiceContainer(builder.Configuration);
builder.Services.AddRebus(rebus =>
    rebus.Routing(r => r.TypeBased().MapAssemblyOf<ApplicationAssembly>("ecommerce-queue"))
        .Transport(t => t.UseRabbitMq(builder.Configuration.GetConnectionString("MessageBroker"), "ecommerce-queue"))
        .Sagas(s => 
            s.StoreInPostgres(builder.Configuration.GetConnectionString("Database"),
            "sagas",
            "saga_indexes")));

builder.Services.AutoRegisterHandlersFromAssemblyOf<ApplicationAssembly>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
