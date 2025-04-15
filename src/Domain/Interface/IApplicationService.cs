using Domain.DTO.Request;
using Domain.DTO.Response;
using Domain.Entities;

namespace Domain.Interface;
public interface IApplicationService
{
    List<GetApplicantsResponse> GetApplications(GetApplicantsRequest request);
    GetApplicantsResponse FindApplicant(int applicationId);

    BaseResponse RegisterApplication(Applicant request);
    BaseResponse UpdateApplication(Applicant request);
    BaseResponse ApproveApplication(ApplicantApprovalsRequest request);
}
