using Domain.Entities.Common;

namespace Domain.Entities;

public class AssistanceProgram : BaseSoftDeleteEntity
{
    public string? ProgramName { get; set; }

    public ICollection<Applicant>? Applicants { get; set; }
}
