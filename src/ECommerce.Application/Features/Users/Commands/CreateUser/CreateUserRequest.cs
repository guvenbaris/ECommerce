using MediatR;

namespace ECommerce.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }
}
