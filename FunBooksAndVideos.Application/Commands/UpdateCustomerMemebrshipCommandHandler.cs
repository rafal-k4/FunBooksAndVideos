using FunBooksAndVideos.Domain.AggregateRoots.Customers;
using MediatR;

namespace FunBooksAndVideos.Application.Commands
{
    internal class UpdateCustomerMembershipCommandHandler : IRequestHandler<UpdateCustomerMembershipCommandRequest>
    {
        private ICustomerRepository _customerRepository;

        public UpdateCustomerMembershipCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task Handle(UpdateCustomerMembershipCommandRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAsync(request.CustomerId, cancellationToken);

            if(customer == null)
            {
                customer = new Customer(request.CustomerId);
                await _customerRepository.CreateAsync(customer, cancellationToken);
            }

            customer.UpdateMembership(request.MembershipName);

            await _customerRepository.SaveChangesAsync(cancellationToken);
        }
    }
}