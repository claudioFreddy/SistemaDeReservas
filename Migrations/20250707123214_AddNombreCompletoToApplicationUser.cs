using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeReservas.Migrations
{
    /// <inheritdoc />
    public partial class AddNombreCompletoToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_AspNetUsers_UsuarioId",
                table: "Reservas");


            migrationBuilder.AddColumn<string>(
                   name: "NombreCompleto",
                   table: "AspNetUsers",
                   type: "nvarchar(max)",
                   nullable: true);


            /*   migrationBuilder.AlterColumn<string>(
                   name: "Name",
                   table: "AspNetUserTokens", 
                   type: "nvarchar(128)",
                   maxLength: 128,
                   nullable: false,
                   oldClrType: typeof(string),
                   oldType: "nvarchar(450)");  

               migrationBuilder.AlterColumn<string>(
                   name: "LoginProvider",
                   table: "AspNetUserTokens",
                   type: "nvarchar(128)",
                   maxLength: 128,
                   nullable: false,
                   oldClrType: typeof(string),
                   oldType: "nvarchar(450)");  

            migrationBuilder.AddColumn<string>(
                name: "NombreCompleto",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey", 
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",  
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_AspNetUsers_UsuarioId",
                table: "Reservas",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");  */
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_AspNetUsers_UsuarioId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "NombreCompleto",
                table: "AspNetUsers");


         /*   migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",  
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);  

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);  

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",  
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",  
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_AspNetUsers_UsuarioId",
                table: "Reservas",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade); */
        }
    }
}
