namespace Domain.DTO.Request;
public class GetApplicantsRequest
{
    public DateTime? ApplicationDate { get; set; }
    public string? Name { get; set; }
    public string[]? Status { get; set; }
    public string[]? ApprovedBy { get; set; }
    public int[]? VillageId { get; set; }
    public int[]? CountyId { get; set; }
    public int[]? SubCountyId { get; set; }
    public int[]? LocationId { get; set; }
    public int[]? SubLocationId { get; set; }
}
