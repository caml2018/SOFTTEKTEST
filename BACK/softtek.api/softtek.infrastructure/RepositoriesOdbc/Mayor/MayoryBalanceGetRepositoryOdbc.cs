using AutoMapper;
using Microsoft.EntityFrameworkCore;
using softtek.application.Interfaces.Mayor;
using softtek.Application.Interfaces.Mayor;
using softtek.domain.Entities;
using softtek.infrastructure.EntityFrameWorkDataAccess.Context;
using softtek.infrastructure.EntityFrameWorkDataAccess.Models;
using softtek.infrastructure.Odbc.Context;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace softtek.Infrastructure.RepositoriesOdbc.Mayor
{
    public class MayoryBalanceGetRepositoryOdbc : IMayorGetRepositoryOdbc
    {
        private readonly IMapper _mapper;
        private readonly IOdbcContext _odbcContext ;
        public MayoryBalanceGetRepositoryOdbc(IMapper mapper, IOdbcContext odbcContext)
        {
            _mapper = mapper;
            _odbcContext = odbcContext;
        }
        public async Task<List<MayoryBalance>> get()
        {
            List<MayoryBalance> result = new List<MayoryBalance>();
            
            //_odbcContext.CreateConnection().Open();
            
            //var res=  _mapper.Map<List<MayoryBalance>>( _dbTestSofttekContext.Result.FromSqlInterpolated<Result>($"reports.prc_obtener_reporte").ToList());
            return result;
        }

        public MayoryBalance get(int id)
        {
            MayoryBalance mayoryBalance= new MayoryBalance();
            //var res= _mapper.Map<MayoryBalance>(_dbTestSofttekContext.Reports.FromSqlInterpolated<Report>($"reports.prc_obtener_reporte").Where(x => x.Id == id).FirstOrDefault());
            return mayoryBalance;
        }
    }
}
