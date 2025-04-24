using Domain.Entities;

namespace Domain.DTO.Request;

public class RegisterApplicantsRequest
{
    public DateTime ApplicationDate { get; set; }
    public string? Names { get; set; }
    public string? Status { get; set; }
    public int SexId { get; set; }
    public int Age { get; set; }
    public int MaritalStatusId { get; set; }
    public string? IDOrPassportNumber { get; set; }
    public int CountyId { get; set; }
    public int SubCountyId { get; set; }
    public int LocationId { get; set; }
    public int SubLocationId { get; set; }
    public int VillageId { get; set; }
    public string? PostalAddress { get; set; }
    public string? PhysicalAddress { get; set; }
    public string? TelephoneContact { get; set; }
    public List<int>? ProgramsAppliedFor { get; set; }

}

public class UpdateApplicantsRequest
{
    public int Id { get; set; }
    public DateTime ApplicationDate { get; set; }
    public string? Names { get; set; }
    public string? Status { get; set; }
    public int SexId { get; set; }
    public int Age { get; set; }
    public int MaritalStatusId { get; set; }
    public string? IDOrPassportNumber { get; set; }
    public int CountyId { get; set; }
    public int SubCountyId { get; set; }
    public int LocationId { get; set; }
    public int SubLocationId { get; set; }
    public int VillageId { get; set; }
    public string? PostalAddress { get; set; }
    public string? PhysicalAddress { get; set; }
    public string? TelephoneContact { get; set; }
    public List<int>? ProgramsAppliedFor { get; set; }

}

