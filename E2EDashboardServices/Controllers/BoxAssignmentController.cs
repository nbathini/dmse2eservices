using E2EDashboardServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using E2EDashboard.Entity;
using E2EDashboard.DataAccess;
using E2EDashboard.Business;
using E2EDashboard.Utility;
using System.Resources;
using System.Globalization;
using System.Reflection;

namespace E2EDashboardServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoxAssignmentController : ControllerBase
    {
        #region Private Veriables
        private readonly E2EDASHBOARDContext _e2eDASHBOARDContext;

        private readonly ILogger<BoxAssignmentController> _logger;
        #endregion

        #region Box Assignment Controller Constructor
        public BoxAssignmentController(E2EDASHBOARDContext eDASHBOARDContext, ILogger<BoxAssignmentController> logger)
        {
            _e2eDASHBOARDContext = eDASHBOARDContext;
            _logger = logger;
        }

        #endregion

        #region Commented EF model call to fetch Boxes details
        //[HttpPost("GetBoxAssignmentDetails")]
        //public IEnumerable<E2EDashboardServices.Models.AssetInquiry> GetBoxAssignmentDetails(E2EDashboardServices.Models.AssetSearch assetSearch)
        //{

        //    var _assetInquiry = (from a in _e2eDASHBOARDContext.Assets
        //                         join p in _e2eDASHBOARDContext.Projects
        //                            on a.ProjectId equals p.ProjectId into aaa
        //                         from aa in aaa.DefaultIfEmpty()
        //                         join b in _e2eDASHBOARDContext.BatchClasses
        //                            on aa.BatchClassId equals b.BatchClassId into bbb
        //                         from bb in bbb.DefaultIfEmpty()
        //                         join l in _e2eDASHBOARDContext.Locations
        //                            on a.DstrctId equals l.LocationId
        //                         join c in _e2eDASHBOARDContext.Customers
        //                            on a.CustAcntNbr equals c.Custid
        //                         where a.CreatedBy != "SP_BATCH_HDR_CREATE"
        //                         && a.AdtCrtDt > DateTime.Now.AddDays(-365)

        //                         && ((assetSearch.FromDt != null && !string.IsNullOrEmpty(assetSearch.FromDt.Value.ToString())) ? (true) : (a.AdtCrtDt >= assetSearch.FromDt))
        //                         && ((assetSearch.ToDt != null && !string.IsNullOrEmpty(assetSearch.ToDt.Value.ToString())) ? (true) : (a.AdtCrtDt <= assetSearch.ToDt))
        //                         && (string.IsNullOrEmpty(assetSearch.DstrctId) ? (true) : (a.DstrctId.Equals(assetSearch.DstrctId)))
        //                         && (string.IsNullOrEmpty(assetSearch.CustId) ? (true) : (a.CustAcntNbr == assetSearch.CustId))
        //                         && (assetSearch.BoxStatus == null ? (true) : (a.Status == assetSearch.BoxStatus))
        //                         && (string.IsNullOrEmpty(assetSearch.SkpOrdrNbr) ? (true) : (a.SkpOrdrNbr.Equals(assetSearch.SkpOrdrNbr)))
        //                         && (string.IsNullOrEmpty(assetSearch.BoxNbr) ? (true) : (a.BoxNbr.Equals(assetSearch.BoxNbr)))



        //                         select new E2EDashboardServices.Models.AssetInquiry
        //                         {
        //                             AssetId = a.AssetId,
        //                             SkpOrdrNbr = a.SkpOrdrNbr,
        //                             BoxNbr = a.BoxNbr,
        //                             CustAcntNbr = a.CustAcntNbr,
        //                             CustNm = c.Customername,
        //                             Status = a.Status,
        //                             ProjectNm = aa.ProjectNm,
        //                             BatchClassNm = bb.BatchClassNm,
        //                             ExpctdCmpltdDt = a.ExpctdCmpltdDt,
        //                             DstrctId = a.DstrctId,
        //                             DstrctNm = l.LocationName,
        //                             AdtCrtDt = a.AdtCrtDt,
        //                             ImgCount = 10,
        //                             ReleasedBatches = 10,
        //                             TotBatches = 10,
        //                             CmpltdDt = a.CmpltdDt
        //                         }).ToList<E2EDashboardServices.Models.AssetInquiry>();

        //    return _assetInquiry;

        //}
        #endregion

        #region Get Boxes Details API based on given search criteria
        [HttpGet("GetBoxes"), HttpPost("GetBoxes")]
        public ReturnObject GetBoxes(AssetSearch assetSearch)
        {
            #region HttpContext Items
            HttpContext.Items.Add(Convert.ToString(HttpContextItem.LoggedInUser), assetSearch.LoggedInUser);
            HttpContext.Items.Add(Convert.ToString(HttpContextItem.ActionType), Convert.ToString(ActionType.GET));
            #endregion

            ReturnObject returnObject = ValidateAPIRequest.ValidateRequest(assetSearch, Convert.ToString(APIRequestMethodName.GetBoxs));

            if (returnObject.success)
            {
                ServiceResponse response = new ServiceResponse();

                var assetInquiries = new BoxAssignmentManage().GetBoxAssignmentDetails(assetSearch);

                returnObject = response.sendSuccessMessage();
                returnObject.result = assetInquiries;

                return returnObject;
            }
            else
            {
                return returnObject;
            }            

        }
        #endregion

        #region Add New Box API
        [HttpPost("AddNewBox")]
        public async Task<ReturnObject> AddNewBox(AddAsset addAsset)
        {
            #region HttpContext Items
            HttpContext.Items.Add(Convert.ToString(HttpContextItem.LoggedInUser), addAsset.LoggedInUser);
            HttpContext.Items.Add(Convert.ToString(HttpContextItem.ActionType), Convert.ToString(ActionType.ADD));
            #endregion

            ReturnObject returnObject = ValidateAPIRequest.ValidateRequest(addAsset, Convert.ToString(APIRequestMethodName.AddNewBox));

            if (returnObject.success)
            {
                ServiceResponse response = new ServiceResponse();

                Asset asset = new Asset();
                BoxAssignmentManage boxAssignmentManage = new BoxAssignmentManage();
                asset.AssetId = boxAssignmentManage.GetNextAssetSequenceValue();
                asset.DstrctId = addAsset.DstrctId;
                asset.CustAcntNbr = addAsset.CustAcntNbr;
                asset.BoxNbr = addAsset.BoxNbr;
                asset.SkpOrdrNbr = addAsset.SkpOrdrNbr;
                asset.AsgnmntTs = DateTime.UtcNow;
                asset.CmpltdFlg = (int)BoxCompleteStatus.NotCompleted;
                asset.Status = (int)BoxStatus.UnAssign;
                asset.AdtCrtDt = DateTime.UtcNow;
                asset.CustAcntNbr = addAsset.CustAcntNbr;
                asset.Isdeleted = BoxDeleteStatus.N.ToString();
                asset.CreatedBy = addAsset.LoggedInUser;

                _e2eDASHBOARDContext.Assets.Add(asset);
                await _e2eDASHBOARDContext.SaveChangesAsync();

                var _asset = _e2eDASHBOARDContext.Assets.Where(e => e.AssetId == asset.AssetId).FirstOrDefault();

                returnObject = response.sendSuccessMessage();
                returnObject.result = _asset;

                return returnObject;
            }
            else
            {
                return returnObject;
            }

            
        }
        #endregion

        #region Box Assignment API (Changing Box Status From "Unassigned" to "Assign")
        [HttpPost("EditBox")]
        public async Task<ReturnObject> EditBox(AssetAssign assetAssign)
        {
            #region HttpContext Items
            HttpContext.Items.Add(Convert.ToString(HttpContextItem.LoggedInUser), assetAssign.LoggedInUser);
            HttpContext.Items.Add(Convert.ToString(HttpContextItem.ActionType), Convert.ToString(ActionType.EDIT));
            #endregion

            ReturnObject returnObject = ValidateAPIRequest.ValidateRequest(assetAssign, Convert.ToString(APIRequestMethodName.EditBox));

            if (returnObject.success)
            {
                ServiceResponse response = new ServiceResponse();

                if (assetAssign.AsgnmntTs == null)
                    assetAssign.AsgnmntTs = DateTime.UtcNow;

                int res = new BoxAssignmentManage().SetAssignByAssetId(assetAssign);

                await _e2eDASHBOARDContext.SaveChangesAsync();

                var _asset = _e2eDASHBOARDContext.Assets.Where(e => e.AssetId == assetAssign.AssetId).FirstOrDefault();

                returnObject = response.sendSuccessMessage();
                returnObject.result = _asset;

                return returnObject;
            }
            else
            {
                return returnObject;
            }
            
        }
        #endregion

        #region Complete Box API
        [HttpPost("CompleteBox")]
        public async Task<ReturnObject> CompleteBox(CompleteAsset completeAsset)
        {
            #region HttpContext Items
            HttpContext.Items.Add(Convert.ToString(HttpContextItem.LoggedInUser), completeAsset.LoggedInUser);
            HttpContext.Items.Add(Convert.ToString(HttpContextItem.ActionType), Convert.ToString(ActionType.EDIT));
            #endregion

            ReturnObject returnObject = ValidateAPIRequest.ValidateRequest(completeAsset, Convert.ToString(APIRequestMethodName.CompleteBox));

            if (returnObject.success)
            {
                ServiceResponse response = new ServiceResponse();

                var _asset = _e2eDASHBOARDContext.Assets.Where(e => e.BoxNbr == completeAsset.BoxNbr).FirstOrDefault();

                _asset.CmpltdFlg = (int)BoxCompleteStatus.Completed;
                _asset.CmpltdDt = DateTime.UtcNow;
                _asset.Status = (int)BoxStatus.Completed;
                _asset.ModifiedBy = completeAsset.LoggedInUser;
                _asset.AdtUpdtDt = DateTime.UtcNow;
                _e2eDASHBOARDContext.Assets.Update(_asset);
                await _e2eDASHBOARDContext.SaveChangesAsync();

                returnObject = response.sendSuccessMessage();

                var _asset_new = _e2eDASHBOARDContext.Assets.Where(e => e.AssetId == _asset.AssetId).FirstOrDefault();

                returnObject.result = _asset_new;

                return returnObject;
            }
            else
            {
                return returnObject;
            }
            
        }
        #endregion

        #region Delete Box API
        [HttpDelete("DeleteBox")]
        public async Task<ReturnObject> DeleteBox(DeleteAsset deleteAsset)
        {
            #region HttpContext Items
            HttpContext.Items.Add(Convert.ToString(HttpContextItem.LoggedInUser), deleteAsset.LoggedInUser);
            HttpContext.Items.Add(Convert.ToString(HttpContextItem.ActionType), Convert.ToString(ActionType.DELETE));
            #endregion

            ReturnObject returnObject = ValidateAPIRequest.ValidateRequest(deleteAsset, Convert.ToString(APIRequestMethodName.DeleteBox));

            if (returnObject.success)
            {
                ServiceResponse response = new ServiceResponse();

                var _asset = _e2eDASHBOARDContext.Assets.Where(e => e.BoxNbr == deleteAsset.BoxNbr).FirstOrDefault();

                if (_asset != null)
                {
                    int res = new BoxAssignmentManage().DeleteAsset(deleteAsset);

                    await _e2eDASHBOARDContext.SaveChangesAsync();

                    returnObject = response.sendSuccessMessage();

                    returnObject.result = null;

                    return returnObject;
                }
                else
                {
                    returnObject = response.sendRequestFailedMessage();
                    ErrorMessage errorMessage = new ErrorMessage();
                    errorMessage.Code = Convert.ToString(ValidationCode.V005);
                    errorMessage.Message = ValidateAPIRequest.ValidateRequest(deleteAsset, APIRequestMethodName.DeleteBox.ToString()) + deleteAsset.BoxNbr;
                    returnObject.errors = new List<ErrorMessage>();
                    returnObject.errors.Add(errorMessage);
                    returnObject.result = null;

                    return returnObject;
                }
            }
            else
            {
                return returnObject;
            }
            
        }
        #endregion

    }
}
