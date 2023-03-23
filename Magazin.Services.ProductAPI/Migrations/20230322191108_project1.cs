using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazin.Services.ProductAPI.Migrations
{
    public partial class project1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategory = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IMG_URL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "IMG_URL", "Price", "ProductCategory", "ProductDescription", "ProductName" },
                values: new object[,]
                {
                    { 1, "https://dotnet6forfirstproj.blob.core.windows.net/magazinproject/chipso.png", 9500.0, 2, "LAY'S®— bu shunchaki chips emas!\\r\\n\\r\\nLAY'S® - bu mahsulotning yuqori sifati va mijozlar haqida g'amxo'rlikdir. Axir biz kartoshka chipslarini tayyorlash uchun eng yaxshi ingredientlar: yuqori PepsiCo standartlariga muvofiq yetishtirilgan rus kartoshkalari, tabiiy o'simlik moylari va xushbo’y ziravorlardan foydalanamiz.\\r\\n\\r\\nBiz kunni  yanada yorqinroq qilish uchun 10 yildan beri ilk bor mahsulot qadog’i dizaynini yangiladik!", "Lays Chips" },
                    { 2, "https://dotnet6forfirstproj.blob.core.windows.net/magazinproject/cola.png", 12000.0, 2, "“Coca‑Cola” kompaniyasi tarixidagi eng mashhur ichimlik 1886-yilning 8-may kuni Jorjiya shtatining Atlanta shahrida dorixonachi-shifokor Jon Pamberton tomonidan kashf etilgan. ", "Coca-Cola" },
                    { 3, "https://dotnet6forfirstproj.blob.core.windows.net/magazinproject/lipton.jpeg", 8000.0, 2, "Lipton — торговая марка чая, зарегистрированная Томасом Липтоном в Великобритании в 1890 году. В настоящее время принадлежит компании Unilever. Также до 1980-х в Великобритании существовала сеть супермаркетов Lipton, созданная в 1871 году тем же Томасом Липтоном.", "Lipton" },
                    { 4, "https://dotnet6forfirstproj.blob.core.windows.net/magazinproject/snickers.jpg", 8000.0, 1, "Батончик шоколадный \"Snickers\" 50 гр", "Snickers Buton" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
