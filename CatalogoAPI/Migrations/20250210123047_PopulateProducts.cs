using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogoAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulateProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql(
                "INSERT INTO Products (Name, Description, Price, Stock, CreatedAt, ImageUrl, CategoryId) VALUES ('Coca-Cola', 'Refrigerante de Lata', 5.75, 50, now(), 'coca-cola.jpg', 1)"
            );
            mb.Sql(
                "INSERT INTO Products (Name, Description, Price, Stock, CreatedAt, ImageUrl, CategoryId) VALUES ('Sanduíche de frango', 'Delicioso sanduíche de frango', 11.99, 20, now(), 'sanduiche.jpg', 2)"
            );

            mb.Sql(
                "INSERT INTO Products (Name, Description, Price, Stock, CreatedAt, ImageUrl, CategoryId) VALUES ('Brownie', 'Brownie quente com chocolate', 7.99, 15, now(), 'brownie.jpg', 3)"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.DropTable("Products");
        }
    }
}
