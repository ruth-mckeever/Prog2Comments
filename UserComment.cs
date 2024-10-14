namespace Prog2Comments
{
    public class UserComment
    {
        private string rawComment;
        private string sanitizedComment = "";

        public string RawComment
        {
            get { return rawComment; }
            set { rawComment = value; }
        }

        public string SanitizedComment
        {
            get { return sanitizedComment; }
            set { sanitizedComment = value; }
        }
        public UserComment(string rawComment)
        {
            this.rawComment = rawComment;
            sanitizedComment = SanitizeService.SanitizeText(rawComment);  //TODO: will sanitize this here
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
