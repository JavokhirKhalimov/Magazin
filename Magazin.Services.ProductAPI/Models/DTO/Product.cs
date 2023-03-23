using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Magazin.Services.ProductAPI.Models.DTO
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Нельзя быть пустым")]
        public ProductCategoryEnum ProductCategory { get; set; }

        [Required(ErrorMessage = "Нельзя быть пустым"),
            MaxLength(30, ErrorMessage = "не менше 30 символов")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Нельзя быть пустым"),
            DisplayName("О продукте")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Нельзя быть пустым"),
            DisplayName("Цена")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Нельзя быть пустым"),
            DisplayName("Cсылка на изображение")]
        public string IMG_URL { get; set; }
    }
}
