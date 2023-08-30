using Microsoft.EntityFrameworkCore;
using Mohashan.UserManager.Domain.Common;
using Mohashan.UserManager.Domain.Entities;

namespace Mohashan.UserManager.Persistence;

public class UserManagerDbContext : DbContext
{
    public UserManagerDbContext(DbContextOptions<UserManagerDbContext> options) : base(options)
    {
    }

    public DbSet<Feature> Features { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<UserType> UserTypes { get; set; }
    public DbSet<UserGroup> userGroups { get; set; }
    public DbSet<UserFeature> userFeatures { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserManagerDbContext).Assembly);
        var seedCreator = "Seeder";

        var user1Guid = Guid.Parse("{5c56c180-6147-4edf-a969-04b83bd49cfa}");

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

        modelBuilder.Entity<Feature>().HasData(new Feature
        {
            CreatedBy = seedCreator,
            DataType = typeof(string).Name,
            CreatedDateTime = DateTime.Now,
            Id = feature1Guid,
            Name = "MobileNumber",
        });

        modelBuilder.Entity<Feature>().HasData(new Feature
        {
            CreatedBy = seedCreator,
            DataType = typeof(string).Name,
            CreatedDateTime = DateTime.Now,
            Id = feature2Guid,
            Name = "Email",
        });

        modelBuilder.Entity<UserType>().HasData(new UserType
        {
            CreatedBy = seedCreator,
            CreatedDateTime = DateTime.Now,
            Id = userType1Guid,
            Name = "Human",
        });

        modelBuilder.Entity<UserType>().HasData(new UserType
        {
            CreatedBy = seedCreator,
            CreatedDateTime = DateTime.Now,
            Id = userType2Guid,
            Name = "System",
        });

        modelBuilder.Entity<User>().HasData(new User
        {
            CreatedBy = seedCreator,
            CreatedDateTime = DateTime.Now,
            Id = user1Guid,
            Name = "Admin",
            UserTypeId = userType1Guid
        });

        modelBuilder.Entity<Group>().HasData(new Group
        {
            CreatedBy = seedCreator,
            CreatedDateTime = DateTime.Now,
            Id = group1Guid,
            Name = "AdminGroup",
        });

        modelBuilder.Entity<Group>().HasData(new Group
        {
            CreatedBy = seedCreator,
            CreatedDateTime = DateTime.Now,
            Id = group2Guid,
            Name = "ReportGroup",
        });

        modelBuilder.Entity<UserGroup>().HasData(new UserGroup
        {
            CreatedBy = seedCreator,
            CreatedDateTime = DateTime.Now,
            Id = userGroup1Guid,
            GroupId = group1Guid,
            UserId = user1Guid,
        });

        modelBuilder.Entity<UserGroup>().HasData(new UserGroup
        {
            CreatedBy = seedCreator,
            CreatedDateTime = DateTime.Now,
            Id = userGroup2Guid,
            GroupId = group2Guid,
            UserId = user1Guid,
        });

        modelBuilder.Entity<UserFeature>().HasData(new UserFeature
        {
            CreatedBy = seedCreator,
            CreatedDateTime = DateTime.Now,
            Id = userFeature1Guid,
            FeatureId = feature1Guid,
            UserId = user1Guid,
            Value = "09011500119"
        });
        modelBuilder.Entity<UserFeature>().HasData(new UserFeature
        {
            CreatedBy = seedCreator,
            CreatedDateTime = DateTime.Now,
            Id = userFeature2Guid,
            FeatureId = feature2Guid,
            UserId = user1Guid,
            Value = "msh200x@gmail.com"
        });

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Deleted:
                    entry.Entity.IsDeleted = true;
                    entry.Entity.DeletedDateTime = DateTime.Now;
                    entry.State = EntityState.Modified;
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedDateTime = DateTime.Now;
                    break;

                case EntityState.Added:
                    entry.Entity.CreatedDateTime = DateTime.Now;
                    break;

                default:
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}