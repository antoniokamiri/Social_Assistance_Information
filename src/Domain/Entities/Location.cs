using Domain.Entities.Common;

namespace Domain.Entities;

public class Location : Entity
{
    public string? LocationName { get; set; }

    public int SubCountyId { get; set; }
    public SubCounty? SubCounty { get; set; }

    public ICollection<SubLocation>? SubLocations { get; set; }
    public ICollection<Applicant>? Applicants { get; set; }

}
