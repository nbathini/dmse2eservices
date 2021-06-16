using System;

namespace E2EDashboard.Entity
{
    public class AssetInquiry
    {
        public decimal AssetId { get; set; }

        public string SkpOrdrNbr { get; set; }

        public string BoxNbr { get; set; }

        public string CustAcntNbr { get; set; }

        public string CustNm { get; set; }

        public decimal Status { get; set; }

        public string ProjectNm { get; set; }

        public string BatchClassNm { get; set; }

        public DateTime? ExpctdCmpltdDt { get; set; }

        public string DstrctId { get; set; }

        public string DstrctNm { get; set; }

        public DateTime AdtCrtDt { get; set; }

        public int ImgCount { get; set; }

        public int ReleasedBatches { get; set; }

        public int TotBatches { get; set; }

        public DateTime? CmpltdDt { get; set; }
    }
}
