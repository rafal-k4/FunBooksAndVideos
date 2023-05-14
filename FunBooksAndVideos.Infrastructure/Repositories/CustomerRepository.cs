using FunBooksAndVideos.Domain.AggregateRoots.Customer;

namespace FunBooksAndVideos.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly OrdersDbContext _ordersDbContext;

    public CustomerRepository(OrdersDbContext ordersDbContext)
    {
        _ordersDbContext = ordersDbContext;
    }

    public async Task<Customer?> GetAsync(int customerId, CancellationToken cancellationToken)
    {
        return await _ordersDbContext.Customers.FindAsync(customerId, cancellationToken);
    }

    public async Task CreateAsync(Customer customer, CancellationToken cancellationToken)
    {
        await _ordersDbContext.Customers.AddAsync(customer, cancellationToken);
        await _ordersDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _ordersDbContext.SaveChangesAsync(cancellationToken);
    }
}
