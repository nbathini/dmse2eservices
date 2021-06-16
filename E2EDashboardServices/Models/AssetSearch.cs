using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E2EDashboardServices.Models
{
    public class AssetSearch
    {
        public DateTime? FromDt { get; set; }
        public DateTime? ToDt { get; set; }
        public string DstrctId { get; set; }
        public string CustId { get; set; }
        public string CustName { get; set; }
        public decimal? BoxStatus { get; set; }
        public string SkpOrdrNbr { get; set; }
        public string BoxNbr { get; set; }
        
    }
}
