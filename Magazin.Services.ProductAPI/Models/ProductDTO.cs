using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Magazin.Services.ProductAPI.Models
{
    public class ProductDTO
    {

        public int ProductId { get; set; }

        public int ProductCategory { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public double Price { get; set; }

        public string IMG_URL { get; set; }
    }
}
