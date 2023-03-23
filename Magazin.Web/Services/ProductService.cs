using Magazin.Web.Models;
using Magazin.Web.Services.IServices;

namespace Magazin.Web.Services
{
    public class ProductService : BaseService, IProductService
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public ProductService(IHttpClientFactory httpClientFactory):base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> CreateProductAsync<T>(ProductDTO productDTO)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = CD.ApiType.POST,
                Data = productDTO,
                Url = CD.ProductAPIBase + "/api/products/",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = CD.ApiType.DELETE,
                Url = CD.ProductAPIBase + "/api/products/"+id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = CD.ApiType.GET,
                Url = CD.ProductAPIBase + "/api/products/",
                AccessToken = ""
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = CD.ApiType.GET,
                Url = CD.ProductAPIBase + "/api/products/"+id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDTO productDTO)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = CD.ApiType.PUT,
                Url = CD.ProductAPIBase + "/api/products/",
                AccessToken = ""
            });
        }
    }
}
