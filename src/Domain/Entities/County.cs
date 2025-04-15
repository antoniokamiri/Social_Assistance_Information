using Domain.Entities.Common;

namespace Domain.Entities;

public class County : Entity
{
    public string? CountyName { get; set; }

    public ICollection<SubCounty>? SubCounties { get; set; }
}
