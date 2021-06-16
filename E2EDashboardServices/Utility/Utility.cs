using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Reflection;
using System.Collections;

namespace E2EDashboard.Utility
{
    public static class Utility
    {
        public static string GetResourceValue(string resourceFileName, string fieldName)
        {
            ResourceManager rm = new ResourceManager("E2EDashboard.API.Core.Resources." + resourceFileName, Assembly.GetExecutingAssembly());


            return rm.GetString(fieldName, CultureInfo.CurrentCulture);

        }
        public static DateTime ConvertStringToDateTime(string date, string time)
        {
            return ConvertToDateTime(date.Trim() + " " + time.Trim());
        }

        public static DateTime ConvertStringToDateTime(string date)
        {
            return ConvertToDateTime(date.Trim() + " 00:00");
        }

        public static DateTime ConvertToDateTime(string datetime)
        {
            return DateTime.ParseExact(datetime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
        }

        public static string ConvertDateTimeToDateTimeString(DateTime datetime)
        {
            return datetime.ToString("dd/MM/yyyy HH:mm");
        }

        public static string ConvertDateTimeToDateString(DateTime datetime)
        {
            return datetime.ToString("dd/MM/yyyy");
        }

        public static string ConvertDateTimeToDateString(string datetime)
        {
            try
            {
                return Convert.ToDateTime(datetime).ToString("dd/MM/yyyy");
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string ConvertDateTimeToTimeString(DateTime datetime)
        {
            return datetime.ToString("HH:mm");
        }

        public static string ConvertDateTimeToTimeString(string datetime)
        {
            try
            {
                return Convert.ToDateTime(datetime).ToString("HH:mm");
            }
            catch
            {
                return string.Empty;
            }
        }

        public static int? ConvertToNullableInteger(object inputValue)
        {
            int outValue;
            if (null == inputValue)
            {
                return null;
            }
            else
            {
                if (int.TryParse(inputValue.ToString(), out outValue))
                {
                    return outValue;
                }
                else
                {
                    return null;
                }
            }
        }

        public static decimal? ConvertToNullableDecimal(object inputValue)
        {
            decimal outValue;
            if (null == inputValue)
            {
                return null;
            }
            else
            {
                if (decimal.TryParse(inputValue.ToString(), out outValue))
                {
                    return outValue;
                }
                else
                {
                    return null;
                }
            }
        }
        
    }
}
