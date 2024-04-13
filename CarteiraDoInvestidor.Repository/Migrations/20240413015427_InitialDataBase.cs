using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarteiraDoInvestidor.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ativos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Papel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantidade = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    PrecoMedio = table.Column<double>(type: "float", nullable: false),
                    Corretora = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TaxaDeCorretagem = table.Column<double>(type: "float", maxLength: 50, nullable: false),
                    DataDaCompra = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    LadoDaOperacao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ativos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plano",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Valor_Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plano", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioMapping",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DtNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioMapping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assinatura",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DtAtivacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assinatura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assinatura_Plano_PlanoId",
                        column: x => x.PlanoId,
                        principalTable: "Plano",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Assinatura_UsuarioMapping_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "UsuarioMapping",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cartao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Limite = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Validade = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    CVV = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cartao_UsuarioMapping_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "UsuarioMapping",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Carteiras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeCarteira = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carteiras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carteiras_UsuarioMapping_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "UsuarioMapping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notificacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DtNotificacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mensagem = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UsuarioDestinoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioRemetenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TipoNotificacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notificacao_UsuarioMapping_UsuarioDestinoId",
                        column: x => x.UsuarioDestinoId,
                        principalTable: "UsuarioMapping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notificacao_UsuarioMapping_UsuarioRemetenteId",
                        column: x => x.UsuarioRemetenteId,
                        principalTable: "UsuarioMapping",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DtTransacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorTransacao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    MerchantNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CartaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacao_Cartao_CartaoId",
                        column: x => x.CartaoId,
                        principalTable: "Cartao",
                        principalColumn: "Id");
                });

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
                name: "IX_Assinatura_PlanoId",
                table: "Assinatura",
                column: "PlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_Assinatura_UsuarioId",
                table: "Assinatura",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AtivosCarteiras_ListaDeAtivosId",
                table: "AtivosCarteiras",
                column: "ListaDeAtivosId");

            migrationBuilder.CreateIndex(
                name: "IX_Cartao_UsuarioId",
                table: "Cartao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Carteiras_UsuarioId",
                table: "Carteiras",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacao_UsuarioDestinoId",
                table: "Notificacao",
                column: "UsuarioDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacao_UsuarioRemetenteId",
                table: "Notificacao",
                column: "UsuarioRemetenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_CartaoId",
                table: "Transacao",
                column: "CartaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assinatura");

            migrationBuilder.DropTable(
                name: "AtivosCarteiras");

            migrationBuilder.DropTable(
                name: "Notificacao");

            migrationBuilder.DropTable(
                name: "Transacao");

            migrationBuilder.DropTable(
                name: "Plano");

            migrationBuilder.DropTable(
                name: "Ativos");

            migrationBuilder.DropTable(
                name: "Carteiras");

            migrationBuilder.DropTable(
                name: "Cartao");

            migrationBuilder.DropTable(
                name: "UsuarioMapping");
        }
    }
}
