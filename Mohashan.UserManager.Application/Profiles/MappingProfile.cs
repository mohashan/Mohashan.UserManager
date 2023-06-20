using AutoMapper;
using Mohashan.UserManager.Application.Features.Users.Queries.GetUserDetails;
using Mohashan.UserManager.Application.Features.Users.Queries.GetUserFeatures;
using Mohashan.UserManager.Application.Features.Users.Queries.GetUsersList;
using Mohashan.UserManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.Profiles;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<User,UsersListVm>().ReverseMap();
        CreateMap<User, UserDetailVm>().ReverseMap();
        CreateMap<UserType,UserTypeDto>();

        CreateMap<User, UserFeaturesListVm>()
            .ForMember(c => c.UserId, opt => opt.MapFrom(c => c.Id))
            .ForMember(c => c.UserName, opt => opt.MapFrom(c => c.Name));

        CreateMap<UserFeature, UserFeaturesDto>()
            .ForMember(c => c.FeatureName, opt => opt.MapFrom(c => c.Feature.Name))
            .ForMember(c => c.FeatureDataType, opt => opt.MapFrom(c => c.Feature.DataType))
            .ForMember(c => c.FeatureDescription, opt => opt.MapFrom(c => c.Feature.Description));
    }
}
