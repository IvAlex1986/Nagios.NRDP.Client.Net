using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace Nagios.NRDP.Client.Net.Helpers
{
    internal static class HttpHelper
    {
        public static String Get(Uri url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            using (var response = request.GetResponse())
            {
                return response.ResponseToString();
            }
        }

        public static String Post(Uri url, NameValueCollection parameters)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            var builder = new StringBuilder();
            foreach (String key in parameters.Keys)
            {
                builder.AppendFormat("{0}={1}&", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(parameters[key]));
            }
            builder.Length -= 1;

            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(builder.ToString());
            }

            using (var response = request.GetResponse())
            {
                return response.ResponseToString();
            }
        }

        #region Private

        private static String ResponseToString(this WebResponse response)
        {
            var result = String.Empty;

            using (var stream = response.GetResponseStream())
            {
                if (stream != null)
                {
                    using (var reader = new StreamReader(stream))
                    {
                        result = reader.ReadToEnd();
                    }

                    stream.Close();
                }
            }

            return result;
        }

        #endregion Private
    }
}
