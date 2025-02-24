using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace todoapi.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[,]
                {
                    { 1, "Blue", "Travail" },
                    { 2, "Green", "Personnel" },
                    { 3, "Red", "Urgent" }
                });

            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id", "Deadline", "Description", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aller au supermarché", "Acheter du lait", 0 },
                    { 2, new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Étudier l'API Web", "Réviser .NET", 1 }
                });

            migrationBuilder.InsertData(
                table: "SubTodos",
                columns: new[] { "Id", "Deadline", "Description", "Name", "ParentTodoId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Créer le wireframe", "Faire une maquette", 2, 0 },
                    { 2, new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Développer les composants de base", "Créer composants Vue", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "TodoTags",
                columns: new[] { "TagId", "TodoId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubTodos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubTodos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TodoTags",
                keyColumns: new[] { "TagId", "TodoId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "TodoTags",
                keyColumns: new[] { "TagId", "TodoId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
