using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class Inizialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("2d6649b6-9390-4436-a89e-a53a2897e23f"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("68443b04-cceb-4f41-84f1-5c518bff503e"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("a0cd0ba0-57c2-46fd-b384-a4b84160cb1b"));

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Cost", "Description", "Link", "Name" },
                values: new object[,]
                {
                    { new Guid("0e53d752-8ea0-423e-b12f-322112afa32c"), 10000m, "Генеральная уборка вашей квартиры или дома, цена зависит от площади", "/image/image3.jpeg", "Генеральная уборка" },
                    { new Guid("66119057-a9e9-406e-b576-51513a0fb783"), 4000m, "Поддерживающая уборка вашей квартиры или дома, цена зависит от площади", "/image/image1.jpg", "Поддерживающая уборка" },
                    { new Guid("99d6eec7-f843-4ceb-80db-515852a4ce54"), 5000m, "Стандартная уборка вашей квартиры или дома, цена зависит от площади", "/image/image2.jpg", "Стандартная уборка" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("0e53d752-8ea0-423e-b12f-322112afa32c"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("66119057-a9e9-406e-b576-51513a0fb783"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("99d6eec7-f843-4ceb-80db-515852a4ce54"));

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Cost", "Description", "Link", "Name" },
                values: new object[,]
                {
                    { new Guid("2d6649b6-9390-4436-a89e-a53a2897e23f"), 4000m, "Поддерживающая уборка вашей квартиры или дома, цена зависит от площади", "/image1.jpg", "Поддерживающая уборка" },
                    { new Guid("68443b04-cceb-4f41-84f1-5c518bff503e"), 10000m, "Генеральная уборка вашей квартиры или дома, цена зависит от площади", "/image3.jpg", "Генеральная уборка" },
                    { new Guid("a0cd0ba0-57c2-46fd-b384-a4b84160cb1b"), 5000m, "Стандартная уборка вашей квартиры или дома, цена зависит от площади", "/image2.jpg", "Стандартная уборка" }
                });
        }
    }
}
