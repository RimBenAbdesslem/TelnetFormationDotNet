using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessusFormation.Migrations
{
    public partial class nameid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    Valide = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BesoinCollectes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Activite = table.Column<string>(nullable: false),
                    Intitule_Formation = table.Column<string>(nullable: false),
                    Priorite = table.Column<string>(nullable: false),
                    Justification_du_besoin = table.Column<string>(nullable: false),
                    Nombre_de_participants = table.Column<string>(nullable: false),
                    Organisme_de_formation = table.Column<string>(nullable: false),
                    Date_Debut = table.Column<DateTime>(nullable: false),
                    Date_Fin = table.Column<DateTime>(nullable: false),
                    type_de_formation = table.Column<string>(nullable: false),
                    Nombre_de_jours = table.Column<int>(nullable: false),
                    Duree = table.Column<string>(nullable: false),
                    Cout_unitaire = table.Column<float>(nullable: false),
                    Frais_de_deplacement = table.Column<float>(nullable: false),
                    Cout_Totale_previsionnel = table.Column<float>(nullable: false),
                    Imputation = table.Column<float>(nullable: false),
                    Bareme_TFP = table.Column<string>(nullable: false),
                    Montant_recuperer = table.Column<float>(nullable: false),
                    nom_formateur = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BesoinCollectes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BesoinFormationModels",
                columns: table => new
                {
                    BesoinFormationId = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Activite = table.Column<string>(nullable: true),
                    Intitule_Formation = table.Column<string>(nullable: true),
                    Priorite = table.Column<string>(nullable: true),
                    Justification_du_besoin = table.Column<string>(nullable: true),
                    Nombre_de_participants = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BesoinFormationModels", x => x.BesoinFormationId);
                });

            migrationBuilder.CreateTable(
                name: "CompetenceEvaluationFroids",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdEvaluation = table.Column<int>(nullable: false),
                    Competence = table.Column<string>(nullable: true),
                    Niveau_actuel = table.Column<int>(nullable: false),
                    Degre = table.Column<string>(nullable: true),
                    Niveau_acquis = table.Column<int>(nullable: false),
                    Critere10 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenceEvaluationFroids", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Domaine = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Niveau = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Domaines",
                columns: table => new
                {
                    DomaineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomDomaine = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domaines", x => x.DomaineId);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationChauds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Theme = table.Column<string>(nullable: true),
                    Lieu = table.Column<string>(nullable: true),
                    Organisme = table.Column<string>(nullable: true),
                    Formateur = table.Column<string>(nullable: true),
                    Date_Evaluation_Chaud = table.Column<DateTime>(nullable: false),
                    Date_DebutFormation = table.Column<DateTime>(nullable: false),
                    Date_FinFormation = table.Column<DateTime>(nullable: false),
                    Nom_Participant = table.Column<string>(nullable: true),
                    Prenom_Participant = table.Column<string>(nullable: true),
                    Matricule = table.Column<string>(nullable: true),
                    Fonction = table.Column<string>(nullable: true),
                    Direction = table.Column<string>(nullable: true),
                    QuestionA = table.Column<string>(nullable: true),
                    Lequelles = table.Column<string>(nullable: true),
                    PourqouiA = table.Column<string>(nullable: true),
                    PourqouiB = table.Column<string>(nullable: true),
                    QuestionB = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    QuestionC = table.Column<string>(nullable: true),
                    Score_Evaluation = table.Column<int>(nullable: false),
                    Score_Satisfaction = table.Column<int>(nullable: false),
                    Commentaire1 = table.Column<string>(nullable: true),
                    Commentaire2 = table.Column<string>(nullable: true),
                    Commentaire3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationChauds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationFroidParticipants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Theme = table.Column<string>(nullable: true),
                    Lieu = table.Column<string>(nullable: true),
                    Organisme = table.Column<string>(nullable: true),
                    Formateur = table.Column<string>(nullable: true),
                    Date_Debut = table.Column<DateTime>(nullable: false),
                    Date_Fin = table.Column<DateTime>(nullable: false),
                    Nom_Participant = table.Column<string>(nullable: true),
                    Prenom_Participant = table.Column<string>(nullable: true),
                    Matricule = table.Column<string>(nullable: true),
                    Fonction = table.Column<string>(nullable: true),
                    Direction = table.Column<string>(nullable: true),
                    Date_Evaluation_Froid = table.Column<DateTime>(nullable: false),
                    question_A = table.Column<string>(nullable: true),
                    question_B = table.Column<string>(nullable: true),
                    question_C = table.Column<string>(nullable: true),
                    Lesquelles = table.Column<string>(nullable: true),
                    PourquoiA = table.Column<string>(nullable: true),
                    Autres1 = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    PourquoiB = table.Column<string>(nullable: true),
                    Commentaire1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationFroidParticipants", x => x.Id);
                });
            migrationBuilder.CreateTable(
              name: "Activites",
              columns: table => new
              {
                  Id = table.Column<int>(nullable: false)
                      .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                  NomActivite = table.Column<string>(nullable: true),

              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Activites", x => x.Id);
              });

            migrationBuilder.CreateTable(
                name: "EvaluationFroids",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Theme = table.Column<string>(nullable: true),
                    Lieu = table.Column<string>(nullable: true),
                    Organisme = table.Column<string>(nullable: true),
                    Formateur = table.Column<string>(nullable: true),
                    Date_Debut = table.Column<DateTime>(nullable: false),
                    Date_Fin = table.Column<DateTime>(nullable: false),
                    Nom_Participant = table.Column<string>(nullable: true),
                    Prenom_Participant = table.Column<string>(nullable: true),
                    Matricule = table.Column<string>(nullable: true),
                    Fonction = table.Column<string>(nullable: true),
                    Direction = table.Column<string>(nullable: true),
                    Date_Evaluation_Froid = table.Column<DateTime>(nullable: false),
                    question_A = table.Column<string>(nullable: true),
                    question_B = table.Column<string>(nullable: true),
                    question_C = table.Column<string>(nullable: true),
                    Lesquelles = table.Column<string>(nullable: true),
                    PourquoiA = table.Column<string>(nullable: true),
                    Autres1 = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    PourquoiB = table.Column<string>(nullable: true),
                    Commentaire1 = table.Column<string>(nullable: true),
                    Critere1 = table.Column<string>(nullable: true),
                    Critere2 = table.Column<string>(nullable: true),
                    Critere3 = table.Column<string>(nullable: true),
                    Critere4 = table.Column<string>(nullable: true),
                    Critere5 = table.Column<string>(nullable: true),
                    Critere6 = table.Column<string>(nullable: true),
                    Critere7 = table.Column<string>(nullable: true),
                    Critere8 = table.Column<string>(nullable: true),
                    Critere9 = table.Column<string>(nullable: true),
                    Autres2 = table.Column<string>(nullable: true),
                    Sinon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationFroids", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formateurs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Theme = table.Column<string>(nullable: true),
                    Organisme_prestataire = table.Column<string>(nullable: true),
                    Nom_Formateur = table.Column<string>(nullable: true),
                    Period = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formateurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Intermidiaires",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParticipantId = table.Column<string>(nullable: true),
                    DirectActivId = table.Column<string>(nullable: true),
                    EvaluatFroidId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intermidiaires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Metiers",
                columns: table => new
                {
                    MetierId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DomaineId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    LabelId = table.Column<int>(nullable: false),
                    Niveau = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metiers", x => x.MetierId);
                });

            migrationBuilder.CreateTable(
                name: "ActiviteMetiers",
                columns: table => new
                {
                    ActivMetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DomaineId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    LabelId = table.Column<int>(nullable: false),
                    ActiviteId = table.Column<int>(nullable: false),
                    Niveau = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiviteMetiers", x => x.ActivMetId);
                });
            migrationBuilder.CreateTable(
               name: "ListeActivites",
               columns: table => new
               {
                   ListActivId = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                   DomaineId = table.Column<int>(nullable: false),
                   LabelId = table.Column<int>(nullable: false),
                   ActiviteId = table.Column<int>(nullable: false),
                   NomDomaine = table.Column<string>(nullable: true),
                   NomActivite = table.Column<string>(nullable: true),
                   NomLabel = table.Column<string>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_ListeActivites", x => x.ListActivId);
               });
            migrationBuilder.CreateTable(
                name: "ParticipantModels",
                columns: table => new
                {
                    ParticipantId = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantModels", x => x.ParticipantId);
                });

            migrationBuilder.CreateTable(
                name: "SuiviFormations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Activite = table.Column<string>(nullable: true),
                    Intitule_Formation = table.Column<string>(nullable: false),
                    Priorite = table.Column<string>(nullable: false),
                    Justification_du_besoin = table.Column<string>(nullable: false),
                    Nombre_de_participants = table.Column<string>(nullable: false),
                    Organisme_de_formation = table.Column<string>(nullable: false),
                    Nombre_Table = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuiviFormations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantToFormations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IdFormation = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantToFormations", x => new { x.IdFormation, x.Id });
                    table.ForeignKey(
                        name: "FK_ParticipantToFormations_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantToFormations_BesoinFormationModels_IdFormation",
                        column: x => x.IdFormation,
                        principalTable: "BesoinFormationModels",
                        principalColumn: "BesoinFormationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Labels",
                columns: table => new
                {
                    LabelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomLabel = table.Column<string>(nullable: true),
                    Niveau = table.Column<int>(nullable: false),
                    DomaineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.LabelId);
                    table.ForeignKey(
                        name: "FK_Labels_Domaines_DomaineId",
                        column: x => x.DomaineId,
                        principalTable: "Domaines",
                        principalColumn: "DomaineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantFormation",
                columns: table => new
                {
                    ParticipantId = table.Column<string>(nullable: false),
                    BesoinFormationId = table.Column<string>(nullable: false),
                    ParticipantModelParticipantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantFormation", x => new { x.BesoinFormationId, x.ParticipantId });
                    table.ForeignKey(
                        name: "FK_ParticipantFormation_BesoinFormationModels_BesoinFormationId",
                        column: x => x.BesoinFormationId,
                        principalTable: "BesoinFormationModels",
                        principalColumn: "BesoinFormationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantFormation_ParticipantModels_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "ParticipantModels",
                        principalColumn: "ParticipantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantFormation_ParticipantModels_ParticipantModelParticipantId",
                        column: x => x.ParticipantModelParticipantId,
                        principalTable: "ParticipantModels",
                        principalColumn: "ParticipantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Labels_DomaineId",
                table: "Labels",
                column: "DomaineId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantFormation_ParticipantId",
                table: "ParticipantFormation",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantFormation_ParticipantModelParticipantId",
                table: "ParticipantFormation",
                column: "ParticipantModelParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantToFormations_Id",
                table: "ParticipantToFormations",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BesoinCollectes");

            migrationBuilder.DropTable(
                name: "CompetenceEvaluationFroids");

            migrationBuilder.DropTable(
                name: "Competences");

            migrationBuilder.DropTable(
                name: "EvaluationChauds");

            migrationBuilder.DropTable(
                name: "EvaluationFroidParticipants");

            migrationBuilder.DropTable(
                name: "EvaluationFroids");

            migrationBuilder.DropTable(
                name: "Formateurs");

            migrationBuilder.DropTable(
                name: "Intermidiaires");

            migrationBuilder.DropTable(
                name: "Labels");

            migrationBuilder.DropTable(
                name: "Metiers");

            migrationBuilder.DropTable(
                name: "ParticipantFormation");

            migrationBuilder.DropTable(
                name: "ParticipantToFormations");

            migrationBuilder.DropTable(
                name: "SuiviFormations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Domaines");

            migrationBuilder.DropTable(
                name: "ParticipantModels");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BesoinFormationModels");
        }
    }
}
