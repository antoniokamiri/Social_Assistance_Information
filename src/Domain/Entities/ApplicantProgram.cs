namespace Domain.Entities;

public class ApplicantProgram
{
    public int ApplicantId { get; set; }
    public Applicant? Applicant { get; set; }

    public int AssistanceProgramId { get; set; }
    public AssistanceProgram? AssistanceProgram { get; set; }
}
