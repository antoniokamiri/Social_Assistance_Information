using Domain.DTO.Request;
using Domain.DTO.Response;
using Domain.Entities;

namespace Domain.Interface;
public interface IApplicationService
{
    List<GetApplicantsResponse> GetApplications(GetApplicantsRequest request);
    GetApplicantsResponse FindApplicant(int applicationId);
    Task<BaseResponse> RegisterApplication(RegisterApplicantsRequest request);
    Task<BaseResponse> UpdateApplication(UpdateApplicantsRequest request);
}
