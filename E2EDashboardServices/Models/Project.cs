using System;
using System.Collections.Generic;

#nullable disable

namespace E2EDashboardServices.Models
{
    public partial class Project
    {
        public decimal ProjectId { get; set; }
        public decimal OpprtntyId { get; set; }
        public decimal BatchClassId { get; set; }
        public string ProjectNm { get; set; }
        public DateTime? AdtCrtDt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? AdtUpdtDt { get; set; }
        public string ModifiedBy { get; set; }
        public string ProjectVisibilityFlag { get; set; }
        public string IsSca { get; set; }

        public virtual BatchClass BatchClass { get; set; }
    }
}
