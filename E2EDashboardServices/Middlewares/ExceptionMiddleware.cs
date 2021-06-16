using E2EDashboard.Business;
using E2EDashboard.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft;
using E2EDashboardServices;

namespace E2EDashboard.API.Core.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(RequestDelegate _next, ILogger<ExceptionMiddleware> _logger)
        {
            logger = _logger;
            next = _next;
        }

        public async Task<ReturnObject> Invoke(HttpContext context)
        {
            string requetPath = context.Request.Path;
            string moduleName = string.Empty;
            string functionName = string.Empty;

            if (requetPath.ToLower().Contains("/api/"))
            {
                string path = requetPath.Replace("/api/", "");
                moduleName = path.Split('/')[0];
                functionName = path.Split('/')[1];
            }

            try
            {
                await next(context);

                return null;
            }
            catch (Exception ex)
            {
                #region Logger Commented
                //logger.LogError(ex, ex.Message);                
                //context.Response.StatusCode = 500;
                //await context.Response.WriteAsync(ex.Message);
                #endregion

                #region Log Error Details To Flat File
                LogHelper.LogFile(LogType.Error, ex.Message);
                #endregion

                #region Log Error Details To DB Table
                APIRequestResponseLogAdd requestResponseLogAdd = new APIRequestResponseLogAdd();
                APIRequestResponseLog requestResponseLog = new APIRequestResponseLog();

                requestResponseLog.ModuleName = moduleName;
                requestResponseLog.FunctionName = functionName;
                requestResponseLog.ActionType = context.Items["ActionType"] != null ? context.Items["ActionType"].ToString() : string.Empty;
                requestResponseLog.LogType = LogType.Error.ToString();
                requestResponseLog.LogMessage = ex.Message;
                requestResponseLog.CreatedBy = context.Items["LoggedInUser"] != null ? context.Items["LoggedInUser"].ToString() : string.Empty; 

                requestResponseLogAdd.AddAPIRequestResponseLog(requestResponseLog);
                #endregion

                #region Prepare Return Object and Return as Response

                ServiceResponse response = new ServiceResponse();

                ReturnObject returnObject = response.sendRequestFailedMessage();

                returnObject.result = null;

                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.Code = Convert.ToString(ValidationCode.ERR);
                errorMessage.Message = ex.Message;

                returnObject.errors = new List<ErrorMessage>();

                returnObject.errors.Add(errorMessage);

                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(returnObject));

                return returnObject;

                #endregion

            }

        }
    }
}
