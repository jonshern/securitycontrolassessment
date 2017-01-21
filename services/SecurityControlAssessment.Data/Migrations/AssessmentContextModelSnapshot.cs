using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SecurityControlAssessment.Data;

namespace SecurityControlAssessment.Data.Migrations
{
    [DbContext(typeof(AssessmentContext))]
    partial class AssessmentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SecurityControlAssessment.Model.AssessmentItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AnswerId");

                    b.Property<Guid>("AssessmentReportId");

                    b.Property<Guid?>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("AssessmentReportId");

                    b.HasIndex("QuestionId");

                    b.ToTable("AssessmentItems");
                });

            modelBuilder.Entity("SecurityControlAssessment.Model.AssessmentReport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Tags");

                    b.HasKey("Id");

                    b.ToTable("AssessmentReports");
                });

            modelBuilder.Entity("SecurityControlAssessment.Model.AssessmentResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppliesTo");

                    b.Property<string>("Comments");

                    b.Property<string>("ControlAutomated");

                    b.Property<string>("ControlImplemented");

                    b.Property<string>("ControlReporting");

                    b.Property<string>("Effort");

                    b.Property<string>("Mitigation");

                    b.Property<string>("PolicyDefined");

                    b.Property<string>("Risk");

                    b.Property<int>("SecurityControlId");

                    b.HasKey("Id");

                    b.ToTable("AssessmentResults");
                });

            modelBuilder.Entity("SecurityControlAssessment.Model.SecurityControlItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Baseline");

                    b.Property<string>("Category");

                    b.Property<string>("ControlId");

                    b.Property<string>("ControlNumber");

                    b.Property<string>("Detail");

                    b.Property<string>("NISTCoreFramework");

                    b.Property<string>("Tags");

                    b.HasKey("Id");

                    b.ToTable("AssessmentReSecurityControlItemports");
                });

            modelBuilder.Entity("SecurityControlAssessment.Model.AssessmentItem", b =>
                {
                    b.HasOne("SecurityControlAssessment.Model.AssessmentResult", "Answer")
                        .WithMany()
                        .HasForeignKey("AnswerId");

                    b.HasOne("SecurityControlAssessment.Model.AssessmentReport")
                        .WithMany("AssessmentItems")
                        .HasForeignKey("AssessmentReportId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SecurityControlAssessment.Model.SecurityControlItem", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId");
                });
        }
    }
}
