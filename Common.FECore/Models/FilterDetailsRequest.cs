using Common.FECore.Models.Enums;

namespace Common.FECore.Models
{
    public class FilterDetailsRequest
    {
        public string? AttributeName { get; set; }
        public string? Value { get; set; }
        public FilterType FilterType { get; set; }
    }
}
