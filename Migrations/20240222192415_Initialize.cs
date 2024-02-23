using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExperimentTester.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Experiments",
                columns: table => new
                {
                    ExperimentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistributionPercentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiments", x => x.ExperimentID);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    ParticipantID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.ParticipantID);
                });

            migrationBuilder.CreateTable(
                name: "ExperimentParticipantAssociations",
                columns: table => new
                {
                    AssociationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExperimentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipantID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperimentParticipantAssociations", x => x.AssociationID);
                    table.ForeignKey(
                        name: "FK_ExperimentParticipantAssociations_Experiments_ExperimentID",
                        column: x => x.ExperimentID,
                        principalTable: "Experiments",
                        principalColumn: "ExperimentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperimentParticipantAssociations_Participants_ParticipantID",
                        column: x => x.ParticipantID,
                        principalTable: "Participants",
                        principalColumn: "ParticipantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExperimentParticipantAssociations_ExperimentID",
                table: "ExperimentParticipantAssociations",
                column: "ExperimentID");

            migrationBuilder.CreateIndex(
                name: "IX_ExperimentParticipantAssociations_ParticipantID",
                table: "ExperimentParticipantAssociations",
                column: "ParticipantID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExperimentParticipantAssociations");

            migrationBuilder.DropTable(
                name: "Experiments");

            migrationBuilder.DropTable(
                name: "Participants");
        }
    }
}
