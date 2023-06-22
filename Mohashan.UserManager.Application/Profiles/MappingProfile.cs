﻿using AutoMapper;
using Mohashan.UserManager.Application.Features.Feature.Commands.CreateFeature;
using Mohashan.UserManager.Application.Features.Feature.Commands.UpdateFeature;
using Mohashan.UserManager.Application.Features.Feature.Queries.GetFeatureDetails;
using Mohashan.UserManager.Application.Features.Feature.Queries.GetFeaturesList;
using Mohashan.UserManager.Application.Features.Group.Commands.CreateGroup;
using Mohashan.UserManager.Application.Features.Group.Commands.UpdateGroup;
using Mohashan.UserManager.Application.Features.Group.Queries.GetGroupDetails;
using Mohashan.UserManager.Application.Features.Group.Queries.GetGroupList;
using Mohashan.UserManager.Application.Features.Users.Queries.GetGroupUsers;
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
        CreateMap<User, GroupUsersListVm>().ReverseMap();
        CreateMap<UserType,UserTypeDto>();

        CreateMap<User, UserFeaturesListVm>()
            .ForMember(c => c.UserId, opt => opt.MapFrom(c => c.Id))
            .ForMember(c => c.UserName, opt => opt.MapFrom(c => c.Name));

        CreateMap<UserFeature, UserFeaturesDto>()
            .ForMember(c => c.FeatureName, opt => opt.MapFrom(c => c.Feature.Name))
            .ForMember(c => c.FeatureDataType, opt => opt.MapFrom(c => c.Feature.DataType))
            .ForMember(c => c.FeatureDescription, opt => opt.MapFrom(c => c.Feature.Description));

        CreateMap<Group, GroupDetailVm>().ReverseMap();
        CreateMap<Group, GroupListVm>().ReverseMap();
        CreateMap<UserGroup, UserGroupDto>().ReverseMap();
        CreateMap<Group, CreateGroupCommand>().ReverseMap();
        CreateMap<Group, UpdateGroupCommand>().ReverseMap();

        CreateMap<Feature, FeatureDetailVm>().ReverseMap();
        CreateMap<Feature, FeaturesListVm>().ReverseMap();
        CreateMap<Feature, CreateFeatureCommand>().ReverseMap();
        CreateMap<Feature, UpdateFeatureCommand>().ReverseMap();
    }
}
