using FunBooksAndVideos.Application;
using FunBooksAndVideos.Domain.AggregateRoots;
using FunBooksAndVideos.Infrastructure;
using FunBooksAndVideos.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(IMediatrMarker).Assembly));

builder.Services.AddScoped<OrdersDbContext>();
builder.Services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();

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
