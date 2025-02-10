using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogoAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulateCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Categories (Name, ImageUrl) VALUES ('Bebidas', 'bebidas.jpg')");
            mb.Sql("INSERT INTO Categories (Name, ImageUrl) VALUES ('Lanches', 'lanches.jpg')");
            mb.Sql(
                "INSERT INTO Categories (Name, ImageUrl) VALUES ('Sobremesas', 'Sobremesas.jpg')"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.DropTable("Categories");
        }
    }
}
