using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecurityControlAssessment.Model;
using SecurityControlAssessment.WebServices.Data;
using SecurityControlAssessment.Data;
using SecurityControlAssessment.Model.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SecurityControlAssessment.WebServices.Controllers
{
    [Route("api/[controller]")]
    public class AssessmentAnswerController : Controller
    {

        private AssessmentContext _context;


        public AssessmentAnswerController(AssessmentContext context)
        {
            _context = context;
        }





        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<AssessmentAnswer> Get(Guid id)
        {
            //DocDbRepository docDbRepo = new DocDbRepository();
    
            //var report = await docDbRepo.GetAssessmentAnswers(id);
            
            //return report;


            EntityFrameworkRepository dataRepository = new EntityFrameworkRepository(_context);

            return dataRepository.GetAssessmentAnswer(id);

        }


        //// PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]AssessmentAnswer value)
        {

            EntityFrameworkRepository dataRepository = new EntityFrameworkRepository(_context);

            value.UpdateScore();

       
            dataRepository.SaveAssessmentAnswers(id, value);


            var report = dataRepository.GetAssessmentReportById(value.AssessmentReportId);


            CISControlService.UpdateAssessmentScore(report);

            dataRepository.SaveAssessmentReport(report);
           
        }


        //// PUT api/values/5
        [HttpPost]
        public void Post([FromBody]AssessmentAnswer value)
        {

            EntityFrameworkRepository dataRepository = new EntityFrameworkRepository(_context);

            value.UpdateScore();

            dataRepository.SaveAssessmentAnswers(value.Id, value);

            //return value;
        }

    }
}
