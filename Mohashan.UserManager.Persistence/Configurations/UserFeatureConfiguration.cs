using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mohashan.UserManager.Domain.Entities;

namespace Mohashan.UserManager.Persistence.Configurations;

public class UserFeatureConfiguration : IEntityTypeConfiguration<UserFeature>
{
    public void Configure(EntityTypeBuilder<UserFeature> builder)
    {
        builder.Property(c => c.FeatureId)
            .IsRequired();

        builder.Property(c => c.UserId)
            .IsRequired();

        builder.Property(c=>c.Value)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(c => c.UserId);

        builder.HasIndex(c => c.FeatureId);
    }
}