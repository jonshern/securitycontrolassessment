using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityControlAssessment.Model
{
    public class AssessmentScore
    {
        public int ControlNumber { get; set; }

        public decimal PolicyDefinedScore { get; set; }

        public decimal ControlImplementedScore { get; set; }


        public decimal ControlAutomatedScore { get; set; }

        public decimal ControlReportingScore { get; set; }

        public int NumberOfQuestions { get; set; }


        public decimal AveragePolicyScore {
            get
            {
                return PolicyDefinedScore / NumberOfQuestions;

            }
        }

        public decimal AverageImplementationScore {
            get
            {
                return ControlImplementedScore / NumberOfQuestions;
          
            }
        }

        public decimal AverageAutomationScore {
            get
            {
                return ControlAutomatedScore / NumberOfQuestions;
            }
        }

        public decimal AverageReportingScore {

            get
            {
                return ControlReportingScore / NumberOfQuestions;

            }

        }


    }

}
