using System;
using System.Collections.Generic;
using System.Text;

using SecurityControlAssessment.Model;

namespace SecurityControlAssessment.Model.Services
{
    public class AssessmentFactory
    {

        public AssessmentReport Create(string name, string template, string tags)
        {
            var assessmentReport = new AssessmentReport(name, template, tags);

            //TODO put different types of assessments in here.
            //if (template == "CIS Controls 6.0")
            assessmentReport.AssessmentAnswers = CISControlService.LoadDefaultSecurityControls(assessmentReport.Id);
            
          




            return assessmentReport;


        }
    }
}
