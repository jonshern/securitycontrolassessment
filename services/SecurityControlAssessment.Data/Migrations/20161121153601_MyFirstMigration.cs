using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecurityControlAssessment.Data.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssessmentReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Tags = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AppliesTo = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    ControlAutomated = table.Column<string>(nullable: true),
                    ControlImplemented = table.Column<string>(nullable: true),
                    ControlReporting = table.Column<string>(nullable: true),
                    Effort = table.Column<string>(nullable: true),
                    Mitigation = table.Column<string>(nullable: true),
                    PolicyDefined = table.Column<string>(nullable: true),
                    Risk = table.Column<string>(nullable: true),
                    SecurityControlId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentReSecurityControlItemports",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Baseline = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    ControlId = table.Column<string>(nullable: true),
                    ControlNumber = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    NISTCoreFramework = table.Column<string>(nullable: true),
                    Tags = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentReSecurityControlItemports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AnswerId = table.Column<Guid>(nullable: true),
                    AssessmentReportId = table.Column<Guid>(nullable: false),
                    QuestionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentItems_AssessmentResults_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "AssessmentResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentItems_AssessmentReports_AssessmentReportId",
                        column: x => x.AssessmentReportId,
                        principalTable: "AssessmentReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentItems_AssessmentReSecurityControlItemports_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "AssessmentReSecurityControlItemports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentItems_AnswerId",
                table: "AssessmentItems",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentItems_AssessmentReportId",
                table: "AssessmentItems",
                column: "AssessmentReportId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentItems_QuestionId",
                table: "AssessmentItems",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssessmentItems");

            migrationBuilder.DropTable(
                name: "AssessmentResults");

            migrationBuilder.DropTable(
                name: "AssessmentReports");

            migrationBuilder.DropTable(
                name: "AssessmentReSecurityControlItemports");
        }
    }
}
