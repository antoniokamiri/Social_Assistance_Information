namespace Domain.Entities.Common;
// used for marking entity deleted.
public interface ISoftDelete
{
    DateTime? DeletedDate { get; set; }
    string? DeletedBy { get; set; }
}
