using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Web;

namespace MQLDatabase.Common
{
    public static class HttpExtentions
    {
        public static string GetCookie(this HttpContext context, string name)
        {
            return context.Request.Cookies[name];
        }
        public static void SetCookie(this HttpContext context, string name, string value, int expireTime)
        {
            context.Response.Cookies.Delete(name);
            var cookieOption = new CookieOptions
            {
                Expires = new DateTimeOffset(DateTime.Now.AddDays(5)),
            };
            context.Response.Cookies.Append(name, value, cookieOption);
        }
        public static void RemoveCookie(this HttpContext context, string name)
        {
            context.Response.Cookies.Delete(name);
        }

        public static string GetCookie(this HttpRequest request, string name)
        {
            return request.Cookies[name];
        }
        public static void SetCookie(this HttpResponse response, string name, string value, int expireTime)
        {
            response.Cookies.Delete(name);
            var cookieOption = new CookieOptions
            {
                Expires = new DateTimeOffset(DateTime.Now.AddDays(5)),
            };
            response.Cookies.Append(name, value, cookieOption);
        }
        public static void RemoveCookie(this HttpResponse response, string name)
        {
            response.Cookies.Delete(name);
        }

        public static string HtmlEncode(this string str)
        {
            return HttpUtility.HtmlEncode(str);
        }
        public static string HtmlDecode(this string str)
        {
            return HttpUtility.HtmlDecode(str);
        }
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }




        
    }
}
