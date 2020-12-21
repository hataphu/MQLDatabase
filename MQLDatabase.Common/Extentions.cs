using Newtonsoft.Json;
using System;
using System.Collections;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
/// <summary>
/// Summary Extentions tan-hv
/// </summary>


namespace MQLDatabase.Common
{
    public static class Extentions
    {
        /// <summary>
        /// convert string json to object
        /// </summary>
        /// <param name="json">input string json</param>
        /// <returns>object</returns>
        public static object JsonToObject(this string json)
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<object>(json);
                return obj;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// convert string json to object
        /// </summary>
        /// <param name="json">input string json</param>
        /// <returns>object</returns>
        public static T JsonToObject<T>(this string json)
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<T>(json);
                return obj;
            }
            catch
            {
                return (T)Convert.ChangeType(null, typeof(T));
            }
        }

        /// <summary>
        /// convert object to json
        /// </summary>
        /// <param name="obj">input object</param>
        /// <returns>string json</returns>
        public static string ToJson(this object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch
            {
                return string.Empty;
            }

        }

        public static DateTime? StringToDateTime(this string strDate)
        {
            string[] formats = {
            "yyyyMMdd",
            "dd/MM/yyyy",
            "yyyyMM",
            "MMM-yy",
            "dd-MMM-yy",
            "dd-MMM-yyyy",
            "dd-MMM-yyyy HH:mm",
            "dd-MMM-yyyy HH:mm:ss",
            "dd-MMM-yyyy HH:mm:ss tt",
            "dd-MMM-yy HH:mm",
            "dd-MMM-yy HH:mm:ss",
            "dd-MMM-yy HH:mm:ss tt",
            "yyyyMMddHHmmss",
            "yyyyMMddHHmm",
            "yyyyMMdd",
            "dd/MM/yyyy HH:mm",
            "dd/MM/yyyy HH:mm:ss" ,
            "dd/MM/yyyy HH:mm:ss tt" ,
            "MM/dd/yyyy HH:mm",
            "yyyy-MM-ddTHH:mm:sszzz",
            "MM/dd/yy HH:mm:ss",
            "MM/dd/yy HH:mm:ss tt"};
            if (!string.IsNullOrEmpty(strDate))
            {
                try
                {
                    var c = new CultureInfo("en-US");
                    var date = DateTime.ParseExact(strDate, formats, c, DateTimeStyles.None);
                    return date;
                }
                catch { }
            }
            return null;
        }
        public static string DateToString(this DateTime date)
        {
            try
            {
                return date.ToString("dd/MM/yyyy");
            }
            catch
            {
                return string.Empty;
            }
        }
        public static string DateTimeToString(this DateTime date)
        {
            try
            {
                return date.ToString("dd/MM/yyyy HH:mm");
            }
            catch
            {
                return string.Empty;
            }
        }
        public static string DateToStringDefault(this DateTime date)
        {
            try
            {
                return date.ToString("yyyyMMdd", new CultureInfo("en-US"));
            }
            catch
            {
                return string.Empty;
            }
        }
        public static string DateTimeToStringDefault(this DateTime date)
        {
            try
            {
                return date.ToString("yyyyMMddHHmmss", new CultureInfo("en-US"));
            }
            catch
            {
                return string.Empty;
            }
        }

        public static int ToInt(this string str)
        {
            try
            {
                int a;
                if (int.TryParse(str, out a))
                {
                    return a;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public static int? ToIntNull(this string str)
        {
            try
            {
                int a;
                if (int.TryParse(str, out a))
                {
                    return a;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static long ToLong(this string str)
        {
            try
            {
                long a;
                if (long.TryParse(str, out a))
                {
                    return a;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public static long? ToLongNull(this string str)
        {
            try
            {
                long a;
                if (long.TryParse(str, out a))
                {
                    return a;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }


        public static float ToFloat(this string str)
        {
            try
            {
                float a;
                if (float.TryParse(str, out a))
                {
                    return a;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public static float? ToFloatNull(this string str)
        {
            try
            {
                float a;
                if (float.TryParse(str, out a))
                {
                    return a;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static double ToDouble(this string str)
        {
            try
            {
                double a;
                if (double.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out a))
                {
                    return a;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public static double? ToDoubleNull(this string str)
        {
            try
            {
                double a;
                if (double.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out a))
                {
                    return a;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static decimal ToDecimal(this string str)
        {
            try
            {
                decimal a;
                if (decimal.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out a))
                {
                    return a;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public static decimal? ToDecimalNull(this string str)
        {
            try
            {
                decimal a;
                if (decimal.TryParse(str, NumberStyles.Any, CultureInfo.InvariantCulture, out a))
                {
                    return a;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static string ToStringNumber(this object obj, CultureInfo cultureInfo)
        {
            try
            {
                double a;
                if (double.TryParse(obj.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out a))
                {
                    return a.ToString("###,###,###,###.#####", cultureInfo);
                }
                return obj.ToString();
            }
            catch
            {
                return "";
            }
        }

        public static bool IsWeekend(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        public static int GetWeekNumberOfYear(this DateTime date, CultureInfo culture)
        {
            return culture.Calendar.GetWeekOfYear(date,
                culture.DateTimeFormat.CalendarWeekRule,
                culture.DateTimeFormat.FirstDayOfWeek);
        }

        public static string ClearVnCharacter(this string vnString)
        {
            var regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            var temp = vnString.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        public static string ClearHtmlTag(this string source)
        {
            return Regex.Replace(source, "<.*?>", string.Empty);
        }


        public static DateTime NgayDauThang(this int thang, int nam)
        {
            return new DateTime(nam, thang, 1);
        }

        public static DateTime NgayCuoiThang(this int thang, int nam)
        {
            return new DateTime(nam, thang, DateTime.DaysInMonth(nam, thang));
        }



        public static byte[] StringToByteArray(this string hex)
        {
            try
            {
                if (hex != null)
                {
                    int NumberChars = hex.Length;
                    byte[] bytes = new byte[NumberChars / 2];
                    for (int i = 0; i < NumberChars; i += 2)
                        bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
                    return bytes;
                }
                return new byte[] { };
            }
            catch
            {
                return new byte[] { };
            }
        }

        public static bool GetBit(this byte b, int bitNumber)
        {
            BitArray ba = new BitArray(new byte[] { b });
            return ba.Get(bitNumber);
        }
        public static string ByteArrayToString(this byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }

}