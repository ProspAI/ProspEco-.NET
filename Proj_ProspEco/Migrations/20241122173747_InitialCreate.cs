using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proj_ProspEco.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_BandeiraTarifaria",
                columns: table => new
                {
                    Id_bandeira = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_bandeira = table.Column<string>(type: "varchar2(50)", maxLength: 50, nullable: false),
                    dt_vigencia = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_BandeiraTarifaria", x => x.Id_bandeira);
                });

            migrationBuilder.CreateTable(
                name: "TB_Usuario",
                columns: table => new
                {
                    Id_usuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_nome = table.Column<string>(type: "varchar2(100)", maxLength: 100, nullable: false),
                    ds_email = table.Column<string>(type: "varchar2(50)", maxLength: 50, nullable: false),
                    ds_senha = table.Column<string>(type: "varchar2(50)", maxLength: 50, nullable: false),
                    PontuacaoEconom = table.Column<decimal>(type: "NUMBER(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Usuario", x => x.Id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "TB_Aparelho",
                columns: table => new
                {
                    Id_aparelho = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_nome = table.Column<string>(type: "varchar2(50)", maxLength: 50, nullable: false),
                    Id_usuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Aparelho", x => x.Id_aparelho);
                    table.ForeignKey(
                        name: "FK_TB_Aparelho_TB_Usuario_Id_usuario",
                        column: x => x.Id_usuario,
                        principalTable: "TB_Usuario",
                        principalColumn: "Id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_Conquista",
                columns: table => new
                {
                    Id_conquista = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_conquista = table.Column<string>(type: "varchar2(100)", maxLength: 100, nullable: false),
                    Id_usuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Conquista", x => x.Id_conquista);
                    table.ForeignKey(
                        name: "FK_TB_Conquista_TB_Usuario_Id_usuario",
                        column: x => x.Id_usuario,
                        principalTable: "TB_Usuario",
                        principalColumn: "Id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_Meta",
                columns: table => new
                {
                    Id_meta = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_meta = table.Column<string>(type: "varchar2(100)", maxLength: 100, nullable: false),
                    Id_usuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Meta", x => x.Id_meta);
                    table.ForeignKey(
                        name: "FK_TB_Meta_TB_Usuario_Id_usuario",
                        column: x => x.Id_usuario,
                        principalTable: "TB_Usuario",
                        principalColumn: "Id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_Notificacao",
                columns: table => new
                {
                    Id_notificacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_notificacao = table.Column<string>(type: "varchar2(255)", maxLength: 255, nullable: false),
                    Id_usuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Notificacao", x => x.Id_notificacao);
                    table.ForeignKey(
                        name: "FK_TB_Notificacao_TB_Usuario_Id_usuario",
                        column: x => x.Id_usuario,
                        principalTable: "TB_Usuario",
                        principalColumn: "Id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_Recomendacao",
                columns: table => new
                {
                    Id_recom = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ds_recomendacao = table.Column<string>(type: "varchar2(255)", maxLength: 255, nullable: false),
                    Id_usuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Recomendacao", x => x.Id_recom);
                    table.ForeignKey(
                        name: "FK_TB_Recomendacao_TB_Usuario_Id_usuario",
                        column: x => x.Id_usuario,
                        principalTable: "TB_Usuario",
                        principalColumn: "Id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_RegistroConsumo",
                columns: table => new
                {
                    Id_registro = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nr_consumo = table.Column<decimal>(type: "NUMBER(10,2)", nullable: false),
                    Id_aparelho = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Id_bandeira = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RegistroConsumo", x => x.Id_registro);
                    table.ForeignKey(
                        name: "FK_TB_RegistroConsumo_TB_Aparelho_Id_aparelho",
                        column: x => x.Id_aparelho,
                        principalTable: "TB_Aparelho",
                        principalColumn: "Id_aparelho",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_RegistroConsumo_TB_BandeiraTarifaria_Id_bandeira",
                        column: x => x.Id_bandeira,
                        principalTable: "TB_BandeiraTarifaria",
                        principalColumn: "Id_bandeira",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Aparelho_Id_usuario",
                table: "TB_Aparelho",
                column: "Id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Conquista_Id_usuario",
                table: "TB_Conquista",
                column: "Id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Meta_Id_usuario",
                table: "TB_Meta",
                column: "Id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Notificacao_Id_usuario",
                table: "TB_Notificacao",
                column: "Id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Recomendacao_Id_usuario",
                table: "TB_Recomendacao",
                column: "Id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RegistroConsumo_Id_aparelho",
                table: "TB_RegistroConsumo",
                column: "Id_aparelho");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RegistroConsumo_Id_bandeira",
                table: "TB_RegistroConsumo",
                column: "Id_bandeira");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Conquista");

            migrationBuilder.DropTable(
                name: "TB_Meta");

            migrationBuilder.DropTable(
                name: "TB_Notificacao");

            migrationBuilder.DropTable(
                name: "TB_Recomendacao");

            migrationBuilder.DropTable(
                name: "TB_RegistroConsumo");

            migrationBuilder.DropTable(
                name: "TB_Aparelho");

            migrationBuilder.DropTable(
                name: "TB_BandeiraTarifaria");

            migrationBuilder.DropTable(
                name: "TB_Usuario");
        }
    }
}
