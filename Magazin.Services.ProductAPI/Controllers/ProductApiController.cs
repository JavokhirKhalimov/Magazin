using Magazin.Services.ProductAPI.Models;
using Magazin.Services.ProductAPI.Models.DTO;
using Magazin.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Magazin.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProductApiController : ControllerBase
    {
        protected ResponseDTO _responseDTO;
        private IProductRepository _productRepository;
        public ProductApiController(IProductRepository productRepository)
        {
            this._responseDTO= new ResponseDTO();
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<object> GetAsync()
        {
            try
            {
                IEnumerable<ProductDTO> productDTOs= await _productRepository.GetAllProductsAsync();
                _responseDTO.ResultRequest=productDTOs;
            }
            catch(Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMessages= new List<string> { ex.ToString()};
            }
            return _responseDTO;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<object> GetAsync(int id)
        {
            try
            {
                ProductDTO productDTO = await _productRepository.GetProductByIdAsync(id);
                _responseDTO.ResultRequest = productDTO;
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _responseDTO;
        }

        [HttpPost]
        
        public async Task<object> PostAsync([FromBody] ProductDTO productDTO)
        {
            try
            {
                ProductDTO productDTOobject = await _productRepository.CreateUpdateProductAsync(productDTO);
                _responseDTO.ResultRequest = productDTOobject;
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _responseDTO;
        }

        [HttpPut]
        public async Task<object> UpdateAsync([FromBody] ProductDTO productDTO)
        {
            try
            {
                ProductDTO productDTOobject = await _productRepository.CreateUpdateProductAsync(productDTO);
                _responseDTO.ResultRequest = productDTOobject;
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _responseDTO;
        }

        [HttpDelete]
        public async Task<object> DeleteAsync(int Id)
        {
            try
            {
                bool IsSuccess = await _productRepository.DeleteProductAsync(Id);
                _responseDTO.ResultRequest = IsSuccess;
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _responseDTO;
        }
    }
}
