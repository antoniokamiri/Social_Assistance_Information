using Domain.Entities.Common;

namespace Domain.Entities;

public class SubCounty : Entity
{
    public string? SubCountyName { get; set; }

    public int CountyId { get; set; }
    public County? County { get; set; }

    public ICollection<Location>? Locations { get; set; }
    public ICollection<Applicant>? Applicants { get; set; }

}
