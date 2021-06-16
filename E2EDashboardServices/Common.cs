using E2EDashboard.Entity;
using E2EDashboard.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2EDashboardServices
{
    public class ValidateAPIRequest
    {
        public static ReturnObject ValidateRequest(object objEntity, string requetMethod)
        {
            ReturnObject returnObject = new ReturnObject();
            List<ErrorMessage> errors = new List<ErrorMessage>();
            ServiceResponse serviceResponse = new ServiceResponse();
            
            switch (requetMethod)
            {
                case "GetBoxs":

                    AssetSearch assetSearch = (AssetSearch)objEntity;

                    if (string.IsNullOrEmpty(assetSearch.BoxNbr) && (assetSearch.BoxStatus == null || Convert.ToInt32(assetSearch.BoxStatus) == 0) && string.IsNullOrEmpty(assetSearch.CustId) && string.IsNullOrEmpty(assetSearch.DstrctId) && string.IsNullOrEmpty(assetSearch.FromDt.ToString()) && string.IsNullOrEmpty(assetSearch.ToDt.ToString()) && string.IsNullOrEmpty(assetSearch.LoggedInUser) && string.IsNullOrEmpty(assetSearch.SkpOrdrNbr))
                    {
                        AddError(errors, Convert.ToString(ValidationCode.V001));
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(assetSearch.FromDt.ToString()) && !string.IsNullOrEmpty(assetSearch.ToDt.ToString()))
                        {
                            returnObject = serviceResponse.sendRequestFailedMessage();
                            returnObject.errors = new List<ErrorMessage>();

                            try
                            {
                             
                                if (assetSearch.FromDt > assetSearch.ToDt)
                                {
                                    AddError(errors, Convert.ToString(ValidationCode.V002));
                                }
                                
                            }
                            catch (Exception ex)
                            {
                                AddError(errors, Convert.ToString(ValidationCode.V003));
                            }
                        }

                        if (assetSearch.BoxStatus != null && Convert.ToInt32(assetSearch.BoxStatus) == 0)
                        {
                            AddError(errors, Convert.ToString(ValidationCode.V016));
                        }

                        if (string.IsNullOrEmpty(assetSearch.LoggedInUser))
                        {
                            AddError(errors, Convert.ToString(ValidationCode.V004));
                        }

                    }

                    break;
                case "AddNewBox":

                    AddAsset addAsset = (AddAsset)objEntity;
                    if (string.IsNullOrEmpty(addAsset.DstrctId))
                    {
                        AddError(errors, Convert.ToString(ValidationCode.V007));
                    }
                    if (string.IsNullOrEmpty(addAsset.CustAcntNbr))
                    {
                        AddError(errors, Convert.ToString(ValidationCode.V008));
                    }
                    if (string.IsNullOrEmpty(addAsset.SkpOrdrNbr))
                    {
                        AddError(errors, Convert.ToString(ValidationCode.V009));
                    }
                    if (string.IsNullOrEmpty(addAsset.BoxNbr))
                    {
                        AddError(errors, Convert.ToString(ValidationCode.V006));
                    }
                    if (string.IsNullOrEmpty(addAsset.LoggedInUser))
                    {
                        AddError(errors, Convert.ToString(ValidationCode.V004));
                    }

                    break;
                case "EditBox":

                    AssetAssign assetAssign = (AssetAssign)objEntity;

                    if (string.IsNullOrEmpty(assetAssign.AssetId.ToString()))
                    {
                        AddError(errors, Convert.ToString(ValidationCode.V010));
                    }
                    else if (assetAssign.AssetId == 0)
                    {
                        AddError(errors, Convert.ToString(ValidationCode.V014));
                    }
                    if (string.IsNullOrEmpty(assetAssign.CustId))
                    {
                        AddError(errors, Convert.ToString(ValidationCode.V008));
                    }
                    //if (string.IsNullOrEmpty(Convert.ToString(assetAssign.AsgnmntTs)))
                    //{
                    //    AddError(errors, Convert.ToString(ValidationCode.V011));
                    //}                    
                    if (assetAssign.ProjectId == null || string.IsNullOrEmpty(Convert.ToString(assetAssign.ProjectId)))
                    {
                        AddError(errors, Convert.ToString(ValidationCode.V012));
                    }
                    else if (assetAssign.ProjectId == 0)
                    {
                        AddError(errors, Convert.ToString(ValidationCode.V015));
                    }
                    if (string.IsNullOrEmpty(Convert.ToString(assetAssign.ExpctdCmpltdDt)))
                    {
                        AddError(errors, Convert.ToString(ValidationCode.V013));
                    }
                    if (string.IsNullOrEmpty(assetAssign.LoggedInUser))
                    {
                        AddError(errors, Convert.ToString(ValidationCode.V004));
                    }

                    break;
                case "CompleteBox":
                    
                    CompleteAsset completeAsset = (CompleteAsset)objEntity;

                    if (string.IsNullOrEmpty(completeAsset.BoxNbr))
                    {
                        AddError(errors, Convert.ToString(ValidationCode.V006));
                    }

                    if (string.IsNullOrEmpty(completeAsset.LoggedInUser))
                    {
                        AddError(errors, Convert.ToString(ValidationCode.V004));
                    }

                    break;

                case "DeleteBox":
                    
                    DeleteAsset deleteAsset = (DeleteAsset)objEntity;
                    
                    if (string.IsNullOrEmpty(deleteAsset.BoxNbr))
                    {
                        AddError(errors, Convert.ToString(ValidationCode.V006));
                    }

                    if (string.IsNullOrEmpty(deleteAsset.LoggedInUser))
                    {
                        AddError(errors, Convert.ToString(ValidationCode.V004));
                    }

                    break;
                default:
                    returnObject = serviceResponse.sendSuccessMessage();
                    break;
            }

            if (errors.Count > 0)
            {
                returnObject = serviceResponse.sendRequestFailedMessage();
                returnObject.errors = new List<ErrorMessage>();
                returnObject.errors = errors;
            }
            else
            {
                returnObject = serviceResponse.sendSuccessMessage();
            }

            return returnObject;
        }

        public static void AddError(List<ErrorMessage> errors, string errorCode)
        {
            ErrorMessage errorMessage = new ErrorMessage();
            errorMessage.Code = errorCode;
            errorMessage.Message = Utility.GetResourceValue(Convert.ToString(ResourceName.Asset), errorMessage.Code);
            errors.Add(errorMessage);
        }
    }

    public class AppError
    {
        public int Id { get; set; }
        public string ErrorCode { get; set; }

        public string ErrorMsg { get; set; }
    }

    public class Response
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Messsage { get; set; }
    }

    public class ReturnObject
    {
        public bool success { get; set; }
        public List<ErrorMessage> errors { get; set; }
        public List<ErrorMessage> warnings { get; set; }
        public int responseCode { get; set; }
        public string responseMessage { get; set; }
        public object result { get; set; }
    }

    public class ErrorMessage
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }

    public class ServiceResponse
    {
        public ReturnObject sendSuccessMessage()
        {
            ReturnObject robj = new ReturnObject()
            {
                responseCode = 0,
                responseMessage = "SUCCESS",
                success = true,
                errors = null,
                warnings = null,
            };
            return robj;
        }



        public ReturnObject sendRequestFailedMessage()
        {
            ReturnObject robj = new ReturnObject()
            {
                responseCode = 1,
                responseMessage = "ERROR",
                success = false,
            };
            return robj;
        }
    }

    public enum BoxStatus
    {
        UnAssign = 101,
        Assign = 102,
        Completed = 103
    }

    public enum BoxCompleteStatus
    {
        Completed = 1,
        NotCompleted = 0
    }

    public enum BoxDeleteStatus
    {
        Y = 1,
        N = 0
    }

    public enum HttpContextItem
    {
        LoggedInUser,
        ActionType
    }
    public enum ActionType
    {
        GET,
        ADD,
        EDIT,
        DELETE
    }

    public enum APIRequestMethodName
    {
        GetBoxs,
        AddNewBox,
        EditBox,
        CompleteBox,
        DeleteBox
    }
}
