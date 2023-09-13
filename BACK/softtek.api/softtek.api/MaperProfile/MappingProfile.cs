using AutoMapper;
using softtek.infrastructure.EntityFrameWorkDataAccess.Models;

namespace softtek.api.MaperProfile
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<softtek.domain.Entities.MayoryBalance, Report>()
                .ReverseMap();
            CreateMap<softtek.domain.Entities.MayoryBalance, Result>()
                .ReverseMap();
        }
    }
}
