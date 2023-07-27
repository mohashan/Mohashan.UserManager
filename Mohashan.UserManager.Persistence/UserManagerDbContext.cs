using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Mohashan.UserManager.Domain.Common;
using Mohashan.UserManager.Domain.Entities;

namespace Mohashan.UserManager.Persistence;

public class UserManagerDbContext:DbContext
{
    public UserManagerDbContext(DbContextOptions<UserManagerDbContext> options ):base(options)
    {
        
    }
    public DbSet<Feature> Features { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<UserType> UserTypes{ get; set; }
    public DbSet<UserGroup> userGroups { get; set; }
    public DbSet<UserFeature> userFeatures { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserManagerDbContext).Assembly);
        var seedCreator = "Seeder";

        var user1Guid = Guid.NewGuid();

        var feature1Guid = Guid.NewGuid();
        var feature2Guid = Guid.NewGuid();

        var group1Guid = Guid.NewGuid();
        var group2Guid = Guid.NewGuid();

        var userFeature1Guid = Guid.NewGuid();
        var userFeature2Guid = Guid.NewGuid();

        var userGroup1Guid = Guid.NewGuid();
        var userGroup2Guid = Guid.NewGuid();

        var userType1Guid = Guid.NewGuid();
        var userType2Guid = Guid.NewGuid();

        modelBuilder.Entity<Feature>().HasData(new Feature
        {
            CreatedBy = seedCreator,
            DataType = typeof(string).Name,
            CreatedDateTime = DateTime.Now,
            Id = feature1Guid,
            Name = "MobileNumber",
            
        }) ;

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