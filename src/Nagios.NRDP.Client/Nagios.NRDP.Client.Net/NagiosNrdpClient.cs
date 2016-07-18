using Nagios.NRDP.Client.Net.Helpers;
using Nagios.NRDP.Client.Net.Models.Request;
using Nagios.NRDP.Client.Net.Models.Response;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Nagios.NRDP.Client.Net
{
    public class NagiosNrdpClient : INagiosNrdpClient
    {
        public NagiosNrdpClient(Uri apiUri, String token)
        {
            ApiUri = apiUri;
            Token = token;
        }

        public NagiosNrdpClient(String apiUri, String token)
            : this(new Uri(apiUri), token)
        {
        }

        public Uri ApiUri
        {
            get;
            set;
        }

        public string Token
        {
            get;
            set;
        }

        public Result SubmitChackData(params INagiosItem[] items)
        {
            var result = new Result();

            if (items.Length == 0)
            {
                throw new ArgumentException("There are no entered INagiosItem elements");
            }

            var builder = new StringBuilder();
            builder.Append("<?xml version='1.0'?> ");
            builder.Append("<checkresults>");
            items.ToList().ForEach(n => builder.Append(n.GenerateItemData()));
            builder.Append("</checkresults>");

            var parameters = new NameValueCollection
            {
                {"cmd", "submitcheck"},
                {"token", Token},
                {"XMLDATA", builder.ToString()}
            };

            var response = HttpHelper.Post(ApiUri, parameters);

            var serializer = new XmlSerializer(typeof(Result));
            using (TextReader reader = new StringReader(response))
            {
                result = (Result)serializer.Deserialize(reader);
            }

            return result;
        }
    }
}
