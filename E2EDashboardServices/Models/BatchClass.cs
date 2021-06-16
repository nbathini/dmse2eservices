using System;
using System.Collections.Generic;

#nullable disable

namespace E2EDashboardServices.Models
{
    public partial class BatchClass
    {
        public BatchClass()
        {
            Projects = new HashSet<Project>();
        }

        public decimal BatchClassId { get; set; }
        public string BatchClassNm { get; set; }
        public decimal ActiveFlg { get; set; }
        public string JobSpecificationLink { get; set; }
        public string WorkflowLink { get; set; }
        public string Type { get; set; }
        public string Version { get; set; }
        public string GsJobId { get; set; }
        public DateTime? DatePublished { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? LastRunDate { get; set; }
        public DateTime? GsRunDate { get; set; }
        public string MultilineFlag { get; set; }
        public string PrintsowFlag { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
