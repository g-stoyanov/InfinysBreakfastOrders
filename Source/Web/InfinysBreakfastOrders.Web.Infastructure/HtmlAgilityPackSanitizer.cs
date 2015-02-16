namespace InfinysBreakfastOrders.Web.Infastructure
{
    public class HtmlAgilityPackSanitizer : ISanitizer
    {
        public string Sanitize(string html)
        {
            return html;
        }
    }
}
