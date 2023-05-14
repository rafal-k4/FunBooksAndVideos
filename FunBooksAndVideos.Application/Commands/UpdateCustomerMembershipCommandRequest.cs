using FunBooksAndVideos.Domain.SharedKernel;
using MediatR;

namespace FunBooksAndVideos.Application.Commands;

public class UpdateCustomerMembershipCommandRequest : IRequest
{
    public int CustomerId { get; set; }
    public string MembershipName { get; set; } = null!;
}