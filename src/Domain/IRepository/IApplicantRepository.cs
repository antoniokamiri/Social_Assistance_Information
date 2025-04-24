using Domain.DTO.Request;
using Domain.Entities;

namespace Domain.IRepository;

public interface IApplicantRepository : IGenericRepository<Applicant>
{
    List<Applicant> GetApplications(GetApplicantsRequest request);
    Applicant? GetApplicationById(int id);
    List<ApplicantProgram> GetApplicantPrograms(int applicantId);
    Task<bool> DeleteApplicantPrograms(int applicantId);
    Task<bool> AddApplicantPrograms(ApplicantProgram request);


}