using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E2EDashboard.API.Core.Models
{
    public class AssetAssign
    {
        public decimal AssetId { get; set; }

        public string CustId { get; set; }

        public string ProjectId { get; set; }

        public DateTime? AsgnmntTs { get; set; }
        public DateTime? ExpctdCmpltdDt { get; set; }

        public string ModifiedBy { get; set; }
    }
}
