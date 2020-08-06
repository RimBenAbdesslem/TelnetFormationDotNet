using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessusFormation.Migrations
{
    public partial class changeKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantFormation_BesoinFormationModels_BesoinFormationId",
                table: "ParticipantFormation");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantFormation_ParticipantModels_ParticipantId",
                table: "ParticipantFormation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParticipantFormation",
                table: "ParticipantFormation");

            migrationBuilder.AlterColumn<string>(
                name: "ParticipantId",
                table: "ParticipantFormation",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "BesoinFormationId",
                table: "ParticipantFormation",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "ParticipantFormation",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParticipantFormation",
                table: "ParticipantFormation",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantFormation_BesoinFormationId",
                table: "ParticipantFormation",
                column: "BesoinFormationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantFormation_BesoinFormationModels_BesoinFormationId",
                table: "ParticipantFormation",
                column: "BesoinFormationId",
                principalTable: "BesoinFormationModels",
                principalColumn: "BesoinFormationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantFormation_ParticipantModels_ParticipantId",
                table: "ParticipantFormation",
                column: "ParticipantId",
                principalTable: "ParticipantModels",
                principalColumn: "ParticipantId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantFormation_BesoinFormationModels_BesoinFormationId",
                table: "ParticipantFormation");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantFormation_ParticipantModels_ParticipantId",
                table: "ParticipantFormation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParticipantFormation",
                table: "ParticipantFormation");

            migrationBuilder.DropIndex(
                name: "IX_ParticipantFormation_BesoinFormationId",
                table: "ParticipantFormation");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ParticipantFormation");

            migrationBuilder.AlterColumn<string>(
                name: "ParticipantId",
                table: "ParticipantFormation",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BesoinFormationId",
                table: "ParticipantFormation",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParticipantFormation",
                table: "ParticipantFormation",
                columns: new[] { "BesoinFormationId", "ParticipantId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantFormation_BesoinFormationModels_BesoinFormationId",
                table: "ParticipantFormation",
                column: "BesoinFormationId",
                principalTable: "BesoinFormationModels",
                principalColumn: "BesoinFormationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantFormation_ParticipantModels_ParticipantId",
                table: "ParticipantFormation",
                column: "ParticipantId",
                principalTable: "ParticipantModels",
                principalColumn: "ParticipantId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
