using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarteiraDoInvestidor.Repository.Migrations
{
    /// <inheritdoc />
    public partial class altertableXPO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtivosCarteiras");

            migrationBuilder.AddColumn<Guid>(
                name: "CarteirasId",
                table: "Ativos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ativos_CarteirasId",
                table: "Ativos",
                column: "CarteirasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ativos_Carteiras_CarteirasId",
                table: "Ativos",
                column: "CarteirasId",
                principalTable: "Carteiras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ativos_Carteiras_CarteirasId",
                table: "Ativos");

            migrationBuilder.DropIndex(
                name: "IX_Ativos_CarteirasId",
                table: "Ativos");

            migrationBuilder.DropColumn(
                name: "CarteirasId",
                table: "Ativos");

            migrationBuilder.CreateTable(
                name: "AtivosCarteiras",
                columns: table => new
                {
                    CarteirasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ListaDeAtivosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtivosCarteiras", x => new { x.CarteirasId, x.ListaDeAtivosId });
                    table.ForeignKey(
                        name: "FK_AtivosCarteiras_Ativos_ListaDeAtivosId",
                        column: x => x.ListaDeAtivosId,
                        principalTable: "Ativos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtivosCarteiras_Carteiras_CarteirasId",
                        column: x => x.CarteirasId,
                        principalTable: "Carteiras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtivosCarteiras_ListaDeAtivosId",
                table: "AtivosCarteiras",
                column: "ListaDeAtivosId");
        }
    }
}
