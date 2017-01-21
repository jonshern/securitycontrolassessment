using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecurityControlAssessment.WebServices.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssessmentReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AssessmentType = table.Column<string>(nullable: true),
                    CreateTimeStamp = table.Column<DateTime>(nullable: false),
                    LastSnapshotDate = table.Column<DateTime>(nullable: false),
                    LevelFiveScore = table.Column<decimal>(nullable: false),
                    LevelFourScore = table.Column<decimal>(nullable: false),
                    LevelOneScore = table.Column<decimal>(nullable: false),
                    LevelThreeScore = table.Column<decimal>(nullable: false),
                    LevelTwoScore = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OverallMaturityScore = table.Column<decimal>(nullable: false),
                    Tags = table.Column<string>(nullable: true),
                    UpdateTimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssesmentTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssesmentTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AppliesTo = table.Column<string>(nullable: true),
                    AssessmentReportId = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    ControlAutomated = table.Column<string>(nullable: true),
                    ControlAutomatedScore = table.Column<decimal>(nullable: false),
                    ControlId = table.Column<decimal>(nullable: false),
                    ControlImplemented = table.Column<string>(nullable: true),
                    ControlImplementedScore = table.Column<decimal>(nullable: false),
                    ControlNumber = table.Column<int>(nullable: false),
                    ControlReporting = table.Column<string>(nullable: true),
                    ControlReportingScore = table.Column<decimal>(nullable: false),
                    CreateTimeStamp = table.Column<DateTime>(nullable: false),
                    PolicyDefined = table.Column<string>(nullable: true),
                    PolicyDefinedScore = table.Column<decimal>(nullable: false),
                    QuestionId = table.Column<Guid>(nullable: false),
                    QuestionText = table.Column<string>(nullable: true),
                    UpdateTimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentAnswers_AssessmentReports_AssessmentReportId",
                        column: x => x.AssessmentReportId,
                        principalTable: "AssessmentReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportSnapshots",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    ReportId = table.Column<Guid>(nullable: true),
                    SavedBy = table.Column<string>(nullable: true),
                    SnapshotDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportSnapshots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportSnapshots_AssessmentReports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "AssessmentReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TemplateQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AssessmentTemplateId = table.Column<Guid>(nullable: true),
                    Baseline = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    ControlId = table.Column<decimal>(nullable: false),
                    ControlNumber = table.Column<int>(nullable: false),
                    Detail = table.Column<string>(nullable: true),
                    NISTCoreFramework = table.Column<string>(nullable: true),
                    Tags = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateQuestion_AssesmentTemplates_AssessmentTemplateId",
                        column: x => x.AssessmentTemplateId,
                        principalTable: "AssesmentTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentAnswers_AssessmentReportId",
                table: "AssessmentAnswers",
                column: "AssessmentReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportSnapshots_ReportId",
                table: "ReportSnapshots",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateQuestion_AssessmentTemplateId",
                table: "TemplateQuestion",
                column: "AssessmentTemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssessmentAnswers");

            migrationBuilder.DropTable(
                name: "ReportSnapshots");

            migrationBuilder.DropTable(
                name: "TemplateQuestion");

            migrationBuilder.DropTable(
                name: "AssessmentReports");

            migrationBuilder.DropTable(
                name: "AssesmentTemplates");
        }
    }
}
