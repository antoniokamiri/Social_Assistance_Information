namespace Domain.DTO.Request;

public class RegisterApplicantsRequest
{
    public DateTime ApplicationDate { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string? Status { get; set; }
    public int SexId { get; set; }
    public int Age { get; set; }
    public int MaritalStatusId { get; set; }
    public string? IDOrPassportNumber { get; set; }
    public int VillageId { get; set; }
    public string? PostalAddress { get; set; }
    public string? PhysicalAddress { get; set; }
    public string? TelephoneContact { get; set; }

}
