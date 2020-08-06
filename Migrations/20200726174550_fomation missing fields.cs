using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessusFormation.Migrations
{
    public partial class fomationmissingfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bareme_TFP",
                table: "BesoinFormationModels",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Cout_Totale_previsionnel",
                table: "BesoinFormationModels",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Cout_unitaire",
                table: "BesoinFormationModels",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Debut",
                table: "BesoinFormationModels",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Fin",
                table: "BesoinFormationModels",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Duree",
                table: "BesoinFormationModels",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FormationType",
                table: "BesoinFormationModels",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Frais_de_deplacement",
                table: "BesoinFormationModels",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Imputation",
                table: "BesoinFormationModels",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Montant_recuperer",
                table: "BesoinFormationModels",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Nombre_de_jours",
                table: "BesoinFormationModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Organisme_de_formation",
                table: "BesoinFormationModels",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nom_formateur",
                table: "BesoinFormationModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "type_de_formation",
                table: "BesoinFormationModels",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bareme_TFP",
                table: "BesoinFormationModels");

            migrationBuilder.DropColumn(
                name: "Cout_Totale_previsionnel",
                table: "BesoinFormationModels");

            migrationBuilder.DropColumn(
                name: "Cout_unitaire",
                table: "BesoinFormationModels");

            migrationBuilder.DropColumn(
                name: "Date_Debut",
                table: "BesoinFormationModels");

            migrationBuilder.DropColumn(
                name: "Date_Fin",
                table: "BesoinFormationModels");

            migrationBuilder.DropColumn(
                name: "Duree",
                table: "BesoinFormationModels");

            migrationBuilder.DropColumn(
                name: "FormationType",
                table: "BesoinFormationModels");

            migrationBuilder.DropColumn(
                name: "Frais_de_deplacement",
                table: "BesoinFormationModels");

            migrationBuilder.DropColumn(
                name: "Imputation",
                table: "BesoinFormationModels");

            migrationBuilder.DropColumn(
                name: "Montant_recuperer",
                table: "BesoinFormationModels");

            migrationBuilder.DropColumn(
                name: "Nombre_de_jours",
                table: "BesoinFormationModels");

            migrationBuilder.DropColumn(
                name: "Organisme_de_formation",
                table: "BesoinFormationModels");

            migrationBuilder.DropColumn(
                name: "nom_formateur",
                table: "BesoinFormationModels");

            migrationBuilder.DropColumn(
                name: "type_de_formation",
                table: "BesoinFormationModels");
        }
    }
}
