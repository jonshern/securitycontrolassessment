using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecurityControlAssessment.WebServices.Migrations
{
    public partial class updatesnapshot1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportSnapshots_AssessmentReports_AssessmentReportId",
                table: "ReportSnapshots");

            migrationBuilder.DropIndex(
                name: "IX_ReportSnapshots_AssessmentReportId",
                table: "ReportSnapshots");

            migrationBuilder.DropColumn(
                name: "AssessmentReportId",
                table: "ReportSnapshots");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AssessmentReportId",
                table: "ReportSnapshots",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportSnapshots_AssessmentReportId",
                table: "ReportSnapshots",
                column: "AssessmentReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportSnapshots_AssessmentReports_AssessmentReportId",
                table: "ReportSnapshots",
                column: "AssessmentReportId",
                principalTable: "AssessmentReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
