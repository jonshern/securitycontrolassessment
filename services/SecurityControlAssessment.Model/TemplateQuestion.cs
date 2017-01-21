using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityControlAssessment.Model
{
    public class TemplateQuestion
    {
        
        public TemplateQuestion(string id, string category, int controlNumber, decimal controlId, string detail, string nistControlFramework, string baseline)
        {

            Id = new Guid(id);
            Category = category;
            ControlNumber = controlNumber;
            ControlId = controlId;
            Detail = detail;
            NISTCoreFramework = nistControlFramework;
            Baseline = baseline;
        }

        public TemplateQuestion()
        {


        }

        public Guid Id { get; set; }
   

        public decimal ControlId { get; set; }

        public string Category { get; set; }

        public int ControlNumber { get; set; }

        public string Detail { get; set; }

        public string NISTCoreFramework { get; set; }

        public string Baseline { get; set; }

        public string Tags { get; set; }


    }
}
