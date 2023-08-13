namespace Hexbear.Lib.Models
{
    public class ReportsResponse
    {
        public List<ReportItem> ReportItems { get; set; }
    }

    public class ReportItem
    {
        public string CreatorName { get; set; }
        public string Reason { get; set; }
        public bool Resolved { get; set; }
        public string ResolverName { get; set; }
        public string PosterName { get; set; }
        public string ReportType { get; set; }
        public string OriginalText { get; set; }
    }
}