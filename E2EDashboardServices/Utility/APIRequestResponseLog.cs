using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2EDashboard.Utility
{
    public class APIRequestResponseLog
    {
        public int LogId { get; set; }

        public string ModuleName { get; set; }

        public string FunctionName { get; set; }

        public string ActionType { get; set; }

        public string LogType { get; set; }

        public string LogMessage { get; set; }

        public string RequestJSON { get; set; }

        public string ResponseJSON { get; set; }

        public string CreatedBy { get; set; }

    }

    public class APIRequestResponseLogDA
    {
        public int AddAPIRequestResponseLog(APIRequestResponseLog requestResponseLog)
        {
            int res = SqlHelper.ExecuteReturnInt(AppConfig.ConnectionString, CommandType.StoredProcedure, "SP_API_REQUEST_RESPONSE_LOG", CreateAPIRequestResponseParameter(requestResponseLog));

            return res;
        }

        private static SqlParameter[] CreateAPIRequestResponseParameter(APIRequestResponseLog requestResponseLog)
        {
            SqlParameter[] param = new SqlParameter[8];
            int iPos = 0;
            param[iPos++] = new SqlParameter("@MODULE_NAME", requestResponseLog.ModuleName);
            param[iPos++] = new SqlParameter("@FUNCTION_NAME", requestResponseLog.FunctionName);
            param[iPos++] = new SqlParameter("@ACTION_TYPE", requestResponseLog.ActionType);
            param[iPos++] = new SqlParameter("@LOG_TYPE", requestResponseLog.LogType);
            param[iPos++] = new SqlParameter("@LOG_MESSAGE", requestResponseLog.LogMessage);
            param[iPos++] = new SqlParameter("@REQUEST_JSON", requestResponseLog.RequestJSON);
            param[iPos++] = new SqlParameter("@RESPONSE_JSON", requestResponseLog.ResponseJSON);
            param[iPos++] = new SqlParameter("@CREATED_BY", requestResponseLog.CreatedBy);
            return param;
        }
    }

    public class APIRequestResponseLogAdd
    {
        APIRequestResponseLogDA requestResponseLogDA = new APIRequestResponseLogDA();
        public int AddAPIRequestResponseLog(APIRequestResponseLog requestResponseLog)
        {
            return this.requestResponseLogDA.AddAPIRequestResponseLog(requestResponseLog);
        }
    }
}
