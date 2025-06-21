using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagement.Migrations
{
    /// <inheritdoc />
    public partial class StudentTableSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StudentResults",
                columns: new[] { "Id", "CourseTitle", "Status", "StudentName", "TotalMarks" },
                values: new object[,]
                {
                    { 1, "Mathematics", 0, "Alice Rahman", 45 },
                    { 2, "Physics", 1, "Tanvir Ahmed", 75 },
                    { 3, "English", 2, "Nusrat Jahan", 85 },
                    { 4, "Chemistry", 1, "Rafiul Islam", 68 },
                    { 5, "Biology", 2, "Mim Chowdhury", 88 },
                    { 6, "History", 0, "Mehedi Hasan", 33 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentResults",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudentResults",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudentResults",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudentResults",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StudentResults",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StudentResults",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
