using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecurityControlAssessment.WebServices.Migrations
{
    public partial class updatesnapshot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportSnapshots_AssessmentReports_ReportId",
                table: "ReportSnapshots");

            migrationBuilder.RenameColumn(
                name: "ReportId",
                table: "ReportSnapshots",
                newName: "AssessmentReportId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportSnapshots_ReportId",
                table: "ReportSnapshots",
                newName: "IX_ReportSnapshots_AssessmentReportId");

            migrationBuilder.AddColumn<Guid>(
                name: "OriginReportId",
                table: "ReportSnapshots",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SnapshotReportId",
                table: "ReportSnapshots",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ReportType",
                table: "AssessmentReports",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportSnapshots_AssessmentReports_AssessmentReportId",
                table: "ReportSnapshots",
                column: "AssessmentReportId",
                principalTable: "AssessmentReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportSnapshots_AssessmentReports_AssessmentReportId",
                table: "ReportSnapshots");

            migrationBuilder.DropColumn(
                name: "OriginReportId",
                table: "ReportSnapshots");

            migrationBuilder.DropColumn(
                name: "SnapshotReportId",
                table: "ReportSnapshots");

            migrationBuilder.DropColumn(
                name: "ReportType",
                table: "AssessmentReports");

            migrationBuilder.RenameColumn(
                name: "AssessmentReportId",
                table: "ReportSnapshots",
                newName: "ReportId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportSnapshots_AssessmentReportId",
                table: "ReportSnapshots",
                newName: "IX_ReportSnapshots_ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportSnapshots_AssessmentReports_ReportId",
                table: "ReportSnapshots",
                column: "ReportId",
                principalTable: "AssessmentReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
