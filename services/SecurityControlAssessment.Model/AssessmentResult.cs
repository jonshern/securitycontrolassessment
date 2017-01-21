using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityControlAssessment.Model
{
    public class AssessmentResult
    {
        public AssessmentResult()
        { }


        public AssessmentResult(string controlId, Guid reportId)
        {
            Id = Guid.NewGuid();
            SecurityControlId = controlId;
            AssessmentReportId = reportId;
            PolicyDefined = "No Policy";
            PolicyDefinedScore = 0;

            ControlImplemented = "Not Implemented";
            ControlImplementedScore = 0;

            ControlAutomated = "Not Automated";
            ControlAutomatedScore = 0;

            ControlReporting = "Not Reported";
            ControlReportingScore = 0;

            UpdateTimeStamp = DateTime.Now;
            CreateTimeStamp = DateTime.Now;


            AppliesTo = String.Empty;
            Risk = String.Empty;
            Effort = String.Empty;
            Mitigation = String.Empty;
            Comments = String.Empty;


        }


        public Guid Id { get; set; }

        public Guid AssessmentReportId { get; set; }

        public string SecurityControlId { get; set; }

        public string PolicyDefined { get; set; }

        public decimal PolicyDefinedScore { get; set; }

        public string ControlImplemented { get; set; }

        public decimal ControlImplementedScore { get; set; }

        public string ControlAutomated { get; set; }

        public decimal ControlAutomatedScore { get; set; }

        public string ControlReporting { get; set; }

        public decimal ControlReportingScore { get; set; }

        public string AppliesTo { get; set; }

        public string Risk { get; set; }

        public string Effort { get; set; }

        public string Mitigation { get; set; }

        public string Comments { get; set; }

        public DateTime UpdateTimeStamp { get; set; }

        public DateTime CreateTimeStamp { get; set; }


    }
}
