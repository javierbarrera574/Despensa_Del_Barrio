using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prueba.BD.Migrations
{
    public partial class TablasModificacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categorias_CategoriaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Proveedores_ProveedorId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Proveedores_Administradores_AdministradorId",
                table: "Proveedores");

            migrationBuilder.DropIndex(
                name: "IX_Productos_ProveedorId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "ProveedorId",
                table: "Productos");

            migrationBuilder.AlterColumn<int>(
                name: "AdministradorId",
                table: "Proveedores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "Proveedores",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Productos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_ProductoId",
                table: "Proveedores",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categorias_CategoriaId",
                table: "Productos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedores_Administradores_AdministradorId",
                table: "Proveedores",
                column: "AdministradorId",
                principalTable: "Administradores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedores_Productos_ProductoId",
                table: "Proveedores",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categorias_CategoriaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Proveedores_Administradores_AdministradorId",
                table: "Proveedores");

            migrationBuilder.DropForeignKey(
                name: "FK_Proveedores_Productos_ProductoId",
                table: "Proveedores");

            migrationBuilder.DropIndex(
                name: "IX_Proveedores_ProductoId",
                table: "Proveedores");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Proveedores");

            migrationBuilder.AlterColumn<int>(
                name: "AdministradorId",
                table: "Proveedores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProveedorId",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ProveedorId",
                table: "Productos",
                column: "ProveedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categorias_CategoriaId",
                table: "Productos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Proveedores_ProveedorId",
                table: "Productos",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedores_Administradores_AdministradorId",
                table: "Proveedores",
                column: "AdministradorId",
                principalTable: "Administradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
