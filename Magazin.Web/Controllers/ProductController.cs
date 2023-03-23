using Magazin.Web.Models;
using Magazin.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;

namespace Magazin.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDTO> listofProductDtobasedProductModel = new();
            var response = await _productService.GetAllProductsAsync<ResponseDTO>();
            if (response is not null && response.IsSuccess)
            {
                listofProductDtobasedProductModel = JsonConvert.DeserializeObject<List<ProductDTO>>
                    (Convert.ToString(response.ResultRequest));
            }
            return View(listofProductDtobasedProductModel);

        }


        public async Task<IActionResult> ProductCreate()
        {
       
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductDTO model)
        {
            
            
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProductAsync<ResponseDTO>(model);
                if (response is not null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            
            return View(model);

        }

        public async Task<IActionResult> ProductEdit(int productId)
        {
            var response = await _productService.GetProductByIdAsync<ResponseDTO>(productId);
            if (response is not null && response.IsSuccess)
            {
                ProductDTO model=JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(response.ResultRequest));
                return View(model);
            }

            return NotFound();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEdit(ProductDTO model)
        {


            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProductAsync<ResponseDTO>(model);
                if (response is not null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }

            return View(model);

        }
    }
}
