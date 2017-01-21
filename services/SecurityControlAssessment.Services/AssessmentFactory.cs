using SecurityControlAssessment.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityControlAssessment.Services
{
    public class AssessmentFactory
    {


        public AssessmentReport CreateReport(string name, string type)
        {



            return new AssessmentReport();

        }
    }
}
