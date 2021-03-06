﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecurityControlAssessment.Model;
using SecurityControlAssessment.Data;
using SecurityControlAssessment.WebServices.Data;
using SecurityControlAssessment.Model.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SecurityControlAssessment.WebServices.Controllers
{
    [Route("api/[controller]")]
    public class AssessmentReportController : Controller
    {

        private AssessmentContext _context;


        public AssessmentReportController(AssessmentContext context)
        {
            _context = context;
        }




        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<AssessmentReport>> Get()
        {

            //DocDbRepository docDbRepo = new DocDbRepository();
            //var reports = await docDbRepo.GetAssessmentReports();

            //return reports;

            EntityFrameworkRepository dataRepo = new EntityFrameworkRepository(_context);
            return dataRepo.GetAssessmentReports();


            
        }


        // GET: api/values
        [HttpGet("GetScoreReport")]
        public IEnumerable<AssessmentReportDetail> GetScoreReport(Guid id)
        {

            //DocDbRepository docDbRepo = new DocDbRepository();
            //var reports = await docDbRepo.GetAssessmentReports();

            //return reports;

            EntityFrameworkRepository dataRepo = new EntityFrameworkRepository(_context);
            return dataRepo.GetSnapshotReport(id);



        }





        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<AssessmentReport> Get(Guid id)
        {

            EntityFrameworkRepository dataRepository = new EntityFrameworkRepository(_context);
            return dataRepository.GetAssessmentReportById(id);

            //DocDbRepository docDbRepo = new DocDbRepository();
            //var report = await docDbRepo.GetAssessmentReportById(id);

            //return report;

        }
        [Route("CreateReportSnapshot/{id}")]
        [HttpPost()]
        public void Post(Guid id, [FromBody]string comments)
        {


            EntityFrameworkRepository dataRepository = new EntityFrameworkRepository(_context);

            dataRepository.CreateReportSnapshot(id, comments);


        }







        [HttpPost]
        public AssessmentReport Post([FromBody]AssessmentReport report)
        {

            if (report == null)
                return null;

            report.AssessmentType = "CIS Controls 6.0";
            report.Tags = "default";

            AssessmentFactory factory = new AssessmentFactory();

            AssessmentReport assessmentReport = factory.Create(report.Name, report.AssessmentType, report.Tags);


            EntityFrameworkRepository dataRepository = new EntityFrameworkRepository(_context);

            dataRepository.CreateAssessmentReport(assessmentReport);


            //DocDbRepository docDbRepo = new DocDbRepository();
            //docDbRepo.CreateAssessmentReport(assessmentReport);

            return assessmentReport;
        }





        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
