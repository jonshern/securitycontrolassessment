using SecurityControlAssessment.Model;
using SecurityControlAssessment.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityControlAssessment.Services
{
    public class AssessmentReportServices
    {

        public IAssessmentReportRepository AssessmentReportRepository { get; set; }

        public AssessmentReportServices(IAssessmentReportRepository assessmentReportRepo)
        {
            AssessmentReportRepository = assessmentReportRepo;
        }


        public IEnumerable<AssessmentReport> GetAssessmentList()
        {

            return AssessmentReportRepository.GetAssessmentReports();

            

        }

      
    }
}
