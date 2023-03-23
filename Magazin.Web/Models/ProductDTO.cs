using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Magazin.Web.Models
{
    public class ProductDTO
    {

        public int ProductId { get; set; }
        [Required(ErrorMessage = "Нельзя быть пустым"), DisplayName("Категория продукта:")]
        public int ProductCategory { get; set; } = 1;
        [Required(ErrorMessage = "Нельзя быть пустым"),
            MaxLength(30, ErrorMessage = "не менше 30 символов"), DisplayName("Название продукта:")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Нельзя быть пустым"),
            DisplayName("О продукте:")]
        public string ProductDescription { get; set; }
        [Required(ErrorMessage = "Нельзя быть пустым"),
            DisplayName("Цена:")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Нельзя быть пустым"),
            DisplayName("Cсылка на изображение:")]
        public string IMG_URL { get; set; }
    }
}
