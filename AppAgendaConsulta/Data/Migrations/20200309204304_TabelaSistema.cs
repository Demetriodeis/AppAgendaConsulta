using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppAgendaConsulta.Data.Migrations
{
    public partial class TabelaSistema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    CRM = table.Column<string>(maxLength: 10, nullable: false),
                    Especialidade = table.Column<string>(maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsultaMedicas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MedicoId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(maxLength: 1000, nullable: false),
                    DataConsulta = table.Column<DateTime>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultaMedicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultaMedicas_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultaMedicas_MedicoId",
                table: "ConsultaMedicas",
                column: "MedicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultaMedicas");

            migrationBuilder.DropTable(
                name: "Medicos");
        }
    }
}
