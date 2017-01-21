using Microsoft.EntityFrameworkCore;
using SecurityControlAssessment.Model;
using System;

namespace SecurityControlAssessment.Data
{

    public class AssessmentContext : DbContext
    {
        public DbSet<AssessmentAnswer> AssessmentAnswers { get; set; }
        public DbSet<AssessmentReport> AssessmentReports { get; set; }
        public DbSet<TemplateQuestion> AssessmentSecurityControlItems { get; set; }
        public DbSet<ReportSnapshot> ReportSnapshots { get; set; }

        public DbSet<AssessmentTemplate> AssesmentTemplates { get; set; }

        public DbSet<TemplateQuestion> TemplateQuestions { get; set; }

        public AssessmentContext(DbContextOptions<AssessmentContext> options)
        : base(options)
        {

        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Blog>()
        //        .Property(b => b.Url)
        //        .IsRequired();
        //}



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase();
            //base.OnConfiguring(optionsBuilder);


            //optionsBuilder.UseInternalServiceProvider
            var connection = @"Server=tcp:[server],1433;Initial Catalog=Assessment;Persist Security Info=False;User ID=[username];Password=[password];MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            optionsBuilder.UseSqlServer(connection, b => b.MigrationsAssembly("SecurityControlAssessment.WebServices"));

        }
    }
}
