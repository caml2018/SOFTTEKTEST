using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace softtek.domain.Interfaces
{
    public interface IEntityBaseWrite<T>:IInsert<T>,IDelete where T : class
    {
    }
}
