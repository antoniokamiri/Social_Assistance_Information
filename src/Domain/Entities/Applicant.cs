using Domain.Entities.Common;

namespace Domain.Entities;

public class Applicant : BaseSoftDeleteEntity
{

    public DateTime ApplicationDate { get; set; }

    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    
    public string? Status { get; set; }

    public int SexId { get; set; }
    public Sex? Sex { get; set; }

    public int Age { get; set; }

    public int MaritalStatusId { get; set; }
    public MaritalStatus? MaritalStatus { get; set; }

    public string? IDOrPassportNumber { get; set; }

    public int VillageId { get; set; }
    public Village? Village { get; set; }

    public string? PostalAddress { get; set; }
    public string? PhysicalAddress { get; set; }
    public string? TelephoneContact { get; set; }

    public ICollection<ApplicantProgram>? ProgramsAppliedFor { get; set; }

    public User? OfficialInfo { get; set; }
}
