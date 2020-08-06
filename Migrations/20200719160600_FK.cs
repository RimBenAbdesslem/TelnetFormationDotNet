using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessusFormation.Migrations
{
    public partial class FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantToFormations_BesoinFormationModels_IdFormation",
                table: "ParticipantToFormations");

            migrationBuilder.RenameColumn(
                name: "IdFormation",
                table: "ParticipantToFormations",
                newName: "BesoinFormationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantToFormations_BesoinFormationModels_BesoinFormationId",
                table: "ParticipantToFormations",
                column: "BesoinFormationId",
                principalTable: "BesoinFormationModels",
                principalColumn: "BesoinFormationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantToFormations_BesoinFormationModels_BesoinFormationId",
                table: "ParticipantToFormations");

            migrationBuilder.RenameColumn(
                name: "BesoinFormationId",
                table: "ParticipantToFormations",
                newName: "IdFormation");

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantToFormations_BesoinFormationModels_IdFormation",
                table: "ParticipantToFormations",
                column: "IdFormation",
                principalTable: "BesoinFormationModels",
                principalColumn: "BesoinFormationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
