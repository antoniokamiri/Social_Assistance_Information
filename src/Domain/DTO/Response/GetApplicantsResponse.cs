using Domain.Entities;

namespace Domain.DTO.Response;
public class GetApplicantsResponse
{
    public int Id { get; set; }
    public string ApplicantIdView
    {
        get { return "A" + Id.ToString().PadLeft(5, '0'); }
    }
    public DateTime ApplicationDate { get; set; }

    public string? Name { get; set; }

    public string? Status { get; set; }

    public int SexId { get; set; }
    public string? Gender { get; set; }

    public int Age { get; set; }

    public int MaritalStatusId { get; set; }
    public string? MaritalStatus { get; set; }

    public string? IDOrPassportNumber { get; set; }

    public int CountyId { get; set; }
    public string? County { get; set; }
    public int SubCountyId { get; set; }
    public string? SubCounty { get; set; }
    public int LocationId { get; set; }
    public string? Location { get; set; }
    public int SubLocationId { get; set; }
    public string? SubLocation { get; set; }
    public int VillageId { get; set; }
    public string? Village { get; set; }

    public string? PostalAddress { get; set; }
    public string? PhysicalAddress { get; set; }
    public string? TelephoneContact { get; set; }

    public List<AssistanceProgram>? ProgramsAppliedFor { get; set; }

    public string? UserId { get; set; }
    public string? User { get; set; }
}
