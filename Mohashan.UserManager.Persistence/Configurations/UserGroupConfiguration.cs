using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mohashan.UserManager.Domain.Entities;

namespace Mohashan.UserManager.Persistence.Configurations;

public class UserGroupConfiguration : IEntityTypeConfiguration<UserGroup>
{
    public void Configure(EntityTypeBuilder<UserGroup> builder)
    {
        builder.Property(c => c.UserId)
            .IsRequired();

        builder.Property(c => c.GroupId)
            .IsRequired();

        builder.HasIndex(c => c.UserId);

        builder.HasIndex(c => c.GroupId);
    }
}