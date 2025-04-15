using Domain.Entities.Common;

namespace Domain.Entities;

public class Village : Entity
{
    public string? VillageName { get; set; }

    public int SubLocationId { get; set; }
    public SubLocation? SubLocation { get; set; }

    public ICollection<Applicant>? Applicants { get; set; }
}