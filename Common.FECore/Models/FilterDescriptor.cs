using Common.FECore.Models;
using Common.FECore.Models.Enums;

namespace Common.FECore.Models
{
    public class FilterDescriptor
    {
        public string? Field { get; set; }
        public string?[]? Values { get; set; }
        public FilterType Operator { get; set; }
        public FilterLogicalOperator LogicalOperator { get; set; }
    }
}
