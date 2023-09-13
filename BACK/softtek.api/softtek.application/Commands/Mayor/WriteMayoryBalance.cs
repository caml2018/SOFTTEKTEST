using softtek.Application.Interfaces.Mayor;
using softtek.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace softtek.Application.Commands.Mayor

{
    public class WriteMayoryBalance : IWriteMayoryBalance
    {

        private readonly IMayorAddRepository _mayorAddRepository;
        public WriteMayoryBalance(IMayorAddRepository mayorAddRepository)
        {
            _mayorAddRepository= mayorAddRepository;
        }
        public int Id => throw new NotImplementedException();

        public void Delete()
        {
            _mayorAddRepository.Delete();
        }
       
        public MayoryBalance Insert(MayoryBalance entity)
        {
            throw new NotImplementedException();
        }

        public List<MayoryBalance> Insert(List<MayoryBalance> entity)
        {
            return _mayorAddRepository.Insert(entity);
        }
    }
}
