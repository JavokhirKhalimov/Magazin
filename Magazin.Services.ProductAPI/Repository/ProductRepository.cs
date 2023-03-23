using AutoMapper;
using Magazin.Services.ProductAPI.DbContexts;
using Magazin.Services.ProductAPI.Models;
using Magazin.Services.ProductAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Magazin.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDTO> CreateUpdateProductAsync(ProductDTO productDTO)
        {
            Product product= _mapper.Map<ProductDTO, Product>(productDTO);
            if(product.ProductId>0)
            {
                _db.Products.Update(product);
            }
            else
            {
               await _db.Products.AddAsync(product);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDTO>(product);
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            try
            {
                Product product = await _db.Products.FirstOrDefaultAsync(u => u.ProductId == productId); 
                if(product is null) return false;
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            List<Product> products = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProductByIdAsync(int productId)
        {
            Product products = await _db.Products.Where(x=>x.ProductId==productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDTO>(products);
        }
    }
}
