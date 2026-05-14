using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PesquisaEleitoral_v2.Migrations
{
    /// <inheritdoc />
    public partial class AjusteAtributosIntencaoDeVoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IntencoesDeVoto_Candidatos_CandidatoID",
                table: "IntencoesDeVoto");

            migrationBuilder.RenameColumn(
                name: "CandidatoID",
                table: "IntencoesDeVoto",
                newName: "CandidatoId");

            migrationBuilder.RenameIndex(
                name: "IX_IntencoesDeVoto_CandidatoID",
                table: "IntencoesDeVoto",
                newName: "IX_IntencoesDeVoto_CandidatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_IntencoesDeVoto_Candidatos_CandidatoId",
                table: "IntencoesDeVoto",
                column: "CandidatoId",
                principalTable: "Candidatos",
                principalColumn: "CandidatoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IntencoesDeVoto_Candidatos_CandidatoId",
                table: "IntencoesDeVoto");

            migrationBuilder.RenameColumn(
                name: "CandidatoId",
                table: "IntencoesDeVoto",
                newName: "CandidatoID");

            migrationBuilder.RenameIndex(
                name: "IX_IntencoesDeVoto_CandidatoId",
                table: "IntencoesDeVoto",
                newName: "IX_IntencoesDeVoto_CandidatoID");

            migrationBuilder.AddForeignKey(
                name: "FK_IntencoesDeVoto_Candidatos_CandidatoID",
                table: "IntencoesDeVoto",
                column: "CandidatoID",
                principalTable: "Candidatos",
                principalColumn: "CandidatoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
