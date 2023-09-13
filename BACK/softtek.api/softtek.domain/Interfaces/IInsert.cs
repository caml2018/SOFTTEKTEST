using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace softtek.domain.Interfaces
{
    public interface IInsert<T>
    {
        public T Insert(T entity);
        public List<T> Insert(List<T> entity);
    }
}
