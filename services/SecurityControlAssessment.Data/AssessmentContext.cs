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
            // var connection = @"Server = eussqlassessment.database.windows.net; Initial Catalog = Assessment; Persist Security Info = False; User ID =jonshern; Password = Mooncheese%5; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ";

            //optionsBuilder.UseInternalServiceProvider
            var connection = @"Server=tcp:eussqlassessment.database.windows.net;Database=Assessment;Persist Security Info=False;User ID=jonshern;Password=Mooncheese%5;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            // var connection = @"Server=tcp:eussqlassessment.database.windows.net,1433;Initial Catalog=Assessment;Persist Security Info=False;User ID=jonshern;Password=Mooncheese%5;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            optionsBuilder.UseSqlServer(connection, b => b.MigrationsAssembly("SecurityControlAssessment.WebServices"));

        }
    }
}
