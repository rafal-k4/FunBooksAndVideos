using FunBooksAndVideos.Application;
using FunBooksAndVideos.Domain.AggregateRoots.Customers;
using FunBooksAndVideos.Domain.AggregateRoots.PurchaseOrder;
using FunBooksAndVideos.Infrastructure;
using FunBooksAndVideos.Infrastructure.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(IMediatrMarker).Assembly));

builder.Services.AddScoped<OrdersDbContext>();
builder.Services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddDbContext<OrdersDbContext>(options =>
{
    options.UseInMemoryDatabase("InMemory-TestDB");
});

builder.Services.AddMassTransit(x =>
{
    //x.SetKebabCaseEndpointNameFormatter();
    x.UsingInMemory((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
