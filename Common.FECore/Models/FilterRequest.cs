using Common.FECore.Models;

namespace Common.FECore.Models
{
    public class FilterRequest
    {
        public FilterLogicalOperator LogicalOperator { get; set; }
        public IEnumerable<FilterDetailsRequest>? Details { get; set; }
    }
}
