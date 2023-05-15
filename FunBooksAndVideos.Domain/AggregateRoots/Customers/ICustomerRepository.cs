namespace FunBooksAndVideos.Domain.AggregateRoots.Customers;

public interface ICustomerRepository
{
    Task<Customer?> GetAsync(int customerId, CancellationToken cancellationToken);
    Task CreateAsync(Customer customer, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
