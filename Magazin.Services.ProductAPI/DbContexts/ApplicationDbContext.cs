using Magazin.Services.ProductAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Magazin.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            :base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId= 1,
                ProductCategory=(ProductCategoryEnum)2,//Man ProductCategory tipini int dan enum ga utkazdim lekin migration qilganim yoq. Enum uchun yangi  Product.CategoryEnum.cs class i yaratilingan! 
                ProductName="Lays Chips",
                ProductDescription= @$"LAY'S®— bu shunchaki chips emas!\r\n\r\nLAY'S® - bu mahsulotning yuqori sifati va mijozlar haqida g'amxo'rlikdir. Axir biz kartoshka chipslarini tayyorlash uchun eng yaxshi ingredientlar: yuqori PepsiCo standartlariga muvofiq yetishtirilgan rus kartoshkalari, tabiiy o'simlik moylari va xushbo’y ziravorlardan foydalanamiz.\r\n\r\nBiz kunni  yanada yorqinroq qilish uchun 10 yildan beri ilk bor mahsulot qadog’i dizaynini yangiladik!",
                Price=9500,
                IMG_URL= "https://dotnet6forfirstproj.blob.core.windows.net/magazinproject/chipso.png"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                ProductCategory = (ProductCategoryEnum)2,
                ProductName = "Coca-Cola",
                ProductDescription = "“Coca‑Cola” kompaniyasi tarixidagi eng mashhur ichimlik 1886-yilning 8-may kuni Jorjiya shtatining Atlanta shahrida dorixonachi-shifokor Jon Pamberton tomonidan kashf etilgan. ",
                Price = 12000,
                IMG_URL = "https://dotnet6forfirstproj.blob.core.windows.net/magazinproject/cola.png"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                ProductCategory = (ProductCategoryEnum)2,
                ProductName = "Lipton",
                ProductDescription= "Lipton — торговая марка чая, зарегистрированная Томасом Липтоном в Великобритании в 1890 году. В настоящее время принадлежит компании Unilever. Также до 1980-х в Великобритании существовала сеть супермаркетов Lipton, созданная в 1871 году тем же Томасом Липтоном.",
                Price = 8000,
                IMG_URL = "https://dotnet6forfirstproj.blob.core.windows.net/magazinproject/lipton.jpeg"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                ProductCategory = (ProductCategoryEnum)1,
                ProductName = "Snickers Buton",
                ProductDescription= "Батончик шоколадный \"Snickers\" 50 гр",
                Price = 8000,
                IMG_URL = "https://dotnet6forfirstproj.blob.core.windows.net/magazinproject/snickers.jpg"
            });
        }
    }
}
