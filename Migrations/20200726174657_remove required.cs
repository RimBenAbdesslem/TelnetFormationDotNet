using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessusFormation.Migrations
{
    public partial class removerequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "type_de_formation",
                table: "BesoinFormationModels",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Organisme_de_formation",
                table: "BesoinFormationModels",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Duree",
                table: "BesoinFormationModels",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Bareme_TFP",
                table: "BesoinFormationModels",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "type_de_formation",
                table: "BesoinFormationModels",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Organisme_de_formation",
                table: "BesoinFormationModels",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Duree",
                table: "BesoinFormationModels",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bareme_TFP",
                table: "BesoinFormationModels",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
