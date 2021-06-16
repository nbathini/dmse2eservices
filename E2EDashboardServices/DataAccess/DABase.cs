using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Transactions;

namespace E2EDashboard.DataAccess
{
    /// <summary>
    /// DA Base
    /// </summary>
    public abstract class DABase
    {
        #region Protect Properties
        /// <summary>
        /// Gets or sets the database transaction scope.
        /// </summary>
        /// <value>
        /// The database transaction scope.
        /// </value>
        protected TransactionScope DBTransactionScope { get; set; }

        /// <summary>
        /// Gets or sets the database connection string.
        /// </summary>
        /// <value>
        /// The database connection string.
        /// </value>
        protected string DBConnectionString { get; set; }
        #endregion

        #region Protect Methods
        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="procName">Name of the proc.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// return reader
        /// </returns>
        protected SqlDataReader ExecuteReader(string procName, SqlParameter[] parameters)
        {
            //if (this.DBTransactionScope != null)
            //    return SqlHelper.ExecuteReader(this.DBTransactionScope.Transaction, procName, parameters);

            return SqlHelper.ExecuteReader(this.DBConnectionString, procName, parameters);
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="procName">Name of the proc.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// The number of rows affected
        /// </returns>
        protected int ExecuteNonQuery(string procName, SqlParameter[] parameters)
        {
            //if (this.DBTransactionScope != null)
            //    return SqlHelper.ExecuteNonQuery(this.DBTransactionScope.Transaction, procName, parameters);

            return SqlHelper.ExecuteNonQuery(this.DBConnectionString, procName, parameters);
        }

        /// <summary>
        /// Executes the datatable.
        /// </summary>
        /// <param name="procName">Name of the proc.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        protected DataTable ExecuteDatatable(string procName, SqlParameter[] parameters)
        {
            //if (this.DBTransactionScope != null)
            //    return SqlHelper.ExecuteDatatable(this.DBTransactionScope.Transaction, procName, parameters);

            return SqlHelper.ExecuteDatatable(this.DBConnectionString, procName, parameters);
        }

        /// <summary>
        /// Executes the return.
        /// </summary>
        /// <param name="procName">Name of the proc.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// return value
        /// </returns>
        protected object ExecuteReturn(string procName, SqlParameter[] parameters)
        {
            //if (this.DBTransactionScope != null)
            //    return SqlHelper.ExecuteReturnObj(this.DBTransactionScope.Transaction, procName, parameters);

            return SqlHelper.ExecuteReturnObj(this.DBConnectionString, procName, parameters);
        }

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="procName">Name of the proc.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// return first cell value
        /// </returns>
        protected object ExecuteScalar(string procName, SqlParameter[] parameters)
        {
            //if (this.DBTransactionScope != null)
            //    return SqlHelper.ExecuteScalar(this.DBTransactionScope.Transaction, procName, parameters);

            return SqlHelper.ExecuteScalar(this.DBConnectionString, procName, parameters);
        }

        /// <summary>
        /// Gets the string value.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns>
        /// return value
        /// </returns>
        protected string GetStringValue(SqlDataReader reader, string fieldName)
        {
            int i = reader.GetOrdinal(fieldName);
            if (!reader.IsDBNull(i))
                return reader.GetString(i);

            return string.Empty;
        }

        /// <summary>
        /// Gets the int value.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns>
        /// return value
        /// </returns>
        protected int GetIntValue(SqlDataReader reader, string fieldName)
        {
            int i = reader.GetOrdinal(fieldName);
            if (!reader.IsDBNull(i))
                return Convert.ToInt32(reader[i]);

            return 0;
        }

        /// <summary>
        /// Gets the int null value.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns>
        /// return value
        /// </returns>
        protected int? GetIntNullValue(SqlDataReader reader, string fieldName)
        {
            int i = reader.GetOrdinal(fieldName);
            if (!reader.IsDBNull(i))
                return Convert.ToInt32(reader[i]);

            return null;
        }

        /// <summary>
        /// Gets the bool value.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns>
        /// return value
        /// </returns>
        protected bool GetBoolValue(SqlDataReader reader, string fieldName)
        {
            int i = reader.GetOrdinal(fieldName);
            if (!reader.IsDBNull(i))
                return reader.GetBoolean(i);

            return false;
        }

        /// <summary>
        /// Gets the bool null value.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns>return value</returns>
        protected bool? GetBoolNullValue(SqlDataReader reader, string fieldName)
        {
            int i = reader.GetOrdinal(fieldName);
            if (!reader.IsDBNull(i))
                return reader.GetBoolean(i);

            return null;
        }

        /// <summary>
        /// Gets the date value.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns>
        /// return value
        /// </returns>
        protected DateTime GetDateValue(SqlDataReader reader, string fieldName)
        {
            int i = reader.GetOrdinal(fieldName);
            if (!reader.IsDBNull(i))
                return reader.GetDateTime(i);

            return DateTime.MinValue;
        }

        /// <summary>
        /// Gets the date null value.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns>
        /// return value
        /// </returns>
        protected DateTime? GetDateNullValue(SqlDataReader reader, string fieldName)
        {
            int i = reader.GetOrdinal(fieldName);
            if (!reader.IsDBNull(i))
                return reader.GetDateTime(i);

            return null;
        }

        /// <summary>
        /// Gets the double value.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns>return value</returns>
        protected double GetDoubleValue(SqlDataReader reader, string fieldName)
        {
            int i = reader.GetOrdinal(fieldName);
            if (!reader.IsDBNull(i))
                return Convert.ToDouble(reader[i]);

            return 0;
        }

        /// <summary>
        /// Gets the double null value.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns>return value</returns>
        protected double? GetDoubleNullValue(SqlDataReader reader, string fieldName)
        {
            int i = reader.GetOrdinal(fieldName);
            if (!reader.IsDBNull(i))
                return Convert.ToDouble(reader[i]);

            return null;
        }

        /// <summary>
        /// Gets the bytes value.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns>return value</returns>
        protected byte[] GetBytesValue(SqlDataReader reader, string fieldName)
        {
            int i = reader.GetOrdinal(fieldName);
            if (!reader.IsDBNull(i))
                return (byte[])reader[i];

            return null;
        }

        /// <summary>
        /// Gets the byte value.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns>return value</returns>
        protected byte GetByteValue(SqlDataReader reader, string fieldName)
        {
            int i = reader.GetOrdinal(fieldName);
            if (!reader.IsDBNull(i))
                return reader.GetByte(i);

            return 0;
        }

        /// <summary>
        /// Joins the value.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        protected string JoinValue(List<int> values)
        {
            if (values.Count == 0)
                return string.Empty;

            string joinStr = values[0].ToString();
            for (int i = 1; i < values.Count; i++)
            {
                joinStr += ",";
                joinStr += values[i];
            }

            return joinStr;
        }

        /// <summary>
        /// Readers the exists.
        /// </summary>
        /// <param name="dr">The dr.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>return process result</returns>
        protected bool readerExists(SqlDataReader dr, string columnName)
        {

            dr.GetSchemaTable().DefaultView.RowFilter = "ColumnName= '" + columnName + "'";

            return (dr.GetSchemaTable().DefaultView.Count > 0);
        }

        /// <summary>
        /// Inserts the audit record.
        /// </summary>
        /// <param name="userKey">The user key.</param>
        /// <param name="contactID">The contact identifier.</param>
        /// <param name="accountID">The account identifier.</param>
        /// <returns>return process result</returns>
        

        ///// <summary>
        ///// Creates the email queue.
        ///// </summary>
        ///// <param name="templateName">Name of the template.</param>
        ///// <returns>
        ///// return empty email template
        ///// </returns>
        ///// <exception cref="System.Exception">Get email template - { + templateName + } failed.</exception>
        //public EmailSendQueue CreateEmailQueue(string templateName)
        //{
        //    EmailHelper emailHelper = new EmailHelper(AppConfiguration.ConnectionString);
        //    EmailTemplate template = emailHelper.GetEmailTemplate(templateName);
        //    if (template == null)
        //    {
        //        throw new Exception("Get email template - {" + templateName + "} failed.");
        //    }

        //    EmailSendQueue sendQueue = new EmailSendQueue();
        //    sendQueue.AddressFrom = AppConfiguration.EmailFrom;
        //    sendQueue.Subject = template.EmailSubject;
        //    sendQueue.Body = template.EmailBody;
        //    sendQueue.EmailType = EmailQueueType.NormalWeb;
        //    sendQueue.RecordDate = DateTime.Now;
        //    sendQueue.QueueStatus = EmailQueueStatus.Sending;
        //    sendQueue.FailedTimes = 1;
        //    return sendQueue;
        //}
        #endregion
    }
}
