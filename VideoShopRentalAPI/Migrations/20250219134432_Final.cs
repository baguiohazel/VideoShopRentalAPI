using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoShopRentalAPI.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalDetails_Movies_MovieId",
                table: "RentalDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalDetails_RentalHeaders_RentalHeadersId",
                table: "RentalDetails");

            migrationBuilder.DropTable(
                name: "RentalHeaders");

            migrationBuilder.RenameColumn(
                name: "RentalHeadersId",
                table: "RentalDetails",
                newName: "RentalId");

            migrationBuilder.RenameIndex(
                name: "IX_RentalDetails_RentalHeadersId",
                table: "RentalDetails",
                newName: "IX_RentalDetails_RentalId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "Sex");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "RentalDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "RentalDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Rented");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Movies",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateRelease",
                table: "Movies",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "Customers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    RentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rentals_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalDetails_CustomerId",
                table: "RentalDetails",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CustomerId",
                table: "Rentals",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_MovieId",
                table: "Rentals",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalDetails_Customers_CustomerId",
                table: "RentalDetails",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalDetails_Movies_MovieId",
                table: "RentalDetails",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalDetails_Rentals_RentalId",
                table: "RentalDetails",
                column: "RentalId",
                principalTable: "Rentals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalDetails_Customers_CustomerId",
                table: "RentalDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalDetails_Movies_MovieId",
                table: "RentalDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalDetails_Rentals_RentalId",
                table: "RentalDetails");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_RentalDetails_CustomerId",
                table: "RentalDetails");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "RentalDetails");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "RentalDetails");

            migrationBuilder.DropColumn(
                name: "DateRelease",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "RentalId",
                table: "RentalDetails",
                newName: "RentalHeadersId");

            migrationBuilder.RenameIndex(
                name: "IX_RentalDetails_RentalId",
                table: "RentalDetails",
                newName: "IX_RentalDetails_RentalHeadersId");

            migrationBuilder.RenameColumn(
                name: "Sex",
                table: "Customers",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Movies",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateTable(
                name: "RentalHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    RentalDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ReturnDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentalHeaders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalHeaders_CustomerId",
                table: "RentalHeaders",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalDetails_Movies_MovieId",
                table: "RentalDetails",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalDetails_RentalHeaders_RentalHeadersId",
                table: "RentalDetails",
                column: "RentalHeadersId",
                principalTable: "RentalHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
