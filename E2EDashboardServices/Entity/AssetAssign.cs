using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2EDashboard.Entity
{
    public class AssetAssign
    {
        public decimal AssetId { get; set; }
        
        public string CustId { get; set; }

        public decimal? ProjectId { get; set; }
        
        public DateTime? AsgnmntTs { get; set; }

        public DateTime? ExpctdCmpltdDt { get; set; }

        public string LoggedInUser { get; set; }
    }
}
