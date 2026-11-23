using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBoardMini.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCompaniesAndCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            // Създаваме обща категория за старите стажове.
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "General" });

            // Запазваме старите организации като компании.
            migrationBuilder.Sql(@"
        SET IDENTITY_INSERT Companies ON;

        INSERT INTO Companies (Id, Name, Address, Website)
        SELECT
            ROW_NUMBER() OVER (ORDER BY Organization),
            Organization,
            N'',
            N''
        FROM (SELECT DISTINCT Organization FROM Internships) AS OldCompanies;

        SET IDENTITY_INSERT Companies OFF;
    ");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Internships",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Internships",
                type: "int",
                nullable: true);

            // Свързваме старите стажове с новите компании.
            migrationBuilder.Sql(@"
        UPDATE Internships
        SET CompanyId = Companies.Id
        FROM Internships
        INNER JOIN Companies
            ON Internships.Organization = Companies.Name;

        UPDATE Internships
        SET CategoryId = 1;
    ");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Internships",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Internships",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Internships",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Internships",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Internships",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.DropColumn(
                name: "Organization",
                table: "Internships");

            migrationBuilder.CreateIndex(
                name: "IX_Internships_CategoryId",
                table: "Internships",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Internships_CompanyId",
                table: "Internships",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Internships_Categories_CategoryId",
                table: "Internships",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Internships_Companies_CompanyId",
                table: "Internships",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Internships_Categories_CategoryId",
                table: "Internships");

            migrationBuilder.DropForeignKey(
                name: "FK_Internships_Companies_CompanyId",
                table: "Internships");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Internships_CategoryId",
                table: "Internships");

            migrationBuilder.DropIndex(
                name: "IX_Internships_CompanyId",
                table: "Internships");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Internships");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Internships");

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Internships",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Internships",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Internships",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Organization",
                table: "Internships",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
