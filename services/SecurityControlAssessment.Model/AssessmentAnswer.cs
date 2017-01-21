using SecurityControlAssessment.Model.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityControlAssessment.Model
{
    public class AssessmentAnswer
    {
        public AssessmentAnswer()
        { }


        public AssessmentAnswer(Guid questionId, Guid reportId, decimal controlId, int controlNumber, string questionText)
        {
            Id = Guid.NewGuid();
            QuestionId = questionId;
            AssessmentReportId = reportId;
            PolicyDefined = "No Policy";
            PolicyDefinedScore = 0;

            ControlImplemented = "Not Implemented";
            ControlImplementedScore = 0;

            ControlAutomated = "Not Automated";
            ControlAutomatedScore = 0;

            ControlReporting = "Not Reported";
            ControlReportingScore = 0;

            ControlId = controlId;
            ControlNumber = controlNumber;

            UpdateTimeStamp = DateTime.Now;
            CreateTimeStamp = DateTime.Now;

            QuestionText = questionText;


            AppliesTo = String.Empty;
            Comments = String.Empty;


        }


        public AssessmentAnswer(AssessmentAnswer answer, Guid reportId)
        {
            Id = Guid.NewGuid();
            QuestionId = answer.QuestionId;
            AssessmentReportId = reportId;
            PolicyDefined = answer.PolicyDefined;
            PolicyDefinedScore = answer.PolicyDefinedScore;

            ControlImplemented = answer.ControlImplemented;
            ControlImplementedScore = answer.ControlImplementedScore;

            ControlAutomated = answer.ControlAutomated;
            ControlAutomatedScore = answer.ControlAutomatedScore;

            ControlReporting = answer.ControlReporting;
            ControlReportingScore = answer.ControlReportingScore;

            ControlId = answer.ControlId;
            ControlNumber = answer.ControlNumber;

            UpdateTimeStamp = DateTime.Now;
            CreateTimeStamp = DateTime.Now;

            QuestionText = answer.QuestionText;


            AppliesTo = answer.AppliesTo;
            Comments = answer.Comments;


        }

        public void UpdateScore()
        {
            var scoreTable = CISControlService.GetScoringList();
            this.PolicyDefinedScore = scoreTable[this.PolicyDefined];
            this.ControlImplementedScore = scoreTable[this.ControlImplemented];
            this.ControlAutomatedScore = scoreTable[this.ControlAutomated];
            this.ControlReportingScore = scoreTable[this.ControlReporting];
        }
        


        public Guid Id { get; set; }

        public Guid AssessmentReportId { get; set; }

        public Guid QuestionId { get; set; }

        public string QuestionText { get; set; }

        public int ControlNumber { get; set; }

        public decimal ControlId { get; set; }

        public string PolicyDefined { get; set; }

        public decimal PolicyDefinedScore { get; set; }

        public string ControlImplemented { get; set; }

        public decimal ControlImplementedScore { get; set; }

        public string ControlAutomated { get; set; }

        public decimal ControlAutomatedScore { get; set; }

        public string ControlReporting { get; set; }

        public decimal ControlReportingScore { get; set; }

        public string AppliesTo { get; set; }

        public string Comments { get; set; }

        public DateTime UpdateTimeStamp { get; set; }

        public DateTime CreateTimeStamp { get; set; }



    }
}
