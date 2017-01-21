using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecurityControlAssessment.Model;
using SecurityControlAssessment.WebServices.Data;
using SecurityControlAssessment.Model.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SecurityControlAssessment.WebServices.Controllers
{
    [Route("api/[controller]")]
    public class TemplateQuestionController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<TemplateQuestion> Get()
        {
            return CISControlService.LoadDefaultSecurityQuestions();
        }


    }
}
