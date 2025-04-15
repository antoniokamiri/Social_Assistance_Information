using Domain.Entities.Common;

namespace Domain.Entities;

public class Sex : Entity
{
    public string? Name { get; set; }
    public ICollection<Applicant>? Applicants { get; set; }
}
