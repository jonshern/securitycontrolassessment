using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityControlAssessment.Model.Repositories
{
    public interface IAssessmentReportRepository : IDisposable
    {
        IEnumerable<AssessmentReport> GetAssessmentReports();
        AssessmentReport GetAssessmentReportById();

    }
}
