using softtek.application.Interfaces.Mayor;
using softtek.Application.Interfaces.Mayor;
using softtek.domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace softtek.Application.Queries.Mayor
{
    public class GetMayoryBalance : IGetMayoryBalance
    {
        private readonly IMayorGetRepository _mayorGetRepository;
        public GetMayoryBalance(IMayorGetRepository mayorGetRepository)
        {
            _mayorGetRepository = mayorGetRepository;
        }
        public async Task< List<MayoryBalance>> get()
        {
            return await _mayorGetRepository.get();
        }

        public MayoryBalance get(int id)
        {
            return _mayorGetRepository.get(id);
        }
    }
}
