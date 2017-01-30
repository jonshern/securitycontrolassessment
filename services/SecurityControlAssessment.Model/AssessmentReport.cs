using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityControlAssessment.Model
{
    public class AssessmentReport
    {

        public enum ReportStatus
        {
            None = 0,
            Active = 1,
            Snapshot = 2,
            Deleted = 3
        }

       

        public AssessmentReport(string assessmentName, string typeName, string tags)
        {
            this.Name = assessmentName;
            this.Id = Guid.NewGuid();
            this.AssessmentType = typeName;
            this.Tags = tags;

            this.OverallMaturityScore = 0;
            this.LevelOneScore = 0;
            this.LevelTwoScore = 0;
            this.LevelThreeScore = 0;
            this.LevelFourScore = 0;
            this.LevelFiveScore = 0;

            this.LastSnapshotDate = DateTime.Now;
            this.UpdateTimeStamp = DateTime.Now;
            this.CreateTimeStamp = DateTime.Now;

            this.ReportType = "Active";
            this.AssessmentAnswers = null;
        }

        public AssessmentReport(AssessmentReport report, string reportType)
        {
            this.Name = report.Name;
            this.Id = Guid.NewGuid();
            this.AssessmentType = report.AssessmentType;
            this.Tags = report.Tags;

            this.OverallMaturityScore = report.OverallMaturityScore;
            this.LevelOneScore = report.LevelOneScore;
            this.LevelTwoScore = report.LevelTwoScore;
            this.LevelThreeScore = report.LevelThreeScore;
            this.LevelFourScore = report.LevelFourScore;
            this.LevelFiveScore = report.LevelFiveScore;

            this.LastSnapshotDate = DateTime.Now;
            this.UpdateTimeStamp = DateTime.Now;
            this.CreateTimeStamp = DateTime.Now;

            this.ReportType = reportType;

            this.Status = ReportStatus.Active;

            List<AssessmentAnswer> answers = new List<AssessmentAnswer>();

            foreach(AssessmentAnswer answer in report.AssessmentAnswers)
            {
                answers.Add(new AssessmentAnswer(answer, this.Id));
            }

            this.AssessmentAnswers = answers;
            

        }

        public AssessmentReport()
        {


        }



        public Guid Id { get; set; }

        public string Name { get; set; }

        public string AssessmentType { get; set; }

        public decimal OverallMaturityScore { get; set; }


        public decimal LevelOneScore { get; set; }

        public decimal LevelTwoScore { get; set; }

        public decimal LevelThreeScore { get; set; }

        public decimal LevelFourScore { get; set; }

        public decimal LevelFiveScore { get; set; }

        public IEnumerable<AssessmentAnswer> AssessmentAnswers { get; set; }

        public string Tags { get; set; }

        public DateTime LastSnapshotDate { get; set; }

        public DateTime UpdateTimeStamp { get; set; }

        public DateTime CreateTimeStamp { get; set; }

        public string ReportType { get; set; }

        public ReportStatus Status { get; set; }







    }
}
