using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultaAlertaDengue.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v0001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DadosDengue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SemanaEpidemiologica = table.Column<int>(type: "INT", nullable: false),
                    CasosEstimados = table.Column<double>(type: "DOUBLE", nullable: false),
                    CasosNotificados = table.Column<int>(type: "INT", nullable: false),
                    NivelAlerta = table.Column<int>(type: "INT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosDengue", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosDengue");
        }
    }
}
