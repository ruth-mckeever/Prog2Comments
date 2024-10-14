using RestSharp;
using System.Xml.Serialization;

namespace Prog2Comments
{
    public class SanitizeService
    {
        static readonly string SanitizeURL = "http://www.purgomalum.com/service/xml";
        public static string? SanitizeText(string rawText)
        {
            var client = new RestClient(SanitizeURL);
            var request = new RestRequest();
            request.AddParameter("text", rawText);
            var response = client.Execute(request);

            if (!string.IsNullOrWhiteSpace(response.Content))
            {
                var serializer = new XmlSerializer(typeof(PurgoMalum));
                using (StringReader sr = new(response.Content))
                {
                    PurgoMalum? sanitized = (PurgoMalum?)serializer.Deserialize(sr);
                    return sanitized?.result;
                }
            }

            return string.Empty;
        }
    }
}
