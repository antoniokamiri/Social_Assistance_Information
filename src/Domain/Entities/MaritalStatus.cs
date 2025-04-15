using Domain.Entities.Common;

namespace Domain.Entities;

public class MaritalStatus : Entity
{
    public string? Status { get; set; }

    public ICollection<Applicant>? Applicants { get; set; }
}
