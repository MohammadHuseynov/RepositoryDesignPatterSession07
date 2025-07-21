using RepositoryDesignPatternSession07.ApplicationServices.Dtos;
using RepositoryDesignPatternSession07.ApplicationServices.Services.Contracts;
using RepositoryDesignPatternSession07.Models.DomainModels.ProductAggregates;
using RepositoryDesignPatternSession07.Models.Services.Contracts;

namespace RepositoryDesignPatternSession07.ApplicationServices.Services
{
    public class ProductApplicationService : IProductApplicationService
    {
        private readonly IProductRepository _productRepository;

        public ProductApplicationService(IProductRepository productRepository)
        {
            _productRepository = productRepository; 
        }

        public void PostProductDto(PostProductDto postProductDto)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Title = postProductDto.Title,
                UnitPrice = postProductDto.UnitPrice,
                Quantity = postProductDto.Quantity
            };

            _productRepository.Add(product);
            _productRepository.SaveChanges();
        }

        public GetProductDto GetById(Guid id)
        {
            var product = _productRepository.GetById(id);
            if (product == null) return null;

            return new GetProductDto
            {
                Id = product.Id,
                Title = product.Title,
                UnitPrice = product.UnitPrice,
                Quantity = product.Quantity
            };
        }

        public List<GetProductDto> GetAll()
        {
            var products = _productRepository.GetAll();
            var productDtos = new List<GetProductDto>();

            foreach (var product in products)
            {
                productDtos.Add(new GetProductDto
                {
                    Id = product.Id,
                    Title = product.Title,
                    UnitPrice = product.UnitPrice,
                    Quantity = product.Quantity
                });
            }

            return productDtos;
        }

        public void UpdateProductDto(UpdateProductDto updateProductDto)
        {
            var product = _productRepository.GetById(updateProductDto.Id);
            if (product == null) return;

            product.Title = updateProductDto.Title;
            product.UnitPrice = updateProductDto.UnitPrice;
            product.Quantity = updateProductDto.Quantity;

            _productRepository.Update(product);
            _productRepository.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var product = _productRepository.GetById(id);
            if (product == null) return;

            _productRepository.Delete(product);
            _productRepository.SaveChanges();
        }
    }
}
