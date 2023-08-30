namespace Mohashan.UserManager.Domain.Common;

public abstract class AuditableEntity
{
    public string? CreatedBy { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedDateTime { get; set; }
    public bool IsDeleted { get; set; } = false;

    public string? DeletedBy { get; set; }
    public DateTime? DeletedDateTime { get; set; }
}