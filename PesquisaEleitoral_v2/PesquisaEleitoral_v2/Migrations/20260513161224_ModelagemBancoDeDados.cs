using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PesquisaEleitoral_v2.Migrations
{
    /// <inheritdoc />
    public partial class ModelagemBancoDeDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    CandidatoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Partido = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.CandidatoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Eleitores",
                columns: table => new
                {
                    EleitorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Renda = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    Regiao = table.Column<int>(type: "int", nullable: false),
                    Escolaridade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eleitores", x => x.EleitorId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pesquisas",
                columns: table => new
                {
                    PesquisaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Localidade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cargo = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pesquisas", x => x.PesquisaId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PesquisaCandidatos",
                columns: table => new
                {
                    PesquisaCandidatoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PesquisaId = table.Column<int>(type: "int", nullable: false),
                    CandidatoId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "IntencoesDeVoto",
                columns: table => new
                {
                    IntencaoDeVotoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EleitorId = table.Column<int>(type: "int", nullable: false),
                    PesquisaCandidatoId = table.Column<int>(type: "int", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntencoesDeVoto", x => x.IntencaoDeVotoId);
                    table.ForeignKey(
                        name: "FK_IntencoesDeVoto_Eleitores_EleitorId",
                        column: x => x.EleitorId,
                        principalTable: "Eleitores",
                        principalColumn: "EleitorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IntencoesDeVoto_PesquisaCandidatos_PesquisaCandidatoId",
                        column: x => x.PesquisaCandidatoId,
                        principalTable: "PesquisaCandidatos",
                        principalColumn: "PesquisaCandidatoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_IntencoesDeVoto_EleitorId",
                table: "IntencoesDeVoto",
                column: "EleitorId");

            migrationBuilder.CreateIndex(
                name: "IX_IntencoesDeVoto_PesquisaCandidatoId",
                table: "IntencoesDeVoto",
                column: "PesquisaCandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_PesquisaCandidatos_CandidatoId",
                table: "PesquisaCandidatos",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_PesquisaCandidatos_PesquisaId",
                table: "PesquisaCandidatos",
                column: "PesquisaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntencoesDeVoto");

            migrationBuilder.DropTable(
                name: "Eleitores");

            migrationBuilder.DropTable(
                name: "PesquisaCandidatos");

            migrationBuilder.DropTable(
                name: "Candidatos");

            migrationBuilder.DropTable(
                name: "Pesquisas");
        }
    }
}
