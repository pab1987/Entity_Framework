using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectef.Migrations
{
    /// <inheritdoc />
    public partial class InicialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("66899106-603d-447c-99ce-8fcaa3239802"), null, "Actividades personales", 50 },
                    { new Guid("66899106-603d-447c-99ce-8fcaa32398e7"), null, "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "tareaId", "CategoriaId", "Descripcion", "EstadoTarea", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("66899106-603d-447c-99ce-8fcaa3239810"), new Guid("66899106-603d-447c-99ce-8fcaa32398e7"), null, true, new DateTime(2023, 10, 3, 13, 34, 57, 418, DateTimeKind.Local).AddTicks(3020), 1, "Pago servicios publicos" },
                    { new Guid("66899106-603d-447c-99ce-8fcaa3239820"), new Guid("66899106-603d-447c-99ce-8fcaa3239802"), null, false, new DateTime(2023, 10, 3, 13, 34, 57, 418, DateTimeKind.Local).AddTicks(3050), 0, "Hacer los deberes de la casa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "tareaId",
                keyValue: new Guid("66899106-603d-447c-99ce-8fcaa3239810"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "tareaId",
                keyValue: new Guid("66899106-603d-447c-99ce-8fcaa3239820"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("66899106-603d-447c-99ce-8fcaa3239802"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("66899106-603d-447c-99ce-8fcaa32398e7"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
