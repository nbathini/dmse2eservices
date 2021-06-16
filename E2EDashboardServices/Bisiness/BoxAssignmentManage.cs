using System;
using E2EDashboard.Entity;
using E2EDashboard.DataAccess;
using System.Collections.Generic;

namespace E2EDashboard.Business
{
    public class BoxAssignmentManage
    {
        private BoxAssignmentDA assignmentDA = new BoxAssignmentDA();

        public List<AssetInquiry> GetBoxAssignmentDetails(AssetSearch assetSearch)
        {
            return this.assignmentDA.GetBoxAssignmentDetails(assetSearch);
        }

        public int SetAssignByAssetId(AssetAssign assetAssign)
        {
            return this.assignmentDA.SetAssignByAssetId(assetAssign);
        }

        public int DeleteAsset(DeleteAsset deleteAsset)
        {
            return this.assignmentDA.DeleteAsset(deleteAsset);
        }

        public int GetNextAssetSequenceValue()
        {
            return this.assignmentDA.GetNextAssetSequenceValue();
        }
    }
}
