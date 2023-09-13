using AutoMapper;
using Microsoft.EntityFrameworkCore;
using softtek.Application.Interfaces.Mayor;
using softtek.domain.Entities;
using softtek.infrastructure.EntityFrameWorkDataAccess.Context;
using softtek.infrastructure.EntityFrameWorkDataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace softtek.Infrastructure.Repositories.Mayor
{
    public class MayoryBalanceGetRepository : IMayorGetRepository
    {
        private readonly IMapper _mapper;
        private readonly DbTestSofttekContext _dbTestSofttekContext;
        public MayoryBalanceGetRepository(IMapper mapper,DbTestSofttekContext dbTestSofttekContext)
        {
            _mapper = mapper;
            _dbTestSofttekContext= dbTestSofttekContext;
        }
        public async Task<List<MayoryBalance>> get()
        {
            var res=  _mapper.Map<List<MayoryBalance>>( _dbTestSofttekContext.Result.FromSqlInterpolated<Result>($"reports.prc_obtener_reporte").ToList());
            return res;
        }

        public MayoryBalance get(int id)
        {
            var res= _mapper.Map<MayoryBalance>(_dbTestSofttekContext.Reports.FromSqlInterpolated<Report>($"reports.prc_obtener_reporte").Where(x => x.Id == id).FirstOrDefault());
            return res;
        }
    }
}
