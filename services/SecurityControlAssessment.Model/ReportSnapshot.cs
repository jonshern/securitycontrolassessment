using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityControlAssessment.Model
{
    public class ReportSnapshot
    {
        public Guid Id { get; set; }

        public Guid OriginReportId { get; set; }

        public Guid SnapshotReportId { get; set; }

        public DateTime SnapshotDate { get; set; }

        public string Comments { get; set; }

        public string SavedBy { get; set; }


  
    }
}
