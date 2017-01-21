using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SecurityControlAssessment.Data;

namespace SecurityControlAssessment.WebServices.Migrations
{
    [DbContext(typeof(AssessmentContext))]
    [Migration("20170113230529_firstmigration")]
    partial class firstmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SecurityControlAssessment.Model.AssessmentAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppliesTo");

                    b.Property<Guid>("AssessmentReportId");

                    b.Property<string>("Comments");

                    b.Property<string>("ControlAutomated");

                    b.Property<decimal>("ControlAutomatedScore");

                    b.Property<decimal>("ControlId");

                    b.Property<string>("ControlImplemented");

                    b.Property<decimal>("ControlImplementedScore");

                    b.Property<int>("ControlNumber");

                    b.Property<string>("ControlReporting");

                    b.Property<decimal>("ControlReportingScore");

                    b.Property<DateTime>("CreateTimeStamp");

                    b.Property<string>("PolicyDefined");

                    b.Property<decimal>("PolicyDefinedScore");

                    b.Property<Guid>("QuestionId");

                    b.Property<string>("QuestionText");

                    b.Property<DateTime>("UpdateTimeStamp");

                    b.HasKey("Id");

                    b.HasIndex("AssessmentReportId");

                    b.ToTable("AssessmentAnswers");
                });

            modelBuilder.Entity("SecurityControlAssessment.Model.AssessmentReport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AssessmentType");

                    b.Property<DateTime>("CreateTimeStamp");

                    b.Property<DateTime>("LastSnapshotDate");

                    b.Property<decimal>("LevelFiveScore");

                    b.Property<decimal>("LevelFourScore");

                    b.Property<decimal>("LevelOneScore");

                    b.Property<decimal>("LevelThreeScore");

                    b.Property<decimal>("LevelTwoScore");

                    b.Property<string>("Name");

                    b.Property<decimal>("OverallMaturityScore");

                    b.Property<string>("Tags");

                    b.Property<DateTime>("UpdateTimeStamp");

                    b.HasKey("Id");

                    b.ToTable("AssessmentReports");
                });

            modelBuilder.Entity("SecurityControlAssessment.Model.AssessmentTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AssesmentTemplates");
                });

            modelBuilder.Entity("SecurityControlAssessment.Model.ReportSnapshot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments");

                    b.Property<Guid?>("ReportId");

                    b.Property<string>("SavedBy");

                    b.Property<DateTime>("SnapshotDate");

                    b.HasKey("Id");

                    b.HasIndex("ReportId");

                    b.ToTable("ReportSnapshots");
                });

            modelBuilder.Entity("SecurityControlAssessment.Model.TemplateQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AssessmentTemplateId");

                    b.Property<string>("Baseline");

                    b.Property<string>("Category");

                    b.Property<decimal>("ControlId");

                    b.Property<int>("ControlNumber");

                    b.Property<string>("Detail");

                    b.Property<string>("NISTCoreFramework");

                    b.Property<string>("Tags");

                    b.HasKey("Id");

                    b.HasIndex("AssessmentTemplateId");

                    b.ToTable("TemplateQuestion");
                });

            modelBuilder.Entity("SecurityControlAssessment.Model.AssessmentAnswer", b =>
                {
                    b.HasOne("SecurityControlAssessment.Model.AssessmentReport")
                        .WithMany("AssessmentAnswers")
                        .HasForeignKey("AssessmentReportId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SecurityControlAssessment.Model.ReportSnapshot", b =>
                {
                    b.HasOne("SecurityControlAssessment.Model.AssessmentReport", "Report")
                        .WithMany("Snapshots")
                        .HasForeignKey("ReportId");
                });

            modelBuilder.Entity("SecurityControlAssessment.Model.TemplateQuestion", b =>
                {
                    b.HasOne("SecurityControlAssessment.Model.AssessmentTemplate")
                        .WithMany("Questions")
                        .HasForeignKey("AssessmentTemplateId");
                });
        }
    }
}
