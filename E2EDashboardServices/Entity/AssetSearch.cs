using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2EDashboard.Entity
{
    public class AssetSearch
    {
        #region Static Parameters
        public static string FromDt_Label = "FromDt";
        public static string ToDt_Label = "ToDt";
        public static string DstrctId_Label = "DstrctId";
        public static string CustId_Label = "CustId";
        public static string BoxStatus_Label = "BoxStatus";
        public static string SkpOrdrNbr_Label = "SkpOrdrNbr";
        public static string BoxNbr_Label = "BoxNbr";
        #endregion

        public DateTime? FromDt { get; set; }
        public DateTime? ToDt { get; set; }
        public string DstrctId { get; set; }
        public string CustId { get; set; }
        //public string CustName { get; set; }
        public decimal? BoxStatus { get; set; }
        public string SkpOrdrNbr { get; set; }
        public string BoxNbr { get; set; }
        public string LoggedInUser { get; set; }
    }
}
