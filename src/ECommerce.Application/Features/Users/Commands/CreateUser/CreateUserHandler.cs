using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Domain.Entities;
using Mapster;
using MediatR;

namespace ECommerce.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var userEntity = request.Adapt<UserEntity>();

            await _userRepository.AddAsync(userEntity);

            return new CreateUserResponse();
        }
    }

}
