using AutoMapper;
using Microsoft.EntityFrameworkCore;
using softtek.Application.Interfaces.Mayor;
using softtek.domain.Entities;
using softtek.infrastructure.EntityFrameWorkDataAccess.Context;
using softtek.infrastructure.EntityFrameWorkDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace softtek.Infrastructure.Repositories.Mayor
{
    public class MayoryBalanceAddRepository : IMayorAddRepository
    {
        private IMapper _mapper;
        private readonly DbTestSofttekContext _dbTestSofttekContext;
        public MayoryBalanceAddRepository(IMapper mapper, DbTestSofttekContext dbTestSofttekContext)
        {
            _mapper = mapper;
            _dbTestSofttekContext= dbTestSofttekContext;
        }
        public MayoryBalance Insert(MayoryBalance entity)
        {
            _dbTestSofttekContext.Add(_mapper.Map<Report>(entity));
            _dbTestSofttekContext.SaveChanges();
            return entity;
        }

        public List<MayoryBalance> Insert(List<MayoryBalance> entity)
        {
            _dbTestSofttekContext.AddRange(_mapper.Map<List<Report>>(entity));
            _dbTestSofttekContext.SaveChanges();
            return entity;
        }

        public void Delete()
        {
            var table = "Reports.Report";
            _dbTestSofttekContext.Database.ExecuteSqlRaw($"Truncate table {table}");
        }
    }
}
