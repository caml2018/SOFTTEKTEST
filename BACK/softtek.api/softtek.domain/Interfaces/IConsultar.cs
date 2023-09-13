using System.Collections.Generic;
using System.Threading.Tasks;

namespace softtek.domain.Interfaces
{
    public interface IConsultar<T,Tid>
    {
        public Task<List<T>> get();
        public T get(Tid id);
    }
}
