using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IgnitechSkolica.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "FirstName", "LastName", "TeacherCode" },
                values: new object[,]
                {
                    { 1, "Ivan", "Horvat", "TE00001" },
                    { 2, "Veldin", "Karic", "TE00002" },
                    { 3, "Danijel", "Poldrugac", "TE00003" },
                    { 4, "Jasmin", "Agic", "TE00004" },
                    { 5, "Eduardo", "Da Silva", "TE00005" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "LastName", "StudentCode", "TeacherId" },
                values: new object[,]
                {
                    { 1, "Tadej", "Pogacar", "ST00001", 1 },
                    { 2, "Ante", "Budimir", "ST00002", 2 },
                    { 3, "Ivan", "Ljubicic", "ST00003", 3 },
                    { 4, "Mario", "Ancic", "ST00004", 4 },
                    { 5, "Novak", "Djokovic", "ST00005", 5 },
                    { 6, "Ivica", "Zubac", "ST00006", 5 },
                    { 7, "Andrej", "Kramaric", "ST00007", 3 },
                    { 8, "Donna", "Vekic", "ST00008", 3 },
                    { 9, "Petra", "Martic", "ST00009", 2 },
                    { 10, "Zulejka", "Stefanini Tucan", "ST000010", 3 },
                    { 11, "Maca", "Maradona", "ST000011", 4 }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "StudentId", "TeacherId" },
                values: new object[,]
                {
                    { 1, "Matematika 1", 1, 1 },
                    { 2, "Matematika 3", 2, 1 },
                    { 3, "Organizacija", 1, 2 },
                    { 4, "Engleski 1", 1, 3 },
                    { 5, "Engleski 3", 3, 3 },
                    { 6, "Baze podataka 1", 3, 4 },
                    { 7, "Programiranje 1", 4, 4 },
                    { 8, "Poslovno odlucivanje", 5, 5 },
                    { 9, "Komunikacija 1", 6, 5 },
                    { 10, "Komunikacija 3", 5, 5 },
                    { 11, "Osnove ekonomije 1", 7, 2 },
                    { 12, "Osnove ekonomije 3", 8, 2 },
                    { 13, "Poslovna ekonomija 1", 8, 2 },
                    { 14, "Poslovna ekonomija 3", 9, 2 },
                    { 15, "Financijska matematika 1", 10, 1 },
                    { 16, "Financijska matematika 3", 11, 1 }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CreatedOn", "SubjectId", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(228), 1, 95 },
                    { 2, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(272), 2, 88 },
                    { 3, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(274), 3, 70 },
                    { 4, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(276), 3, 51 },
                    { 5, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(278), 4, 55 },
                    { 6, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(280), 5, 44 },
                    { 7, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(282), 6, 33 },
                    { 8, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(284), 6, 85 },
                    { 9, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(285), 7, 90 },
                    { 10, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(287), 7, 91 },
                    { 11, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(289), 7, 99 },
                    { 12, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(291), 8, 74 },
                    { 13, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(292), 9, 66 },
                    { 14, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(294), 9, 65 },
                    { 15, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(296), 10, 67 },
                    { 16, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(298), 10, 56 },
                    { 17, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(300), 11, 50 },
                    { 18, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(301), 11, 51 },
                    { 19, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(303), 11, 52 },
                    { 20, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(305), 11, 73 },
                    { 21, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(307), 12, 81 },
                    { 22, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(308), 12, 82 },
                    { 23, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(310), 13, 83 },
                    { 24, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(312), 13, 89 },
                    { 25, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(314), 14, 91 },
                    { 26, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(315), 15, 77 },
                    { 27, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(317), 16, 75 },
                    { 28, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(319), 16, 59 },
                    { 29, new DateTime(2024, 7, 23, 11, 32, 45, 502, DateTimeKind.Local).AddTicks(321), 16, 71 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
