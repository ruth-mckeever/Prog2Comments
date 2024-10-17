using RestSharp;
using System.Xml.Serialization;

namespace Prog2Comments
{
    public class SanitizeService
    {
        static readonly string Sanitize_URL = "http://www.purgomalum.com/service/xml";

        public static string? SanitizeText(string rawText)
        {

            var client = new RestClient(Sanitize_URL);
            var request = new RestRequest();
            request.AddParameter("text", rawText);
            var response = client.Execute(request);

            if (!string.IsNullOrWhiteSpace(response.Content))
            {
                var serializer = new XmlSerializer(typeof(PurgoMalum));
                using(StringReader sr = new(response.Content))
                {
                    PurgoMalum? sanitizedText = (PurgoMalum?)serializer.Deserialize(sr);
                    return sanitizedText?.result;
                }
            }

            return string.Empty;
        }
    }


    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.purgomalum.com")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.purgomalum.com", IsNullable = false)]
    public partial class PurgoMalum
    {

        private string resultField;

        /// <remarks/>
        public string result
        {
            get
            {
                return this.resultField;
            }
            set
            {
                this.resultField = value;
            }
        }
    }


}
