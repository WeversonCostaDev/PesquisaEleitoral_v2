using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PesquisaEleitoral_v2.Migrations
{
    /// <inheritdoc />
    public partial class RemodelandoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IntencoesDeVoto_PesquisaCandidatos_PesquisaCandidatoId",
                table: "IntencoesDeVoto");

            migrationBuilder.DropTable(
                name: "PesquisaCandidatos");

            migrationBuilder.RenameColumn(
                name: "PesquisaCandidatoId",
                table: "IntencoesDeVoto",
                newName: "PesquisaId");

            migrationBuilder.RenameIndex(
                name: "IX_IntencoesDeVoto_PesquisaCandidatoId",
                table: "IntencoesDeVoto",
                newName: "IX_IntencoesDeVoto_PesquisaId");

            migrationBuilder.UpdateData(
                table: "Pesquisas",
                keyColumn: "Descricao",
                keyValue: null,
                column: "Descricao",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Pesquisas",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CandidatoID",
                table: "IntencoesDeVoto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CandidatoPesquisa",
                columns: table => new
                {
                    CandidatosCandidatoId = table.Column<int>(type: "int", nullable: false),
                    PesquisaCandidatosPesquisaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatoPesquisa", x => new { x.CandidatosCandidatoId, x.PesquisaCandidatosPesquisaId });
                    table.ForeignKey(
                        name: "FK_CandidatoPesquisa_Candidatos_CandidatosCandidatoId",
                        column: x => x.CandidatosCandidatoId,
                        principalTable: "Candidatos",
                        principalColumn: "CandidatoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatoPesquisa_Pesquisas_PesquisaCandidatosPesquisaId",
                        column: x => x.PesquisaCandidatosPesquisaId,
                        principalTable: "Pesquisas",
                        principalColumn: "PesquisaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_IntencoesDeVoto_CandidatoID",
                table: "IntencoesDeVoto",
                column: "CandidatoID");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatoPesquisa_PesquisaCandidatosPesquisaId",
                table: "CandidatoPesquisa",
                column: "PesquisaCandidatosPesquisaId");

            migrationBuilder.AddForeignKey(
                name: "FK_IntencoesDeVoto_Candidatos_CandidatoID",
                table: "IntencoesDeVoto",
                column: "CandidatoID",
                principalTable: "Candidatos",
                principalColumn: "CandidatoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IntencoesDeVoto_Pesquisas_PesquisaId",
                table: "IntencoesDeVoto",
                column: "PesquisaId",
                principalTable: "Pesquisas",
                principalColumn: "PesquisaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IntencoesDeVoto_Candidatos_CandidatoID",
                table: "IntencoesDeVoto");

            migrationBuilder.DropForeignKey(
                name: "FK_IntencoesDeVoto_Pesquisas_PesquisaId",
                table: "IntencoesDeVoto");

            migrationBuilder.DropTable(
                name: "CandidatoPesquisa");

            migrationBuilder.DropIndex(
                name: "IX_IntencoesDeVoto_CandidatoID",
                table: "IntencoesDeVoto");

            migrationBuilder.DropColumn(
                name: "CandidatoID",
                table: "IntencoesDeVoto");

            migrationBuilder.RenameColumn(
                name: "PesquisaId",
                table: "IntencoesDeVoto",
                newName: "PesquisaCandidatoId");

            migrationBuilder.RenameIndex(
                name: "IX_IntencoesDeVoto_PesquisaId",
                table: "IntencoesDeVoto",
                newName: "IX_IntencoesDeVoto_PesquisaCandidatoId");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Pesquisas",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PesquisaCandidatos",
                columns: table => new
                {
                    PesquisaCandidatoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CandidatoId = table.Column<int>(type: "int", nullable: false),
                    PesquisaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PesquisaCandidatos", x => x.PesquisaCandidatoId);
                    table.ForeignKey(
                        name: "FK_PesquisaCandidatos_Candidatos_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidatos",
                        principalColumn: "CandidatoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PesquisaCandidatos_Pesquisas_PesquisaId",
                        column: x => x.PesquisaId,
                        principalTable: "Pesquisas",
                        principalColumn: "PesquisaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PesquisaCandidatos_CandidatoId",
                table: "PesquisaCandidatos",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_PesquisaCandidatos_PesquisaId",
                table: "PesquisaCandidatos",
                column: "PesquisaId");

            migrationBuilder.AddForeignKey(
                name: "FK_IntencoesDeVoto_PesquisaCandidatos_PesquisaCandidatoId",
                table: "IntencoesDeVoto",
                column: "PesquisaCandidatoId",
                principalTable: "PesquisaCandidatos",
                principalColumn: "PesquisaCandidatoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
