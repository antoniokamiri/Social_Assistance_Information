using Domain.Entities.Common;

namespace Domain.Entities;

public class SubLocation : Entity
{
    public string? SubLocationName { get; set; }

    public int LocationId { get; set; }
    public Location? Location { get; set; }

    public ICollection<Village>? Villages { get; set; }
}
