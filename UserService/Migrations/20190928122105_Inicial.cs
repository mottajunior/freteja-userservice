using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace UserService.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "perfil",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    tipo = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nome = table.Column<string>(type: "varchar(30)", nullable: false),
                    email = table.Column<string>(type: "varchar(120)", nullable: false),
                    senha = table.Column<string>(type: "varchar(120)", nullable: false),
                    id_perfil = table.Column<int>(type: "INT", nullable: false),
                    cidade = table.Column<string>(type: "varchar(50)", nullable: false),
                    endereco = table.Column<string>(type: "varchar(150)", nullable: false),
                    numero_residencia = table.Column<string>(type: "varchar(10)", nullable: false),
                    bairro = table.Column<string>(type: "varchar(50)", nullable: false),
                    telefone = table.Column<string>(type: "varchar(25)", nullable: false),
                    Cnh = table.Column<int>(type: "INT", nullable: true),
                    cep = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuario_perfil_id_perfil",
                        column: x => x.id_perfil,
                        principalTable: "perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "veiculo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    placa = table.Column<string>(type: "varchar(15)", nullable: false),
                    modelo = table.Column<string>(type: "varchar(60)", nullable: false),
                    cor = table.Column<string>(type: "varchar(15)", nullable: false),
                    ano = table.Column<int>(type: "INT", nullable: false),
                    renavan = table.Column<string>(type: "varchar(20)", nullable: false),
                    id_usuario = table.Column<int>(type: "INT", nullable: false),
                    carga_max_kg = table.Column<decimal>(type: "decimal(7,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_veiculo_usuario_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuario_id_perfil",
                table: "usuario",
                column: "id_perfil");

            migrationBuilder.CreateIndex(
                name: "IX_veiculo_id_usuario",
                table: "veiculo",
                column: "id_usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "veiculo");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "perfil");
        }
    }
}
