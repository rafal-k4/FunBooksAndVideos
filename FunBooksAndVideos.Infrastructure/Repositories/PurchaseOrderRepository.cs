﻿using FunBooksAndVideos.Domain.AggregateRoots.PurchaseOrder;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Infrastructure.Repositories;

public class PurchaseOrderRepository : IPurchaseOrderRepository
{
    private readonly OrdersDbContext _dbContext;

    public PurchaseOrderRepository(OrdersDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(PurchaseOrder purchaseOrder, CancellationToken cancellationToken)
    {
        await _dbContext.PurchaseOrders.AddAsync(purchaseOrder, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<PurchaseOrder?> GetAsync(int id, CancellationToken cancellationToken)
    {
        _dbContext.PurchaseOrders.Include(x => x.ItemLines);
        return await _dbContext.PurchaseOrders.FindAsync(id, cancellationToken);
    }
}
