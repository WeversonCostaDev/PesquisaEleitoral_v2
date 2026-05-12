using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PesquisaEleitoral_v2.Migrations
{
    /// <inheritdoc />
    public partial class AdcaoDeLocalidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Localidade",
                table: "Pesquisas",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localidade",
                table: "Pesquisas");
        }
    }
}
