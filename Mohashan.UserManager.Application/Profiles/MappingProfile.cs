using AutoMapper;
using Mohashan.UserManager.Application.Features.Users;
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
    }
}
