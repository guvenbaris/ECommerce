using MediatR;

namespace ECommerce.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductRequest : IRequest<CreateProductResponse>
    {
        public string ProductName { get; set; } = string.Empty;
        public long StockQuantity { get; set; }
        public decimal Price { get; set; }
    }
}
