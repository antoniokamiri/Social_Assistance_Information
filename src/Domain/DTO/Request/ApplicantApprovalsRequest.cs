namespace Domain.DTO.Request;

public class ApplicantApprovalsRequest
{
    public int Id { get; set; }
    public string? Status { get; set; }
    public string? UserId { get; set; }

}