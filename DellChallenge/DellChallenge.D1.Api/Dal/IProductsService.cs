using DellChallenge.D1.Api.Dto;
using System.Collections.Generic;

namespace DellChallenge.D1.Api.Dal
{
    public interface IProductsService
    {
        IEnumerable<ProductDto> GetAll();
        ProductDto GetProductById(string Id);
        ProductDto Add(NewProductDto newProduct);
        ProductDto Update(string id, ProductDto product);
        ProductDto Delete(string id);
    }
}
