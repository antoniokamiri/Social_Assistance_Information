namespace Domain.Entities.Common;

public abstract class BaseEntity : Entity
{
    public virtual DateTime? Created { get; set; }
    public virtual string? CreatedBy { get; set; }
    public virtual DateTime? LastModified { get; set; }
    public virtual string? LastModifiedBy { get; set; }
}
