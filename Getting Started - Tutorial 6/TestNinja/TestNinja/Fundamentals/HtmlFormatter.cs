namespace TestNinja.Fundamentals
{
    public class HtmlFormatter
    {
        //Section 3 - Tutorial 2 - Testing Strings
        //This HTML Method just wraps strings in some HTML formatting.
        public string FormatAsBold(string content)
        {
            return $"<strong>{content}</strong>";
        }
    }
}