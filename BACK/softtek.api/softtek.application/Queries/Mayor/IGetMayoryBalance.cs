using softtek.domain.Entities;
using softtek.domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace softtek.Application.Queries.Mayor
{
    public interface IGetMayoryBalance:IConsultar<MayoryBalance, int>
    {
    }
}
