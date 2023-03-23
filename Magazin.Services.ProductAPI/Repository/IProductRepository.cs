using Magazin.Services.ProductAPI.Models;

namespace Magazin.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(int productId);
        Task<ProductDTO> CreateUpdateProductAsync(ProductDTO productDTO);
       // Task<ProductDTO> UpdateProductAsync(ProductDTO productDTO);
        Task<bool> DeleteProductAsync(int productId);
    }
}
