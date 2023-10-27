using Common.FECore.Models.DTOs;

namespace Common.FECore.Models.DTOs
{
    public abstract class BaseUpdateRequest<TKey> : BaseDTO
    {
        public virtual TKey? Id { get; set; }
    }
}
