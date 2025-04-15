namespace Domain.Entities.Common;

public abstract class BaseSoftDeleteEntity : BaseEntity, ISoftDelete
{
    public DateTime? DeletedDate { get; set; }
    public string? DeletedBy { get; set; }
}