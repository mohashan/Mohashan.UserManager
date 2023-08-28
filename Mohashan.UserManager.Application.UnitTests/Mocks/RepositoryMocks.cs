using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Application.Features.Users.Queries.GetUserDetails;
using Mohashan.UserManager.Domain.Entities;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.UnitTests.Mocks;

public class RepositoryMocks
{
    public static Mock<IUserRepository> GetUserRepository()
    {
        var allUsers = users().Where(c=>!c.IsDeleted).ToList();
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository.Setup(repo => repo.GetListAsync()).ReturnsAsync(allUsers);
        mockUserRepository.Setup(repo => repo.GetAllPagedAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync((int count, int page) =>
        {
            return allUsers.OrderBy(c => c.Name).Skip((page - 1) * count).Take(count).ToList();
        });
        mockUserRepository.Setup(repo => repo.UsernameIsUnique(It.IsAny<string>())).ReturnsAsync((string name) =>
        {
            return !allUsers.Any(u => u.Name == name);
        });

        mockUserRepository.Setup(repo => repo.AddAsync(It.IsAny<User>())).ReturnsAsync((User user) =>
        {
            allUsers.Add(user);
            return user;
        });

        mockUserRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Guid id) =>
        {
            return allUsers.FirstOrDefault(c => c.Id == id);
        });
        mockUserRepository.Setup(repo => repo.GetUserFeatures(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync((Guid userId, int count, int page) =>
        {
            return allUsers.FirstOrDefault(c => c.Id == userId)?.UserFeatures?.Skip((page - 1) * count).Take(count).ToList();
        });

        mockUserRepository.Setup(repo => repo.GetGroupUsers(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync((Guid groupId, int count, int page) =>
        {
            return allUsers.Where(c => c != null && c.UserGroup != null && c.UserGroup.Any(d => d?.GroupId == groupId)).ToList();
        });

        mockUserRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Guid>())).Returns((Guid Id) =>
        {
            var user = allUsers.FirstOrDefault(c => c.Id == Id);
            if(user is null)
                throw new ArgumentException();

            user.IsDeleted = true;
            user.DeletedDateTime = DateTime.UtcNow;
            return Task.CompletedTask;
        });

        mockUserRepository.Setup(repo => repo.UpdateAsync(It.IsAny<User>())).Returns((User user) =>
        {
            var newUser = allUsers.FirstOrDefault(c => c.Id == user.Id);
            if (newUser is null)
                throw new ArgumentException();
            newUser.Name = user.Name;
            newUser.UserTypeId = user.UserTypeId;
            user.LastModifiedDateTime = DateTime.UtcNow;
            return Task.CompletedTask;
        });

        return mockUserRepository;
    }
    public static Mock<IUserTypeRepository> GetUserTypeRepository()
    {
        var allUserTypes = userTypes();

        Mock<IUserTypeRepository> mockUserTypeRepository = new Mock<IUserTypeRepository>();

        mockUserTypeRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Guid id) =>
        {
            return allUserTypes.FirstOrDefault(u => u.Id == id);
        });

        mockUserTypeRepository.Setup(repo => repo.GetListAsync()).ReturnsAsync(() =>
        {
            return allUserTypes;
        });

        return mockUserTypeRepository;
    }
    private static List<UserType> userTypes()
    {
        var userType1Guid = Guid.Parse("{334c067b-e114-4e18-891f-2b7c8e21c25f}");
        var userType2Guid = Guid.Parse("{84639c75-d591-4cac-a864-e706c08800f1}");

        return new List<UserType>
        {
            new UserType
            {
                Id = userType1Guid,
                Name = "User Type 1"
            },
            new UserType
            {
                Id = userType2Guid,
                Name = "User Type 2"
            },
        };
    }
    private static List<User> users()
    {
        var user1Guid = Guid.Parse("{5c56c180-6147-4edf-a969-04b83bd49cfa}");
        var user2Guid = Guid.Parse("{304cfc9e-6d2d-4db4-a678-43b51aab26f0}");

        var feature1Guid = Guid.Parse("{a9bbae60-9326-4059-ada5-ab38bb44436d}");
        var feature2Guid = Guid.Parse("{ae9c1443-7139-449a-8ba4-d08ddc5d92ec}");

        var group1Guid = Guid.Parse("{be8331cf-6893-4233-8efb-c485a179bb53}");
        var group2Guid = Guid.Parse("{2aa6ff03-b8d7-44cf-8937-21dd0ea0d706}");

        var userFeature1Guid = Guid.Parse("{a6251894-fd70-4cd4-b2bd-771f6f6df345}");
        var userFeature2Guid = Guid.Parse("{36681998-1486-4d22-9374-2eb84e401c79}");

        var userGroup1Guid = Guid.Parse("{e254a8e7-06a1-4c14-918d-5e65ab9109f9}");
        var userGroup2Guid = Guid.Parse("{e182d7f4-a5b3-4525-826b-eb7b9e72dbb7}");

        var userType1Guid = Guid.Parse("{334c067b-e114-4e18-891f-2b7c8e21c25f}");
        var userType2Guid = Guid.Parse("{84639c75-d591-4cac-a864-e706c08800f1}");
        return new List<User>
        {
            new User
            {
                Id = user1Guid,
                Name = "AdminTest",
                UserFeatures = new List<UserFeature>
                {
                    new UserFeature
                    {
                        Id = userFeature1Guid,
                        Feature = new Feature
                        {
                            Id = feature1Guid,
                            Name = "MobileNo"
                        },
                        Value = "+989011500119"
                    },
                    new UserFeature
                    {
                        Id = userFeature2Guid,
                        Feature = new Feature
                        {
                            Id = feature2Guid,
                            Name= "Email"
                        },
                        Value = "msh200x@gmail.com"

                    }
                },
                UserTypeId = userType1Guid,
                UserGroup = new List<UserGroup>
                {
                    new UserGroup
                    {
                        Id= userGroup1Guid,
                        GroupId = group1Guid,
                        UserId = user1Guid,
                        Group = new Group
                        {
                            Id = group1Guid,
                            Name = "AdminGroup",
                        }
                    }
                }
            },
            new User
            {
                Id = user2Guid,
                Name = "testUser1",
            },
            new User
            {
                Id = Guid.NewGuid(),
                Name = "testUser2",
            },
            new User
            {
                Id = Guid.NewGuid(),
                Name = "testUser3",
            },
            new User
            {
                Id = Guid.NewGuid(),
                Name = "testUser4",
            },
            new User
            {
                Id = Guid.NewGuid(),
                Name = "testUser5",
            },
            new User
            {
                Id = Guid.NewGuid(),
                Name = "testUser6",
            },
            new User
            {
                Id = Guid.NewGuid(),
                Name = "testUser7",
            },
            new User
            {
                Id = Guid.NewGuid(),
                Name = "testUser8",
            },
            new User
            {
                Id = Guid.NewGuid(),
                Name = "testUser9",
            },
            new User
            {
                Id = Guid.NewGuid(),
                Name = "testUser10",
            },
            new User
            {
                Id = Guid.NewGuid(),
                Name = "testUser11",
            },
        };
    }
}
