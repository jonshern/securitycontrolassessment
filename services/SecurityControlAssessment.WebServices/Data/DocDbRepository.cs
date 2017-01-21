using SecurityControlAssessment.Data;
using SecurityControlAssessment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityControlAssessment.WebServices.Data
{
    public class DocDbRepository
    {

        public async void CreateAssessmentReport(AssessmentReport report)
        {


            DocumentDBRepository<AssessmentReport>.Initialize();

            await DocumentDBRepository<AssessmentReport>.CreateItemAsync(report);


        }


        public async Task<AssessmentReport> GetAssessmentReportById(Guid id)
        {
            DocumentDBRepository<AssessmentReport>.Initialize();

            var report =  await DocumentDBRepository<AssessmentReport>.GetItemAsync(id.ToString());

            return report;

        }



        public async Task<IEnumerable<AssessmentAnswer>> GetAssessmentAnswers(Guid assessmentReportId)
        {
            DocumentDBRepository<AssessmentReport>.Initialize();

            var report = await DocumentDBRepository<AssessmentAnswer>.GetItemsAsync(d => d.AssessmentReportId == assessmentReportId);

            return report;

        }


        public async Task<IEnumerable<AssessmentReport>> GetAssessmentReports()
        {
            DocumentDBRepository<AssessmentReport>.Initialize();

            var reports = await DocumentDBRepository<AssessmentReport>.GetItemsAsync();

            return reports;

        }


        public async void DeleteAssessmentReport(Guid id)
        {
            DocumentDBRepository<AssessmentReport>.Initialize();
            await DocumentDBRepository<AssessmentReport>.DeleteItemAsync(id.ToString());
  
        }


        //public async void UpdateAssessmentAnswer(Guid id)
        //{
        //    DocumentDBRepository<AssessmentReport>.Initialize();
        //    await DocumentDBRepository<AssessmentReport>.DeleteItemAsync(id.ToString());

        //}


    }
}
