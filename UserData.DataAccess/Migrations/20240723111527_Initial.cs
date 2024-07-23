using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserData.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DisplayName", "Email", "UserName" },
                values: new object[,]
                {
                    { new Guid("30b01a1d-2163-4655-87e1-30315b5b00a4"), "Ivan Ivanov", "i.ivanov@example.com", "ivivan" },
                    { new Guid("3f987a11-15c2-4b75-8ff3-6955be5ba91a"), "Georgi Dimitrov", "g.dimitrov@example.com", "gdimit" },
                    { new Guid("52026104-2418-42c3-8891-28c75abb4a2f"), "Kaloqn Kostadinov", "k.kostadinov@example.com", "kakost" },
                    { new Guid("62b0cfc8-722c-40c0-ab08-991b61d78d57"), "Katerina Ivanova", "k.ivanova@example.com", "kivanova" },
                    { new Guid("87c84637-7e69-4c0a-94bd-7e09921fddaf"), "Ivaila Gerdjikova", "i.gerdjikova@example.com", "igerd" },
                    { new Guid("f2f55f46-f9d8-4087-9b14-e39e7495a8d3"), "Ivelina Georgieva", "i.georgieva@example.com", "igeor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
