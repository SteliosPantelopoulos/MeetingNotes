using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetingNotes.Data.Migrations
{
    public partial class InitialContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeetingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeetingStatus = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", nullable: false),
                    ExternalParticipants = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RiskLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeetingParticipants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingId = table.Column<int>(type: "int", nullable: false),
                    ParticipantId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingParticipants_AspNetUsers_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingParticipants_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeetingItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssignedTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RiskLevelId = table.Column<int>(type: "int", nullable: false),
                    RequestedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChangeRequested = table.Column<bool>(type: "bit", nullable: false),
                    VissibleInMinutes = table.Column<bool>(type: "bit", nullable: false),
                    FileAttachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingItems_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingItems_RiskLevels_RiskLevelId",
                        column: x => x.RiskLevelId,
                        principalTable: "RiskLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeetingItems_MeetingId",
                table: "MeetingItems",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingItems_RiskLevelId",
                table: "MeetingItems",
                column: "RiskLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingParticipants_MeetingId",
                table: "MeetingParticipants",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingParticipants_ParticipantId",
                table: "MeetingParticipants",
                column: "ParticipantId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeetingItems");

            migrationBuilder.DropTable(
                name: "MeetingParticipants");

            migrationBuilder.DropTable(
                name: "RiskLevels");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");
        }
    }
}
