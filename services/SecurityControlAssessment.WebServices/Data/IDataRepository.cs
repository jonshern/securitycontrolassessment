using SecurityControlAssessment.Data;
using SecurityControlAssessment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityControlAssessment.WebServices.Data
{


    public interface IDataRepository
    {
        Task<AssessmentReport> GetAssessmentReportById(Guid id);

        void CreateAssessmentReport(AssessmentReport report);

    }




}
