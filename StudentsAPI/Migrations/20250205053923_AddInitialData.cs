using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudetnsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Estudiantes",
                columns: new[] { "Id", "Email", "Nombre" },
                values: new object[,]
                {
                    { 1, "juan.perez@example.com", "Juan Pérez" },
                    { 2, "maria.gomez@example.com", "María Gómez" },
                    { 3, "carlos.lopez@example.com", "Carlos López" }
                });

            migrationBuilder.InsertData(
                table: "Profesores",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Profesor A" },
                    { 2, "Profesor B" },
                    { 3, "Profesor C" },
                    { 4, "Profesor D" },
                    { 5, "Profesor E" }
                });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Id", "Creditos", "Nombre", "ProfesorId" },
                values: new object[,]
                {
                    { 1, 3, "Matemáticas", 1 },
                    { 2, 3, "Física", 1 },
                    { 3, 3, "Química", 2 },
                    { 4, 3, "Biología", 2 },
                    { 5, 3, "Historia", 3 },
                    { 6, 3, "Geografía", 3 },
                    { 7, 3, "Inglés", 4 },
                    { 8, 3, "Francés", 4 },
                    { 9, 3, "Arte", 5 },
                    { 10, 3, "Música", 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estudiantes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Estudiantes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Estudiantes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Materias",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Profesores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Profesores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Profesores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Profesores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Profesores",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
