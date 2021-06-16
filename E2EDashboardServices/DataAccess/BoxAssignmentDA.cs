using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using E2EDashboard.Entity;
using E2EDashboard.Utility;

namespace E2EDashboard.DataAccess
{
    public class BoxAssignmentDA
    {
        public List<AssetInquiry> GetBoxAssignmentDetails(AssetSearch assetSearch)
        {
            SqlDataReader reader = null;
            List<AssetInquiry> assetInquiries = new List<AssetInquiry>();
            AssetInquiry assetInquiry;

            reader = SqlHelper.ExecuteReader(AppConfig.ConnectionString, CommandType.StoredProcedure, "SP_API_GETBOXASSIGNMENTDETAILS", CreateAssetSearchParameter(assetSearch));

            while (reader.Read())
            {
                assetInquiry = new AssetInquiry();
                ReadBoxAssignmentDetails(reader, ref assetInquiry);
                assetInquiries.Add(assetInquiry);
            }

            return assetInquiries;
        }

        public int SetAssignByAssetId(AssetAssign assetAssign)
        {
            int res = SqlHelper.ExecuteNonQuery(AppConfig.ConnectionString, CommandType.StoredProcedure, "SP_E2EAT_ASSET_ASSIGN_BY_ID", CreateAssetAssignParameter(assetAssign));

            return res;
        }

        public int DeleteAsset(DeleteAsset deleteAsset)
        {
            int res = SqlHelper.ExecuteNonQuery(AppConfig.ConnectionString, CommandType.StoredProcedure, "DELETE_ASSET", new SqlParameter("@BOXNUMBER", deleteAsset.BoxNbr));

            return res;
        }

        public int GetNextAssetSequenceValue()
        {
            int res = SqlHelper.ExecuteReturnInt(AppConfig.ConnectionString, CommandType.StoredProcedure, "SP_API_GETNEXTASSETSEQUENCEVALUE");

            return res;
        }

        internal static void ReadBoxAssignmentDetails(SqlDataReader reader, ref AssetInquiry assetInquiry)
        {
            if (!reader.IsDBNull(reader.GetOrdinal("ASSET_ID")))
                assetInquiry.AssetId = reader.GetDecimal(reader.GetOrdinal("ASSET_ID"));

            if (!reader.IsDBNull(reader.GetOrdinal("SKP_ORDR_NBR")))
                assetInquiry.SkpOrdrNbr = reader.GetString(reader.GetOrdinal("SKP_ORDR_NBR"));

            if (!reader.IsDBNull(reader.GetOrdinal("BOX_NBR")))
                assetInquiry.BoxNbr = reader.GetString(reader.GetOrdinal("BOX_NBR"));

            if (!reader.IsDBNull(reader.GetOrdinal("CUST_ACNT_NBR")))
                assetInquiry.CustAcntNbr = reader.GetString(reader.GetOrdinal("CUST_ACNT_NBR"));

            if (!reader.IsDBNull(reader.GetOrdinal("STATUS")))
                assetInquiry.Status = reader.GetDecimal(reader.GetOrdinal("STATUS"));

            if (!reader.IsDBNull(reader.GetOrdinal("PROJECT_NM")))
                assetInquiry.ProjectNm = reader.GetString(reader.GetOrdinal("PROJECT_NM"));

            if (!reader.IsDBNull(reader.GetOrdinal("BATCH_CLASS_NM")))
                assetInquiry.BatchClassNm = reader.GetString(reader.GetOrdinal("BATCH_CLASS_NM"));

            if (!reader.IsDBNull(reader.GetOrdinal("EXPCTD_CMPLTD_DT")))
                assetInquiry.ExpctdCmpltdDt = reader.GetDateTime(reader.GetOrdinal("EXPCTD_CMPLTD_DT"));

            if (!reader.IsDBNull(reader.GetOrdinal("DSTRCT_ID")))
                assetInquiry.DstrctId = reader.GetString(reader.GetOrdinal("DSTRCT_ID"));

            if (!reader.IsDBNull(reader.GetOrdinal("DSTRCT_NM")))
                assetInquiry.DstrctNm = reader.GetString(reader.GetOrdinal("DSTRCT_NM"));

            if (!reader.IsDBNull(reader.GetOrdinal("ADT_CRT_DT")))
                assetInquiry.AdtCrtDt = reader.GetDateTime(reader.GetOrdinal("ADT_CRT_DT"));

            if (!reader.IsDBNull(reader.GetOrdinal("IMG_COUNT")))
                assetInquiry.ImgCount = reader.GetInt32(reader.GetOrdinal("IMG_COUNT"));

            if (!reader.IsDBNull(reader.GetOrdinal("RELEASEDBATCHES")))
                assetInquiry.ReleasedBatches = reader.GetInt32(reader.GetOrdinal("RELEASEDBATCHES"));

            if (!reader.IsDBNull(reader.GetOrdinal("TOTBATCHES")))
                assetInquiry.TotBatches = reader.GetInt32(reader.GetOrdinal("TOTBATCHES"));

            if (!reader.IsDBNull(reader.GetOrdinal("CMPLTD_DT")))
                assetInquiry.CmpltdDt = reader.GetDateTime(reader.GetOrdinal("CMPLTD_DT"));
        }

        private static SqlParameter[] CreateAssetSearchParameter(AssetSearch assetSearch)
        {
            SqlParameter[] param = new SqlParameter[7];
            int iPos = 0;
            param[iPos++] = new SqlParameter("@" + AssetSearch.FromDt_Label, assetSearch.FromDt);
            param[iPos++] = new SqlParameter("@" + AssetSearch.ToDt_Label, assetSearch.ToDt);
            param[iPos++] = new SqlParameter("@" + AssetSearch.DstrctId_Label, assetSearch.DstrctId);
            param[iPos++] = new SqlParameter("@" + AssetSearch.CustId_Label, assetSearch.CustId);
            param[iPos++] = new SqlParameter("@" + AssetSearch.BoxStatus_Label, assetSearch.BoxStatus);
            param[iPos++] = new SqlParameter("@" + AssetSearch.SkpOrdrNbr_Label, assetSearch.SkpOrdrNbr);
            param[iPos++] = new SqlParameter("@" + AssetSearch.BoxNbr_Label, assetSearch.BoxNbr);
            return param;
        }

        private static SqlParameter[] CreateAssetAssignParameter(AssetAssign assetAssign)
        {
            SqlParameter[] param = new SqlParameter[6];
            int iPos = 0;
            param[iPos++] = new SqlParameter("@ASSET_ID_IN", assetAssign.AssetId);
            param[iPos++] = new SqlParameter("@CUST_ACNT_NBR_IN", assetAssign.CustId);
            param[iPos++] = new SqlParameter("@PROJECT_ID_IN", assetAssign.ProjectId);
            param[iPos++] = new SqlParameter("@ASGNMNT_TS_IN", assetAssign.AsgnmntTs);
            param[iPos++] = new SqlParameter("@EXPCTD_CMPLTD_DT_IN", assetAssign.ExpctdCmpltdDt);
            param[iPos++] = new SqlParameter("@MODIFIED_BY_IN", assetAssign.LoggedInUser);
            return param;
        }
    }
}
