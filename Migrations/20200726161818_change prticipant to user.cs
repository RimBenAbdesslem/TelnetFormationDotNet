using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessusFormation.Migrations
{
    public partial class changeprticipanttouser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantFormation_ParticipantModels_ParticipantId",
                table: "ParticipantFormation");

            migrationBuilder.AlterColumn<string>(
                name: "ParticipantId",
                table: "ParticipantFormation",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ParticipantFormation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParticipantModelParticipantId1",
                table: "ParticipantFormation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantFormation_ApplicationUserId",
                table: "ParticipantFormation",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantFormation_ParticipantModelParticipantId1",
                table: "ParticipantFormation",
                column: "ParticipantModelParticipantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantFormation_AspNetUsers_ApplicationUserId",
                table: "ParticipantFormation",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantFormation_AspNetUsers_ParticipantId",
                table: "ParticipantFormation",
                column: "ParticipantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantFormation_ParticipantModels_ParticipantModelParticipantId1",
                table: "ParticipantFormation",
                column: "ParticipantModelParticipantId1",
                principalTable: "ParticipantModels",
                principalColumn: "ParticipantId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantFormation_AspNetUsers_ApplicationUserId",
                table: "ParticipantFormation");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantFormation_AspNetUsers_ParticipantId",
                table: "ParticipantFormation");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantFormation_ParticipantModels_ParticipantModelParticipantId1",
                table: "ParticipantFormation");

            migrationBuilder.DropIndex(
                name: "IX_ParticipantFormation_ApplicationUserId",
                table: "ParticipantFormation");

            migrationBuilder.DropIndex(
                name: "IX_ParticipantFormation_ParticipantModelParticipantId1",
                table: "ParticipantFormation");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ParticipantFormation");

            migrationBuilder.DropColumn(
                name: "ParticipantModelParticipantId1",
                table: "ParticipantFormation");

            migrationBuilder.AlterColumn<string>(
                name: "ParticipantId",
                table: "ParticipantFormation",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantFormation_ParticipantModels_ParticipantId",
                table: "ParticipantFormation",
                column: "ParticipantId",
                principalTable: "ParticipantModels",
                principalColumn: "ParticipantId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
