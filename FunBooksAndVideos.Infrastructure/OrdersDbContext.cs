using FunBooksAndVideos.Domain.AggregateRoots.Customer;
using FunBooksAndVideos.Domain.AggregateRoots.PurchaseOrder;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Infrastructure;

public class OrdersDbContext : DbContext
{
    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseInMemoryDatabase(databaseName: "FunBooksAndVideos");
}
