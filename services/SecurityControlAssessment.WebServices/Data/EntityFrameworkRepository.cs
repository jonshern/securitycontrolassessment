using SecurityControlAssessment.Data;
using SecurityControlAssessment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityControlAssessment.WebServices.Data
{
    public class EntityFrameworkRepository
    {
        private AssessmentContext _context;
        public EntityFrameworkRepository(AssessmentContext context)
        {
            _context = context;
        }


        public void CreateAssessmentReport(AssessmentReport report)
        {
            _context.Add(report);

            _context.SaveChanges();

        }


        public AssessmentReport GetAssessmentReportById(Guid id)
        {


            var report = (from r in _context.AssessmentReports
                          where r.Id == id
                          select r).FirstOrDefault();

            if (report != null)
            {


                var items = (from i in _context.AssessmentAnswers
                             where i.AssessmentReportId == id
                             orderby i.ControlId ascending 
                             select i).ToList();

                report.AssessmentAnswers = items;

            }

            return report;

        }


        public void CreateReportSnapshot(Guid id, string comment)
        {
            var report = GetAssessmentReportById(id);


            //Do a Deep Copy to save the report as a snapshot status.
            AssessmentReport reportSnapshot = new AssessmentReport(report, "Snapshot");
    




            ReportSnapshot snapshot = new ReportSnapshot();

            snapshot.Id = Guid.NewGuid();
            snapshot.OriginReportId = report.Id;
            snapshot.SavedBy = "someone";
            snapshot.SnapshotDate = DateTime.Now;
            snapshot.Comments = comment;
            snapshot.SnapshotReportId = reportSnapshot.Id ;
;
            _context.AssessmentReports.Add(reportSnapshot);

            _context.SaveChanges();



        }


        public IEnumerable<AssessmentReportDetail> GetSnapshotReport(Guid id)
        {
            IEnumerable<AssessmentReportDetail> details = new List<AssessmentReportDetail>();


            var item = (from i in _context.ReportSnapshots
                       join p in _context.AssessmentReports on i.OriginReportId equals p.Id
                       where i.OriginReportId == id
                       select new AssessmentReportDetail(p, i));

            return item;
        }


        public void SaveAssessmentAnswers(Guid id, AssessmentAnswer answer)
        {

            answer.UpdateTimeStamp = DateTime.Now;

            _context.Update<AssessmentAnswer>(answer);

            _context.SaveChanges();

        }


        public void SaveAssessmentReport(AssessmentReport report)
        {

            report.UpdateTimeStamp = DateTime.Now;

            _context.Update<AssessmentReport>(report);

            _context.SaveChanges();

        }


        public AssessmentAnswer GetAssessmentAnswer(Guid answerId)
        {


            var item = (from i in _context.AssessmentAnswers
                         where i.Id == answerId
                         select i).FirstOrDefault();



            return item;

        }



        //public IEnumerable<TemplateQuestion> GetTemplateQuestions()
        //{


        //    var items = (from i in _context.TemplateQuestions
        //                 where i.AssessmentReportId == reportId
        //                 select i).ToList();



        //    return items;

        //}



        public IEnumerable<AssessmentReport> GetAssessmentReports()
        {

            var reports = (from i in _context.AssessmentReports
                        where i.ReportType == "Active"
                        select i);


            //foreach(AssessmentReport report in reports)
            //{
            //    var items = (from i in _context.AssessmentAnswers
            //                 where i.AssessmentReportId == report.Id
            //                 select i).ToList();

            //    report.AssessmentAnswers = items;

            //}


            return reports.ToList();
        }




    }
}
