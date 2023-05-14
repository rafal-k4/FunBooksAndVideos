namespace FunBooksAndVideos.Domain.AggregateRoots.Customer;

public interface ICustomerRepository
{
    Task<Customer?> GetAsync(int customerId, CancellationToken cancellationToken);
    Task CreateAsync(Customer customer, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
