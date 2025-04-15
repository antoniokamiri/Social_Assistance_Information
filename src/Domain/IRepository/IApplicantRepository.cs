using Domain.DTO.Request;
using Domain.Entities;

namespace Domain.IRepository;

public interface IApplicantRepository : IGenericRepository<Applicant>
{
    List<Applicant> GetApplications(GetApplicantsRequest request);
    Task<bool> AddApplications(Applicant request);
    Task<bool> UpdateApplications(Applicant request);
}