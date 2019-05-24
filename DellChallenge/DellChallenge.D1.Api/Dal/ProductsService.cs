using System.Collections.Generic;
using System.Linq;
using DellChallenge.D1.Api.Dto;

namespace DellChallenge.D1.Api.Dal
{
    public class ProductsService : IProductsService
    {
        private readonly ProductsContext _context;

        public ProductsService(ProductsContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return _context.Products.Select(p => MapToDto(p));
        }

        public ProductDto GetProductById(string Id)
        {
            Product product = _context.Products.Where(p => p.Id.Equals(Id)).FirstOrDefault();
            if (product != null)
            {
                return MapToDto(product);
            }
            else
                return null;
        }

        public ProductDto Add(NewProductDto newProduct)
        {
            var product = MapToData(newProduct);
            _context.Products.Add(product);
            _context.SaveChanges();
            var addedDto = MapToDto(product);
            return addedDto;
        }

        public ProductDto Update(string Id, ProductDto productWithUpdates)
        {
            Product product = _context.Products.Where(p => p.Id.Equals(Id)).FirstOrDefault();
            if (product != null)
            {
                product.Name = productWithUpdates.Name;
                product.Category = productWithUpdates.Category;
                _context.SaveChanges();
                return MapToDto(product);
            }
            else
                return null;
        }

        public ProductDto Delete(string Id)
        {
            Product product = _context.Products.Where(p => p.Id.Equals(Id)).FirstOrDefault();
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return MapToDto(product);
            }
            else
                return null;
        }

        private Product MapToData(NewProductDto newProduct)
        {
            return new Product
            {
                Category = newProduct.Category,
                Name = newProduct.Name
            };
        }

        private ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category
            };
        }
    }
}
