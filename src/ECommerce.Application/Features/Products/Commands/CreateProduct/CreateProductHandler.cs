using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Domain.Entities;
using Mapster;
using MediatR;

namespace ECommerce.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {

        private readonly IProductRepository _repository;

        public CreateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var productEntity = request.Adapt<ProductEntity>();
            await _repository.AddAsync(productEntity);
            return new CreateProductResponse();
        }
    }
}
