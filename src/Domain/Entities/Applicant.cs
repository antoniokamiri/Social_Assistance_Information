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

    public int CountyId { get; set; }
    public County? County { get; set; }
    public int SubCountyId { get; set; }
    public SubCounty? SubCounty { get; set; }
    public int LocationId { get; set; }
    public Location? Location { get; set; }
    public int SubLocationId { get; set; }
    public SubLocation? SubLocation { get; set; }
    public int VillageId { get; set; }
    public Village? Village { get; set; }

    public string? PostalAddress { get; set; }
    public string? PhysicalAddress { get; set; }
    public string? TelephoneContact { get; set; }

    public ICollection<AssistanceProgram>? ProgramsAppliedFor { get; set; }

    public string? UserId { get; set; }
    public User? User { get; set; }
}
