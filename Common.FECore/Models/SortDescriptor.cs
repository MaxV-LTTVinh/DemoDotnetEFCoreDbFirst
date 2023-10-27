using Common.FECore.Models.Enums;

namespace Common.FECore.Models
{
    public class SortDescriptor
    {
        public string Field { get; set; }
        public SortDirection Direction { get; set; }
    }
}
