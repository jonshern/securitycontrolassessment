using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecurityControlAssessment.WebServices.Migrations
{
    public partial class IsDeletedStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AssessmentReports");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AssessmentReports",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "AssessmentReports");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AssessmentReports",
                nullable: false,
                defaultValue: false);
        }
    }
}
