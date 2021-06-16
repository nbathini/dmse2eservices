using System;
using System.Collections.Generic;

#nullable disable

namespace E2EDashboardServices.Models
{
    public partial class Asset
    {
        public decimal AssetId { get; set; }
        public string DstrctId { get; set; }
        public decimal? ProjectId { get; set; }
        public string BoxNbr { get; set; }
        public string SkpOrdrNbr { get; set; }
        public DateTime? AsgnmntTs { get; set; }
        public DateTime? ExpctdCmpltdDt { get; set; }
        public decimal? CmpltdFlg { get; set; }
        public DateTime? CmpltdDt { get; set; }
        public decimal Status { get; set; }
        public DateTime AdtCrtDt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? AdtUpdtDt { get; set; }
        public string ModifiedBy { get; set; }
        public string CustAcntNbr { get; set; }
        public string ReportId { get; set; }
        public string ParentBoxNbr { get; set; }
        public string Isdeleted { get; set; }
        public string Subbtchhdr { get; set; }
    }
}
