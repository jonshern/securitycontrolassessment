using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityControlAssessment.Model
{
    public class AssessmentReportDetail
    {

        public AssessmentReportDetail(AssessmentReport report, ReportSnapshot snapshot)
        {
            this.OverallMaturityScore = report.OverallMaturityScore;
            this.LevelOneScore = report.LevelOneScore;
            this.LevelTwoScore = report.LevelTwoScore;
            this.LevelThreeScore = report.LevelThreeScore;
            this.LevelFourScore = report.LevelFourScore;
            this.LevelFiveScore = report.LevelFiveScore;
            this.LastSnapshotDate = snapshot.SnapshotDate;
            this.SnapshotComment = snapshot.Comments;
        }

        public decimal OverallMaturityScore { get; set; }

        public decimal LevelOneScore { get; set; }

        public decimal LevelTwoScore { get; set; }

        public decimal LevelThreeScore { get; set; }

        public decimal LevelFourScore { get; set; }

        public decimal LevelFiveScore { get; set; }

        public DateTime LastSnapshotDate { get; set; }

        public string SnapshotComment { get; set; }
    }
}
