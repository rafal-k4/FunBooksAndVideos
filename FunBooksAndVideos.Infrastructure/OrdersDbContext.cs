using FunBooksAndVideos.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Infrastructure;

public class OrdersDbContext : DbContext
{
    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseInMemoryDatabase(databaseName: "FunBooksAndVideos");
}
