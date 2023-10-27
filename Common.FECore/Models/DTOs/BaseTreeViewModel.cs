using Common.FECore.Models.DTOs;

namespace Common.FECore.Models.DTOs
{
    public interface IBaseTreeViewModel<T>
    {
        public T Data { get; set; }
        public List<IBaseTreeViewModel<T>> Children { get; set; }
    }
}
