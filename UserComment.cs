using System.Runtime.InteropServices;

namespace Prog2Comments
{
    public class UserComment : IComparable<UserComment>
    {
        private string rawComment;
        private string sanitizedComment = "";
        private string rawTitle;
        private string sanitizedTitle = "";
        private DateTime createdTimestamp;

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
        public string RawTitle
        {
            get { return rawTitle; }
            set { rawTitle = value; }
        }
        public string SanitizedTitle
        {
            get { return sanitizedTitle; }
            set { sanitizedTitle = value; }
        }
        public DateTime CreatedTimestamp {
            get { return createdTimestamp; }
            set { createdTimestamp = value; }
        }
        public UserComment(string rawComment, string rawTitle)
        {
            this.rawComment = rawComment;
            sanitizedComment = SanitizeService.SanitizeText(rawComment);
            this.rawTitle = rawTitle;
            sanitizedTitle = SanitizeService.SanitizeText(rawTitle);
            createdTimestamp = DateTime.Now;
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is UserComment))
            {
                return false;
            }
            var userComment = (UserComment)obj;
            if (userComment.SanitizedComment.Equals(SanitizedComment) && userComment.SanitizedTitle.Equals(SanitizedTitle))
            {
                return true;
            }
            return base.Equals(obj);
        }

        public static bool operator ==(UserComment left, UserComment right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(UserComment left, UserComment right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return (SanitizedComment, SanitizedTitle).GetHashCode();
        }

        public int CompareTo(UserComment? other)
        {

            int result = string.Compare(SanitizedTitle, other.SanitizedTitle, ignoreCase: true);
            if (result == 0)
            {
                result = string.Compare(SanitizedComment, other.SanitizedComment, ignoreCase: true);
            }
            return result;
        }
    }


    
}
