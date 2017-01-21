using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityControlAssessment.Model
{
    public class AssessmentTemplate
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<TemplateQuestion> Questions  { get; set; }

    }
}
