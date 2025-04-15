using Domain.DTO.Request;
using Domain.DTO.Response;
using Domain.Entities;
using Domain.Interface;
using Domain.IRepository;

namespace Infrastructure.Services;
public class ApplicationService(IUnitOfWork unitOfWork) : IApplicationService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public BaseResponse ApproveApplication(ApplicantApprovalsRequest request)
    {
        var entity = _unitOfWork.Repository<Applicant>().GetById(request.Id);
        if (entity == null) { return BaseResponse<string>.Failure("Application not found."); }

        entity.Status = request.Status;
        entity.UserId = request.UserId; 

        var response = _unitOfWork.ApplicantRepository.Update(entity);

        if(response)
        {
            return BaseResponse<string>.Success("Approved");
        }
        else
        {
            return BaseResponse<string>.Failure("Error occured.");
        }
    }

    public GetApplicantsResponse FindApplicant(int applicationId)
    {
        var result = _unitOfWork.Repository<Applicant>().GetById(applicationId);
        if (result == null) return null;

        return new GetApplicantsResponse
        {
            Id = result.Id,
            Name = result.MiddleName is null ? $"{result.FirstName} {result.LastName}" : $"{result.FirstName} {result.MiddleName} {result.LastName}",
            Status = result.Status,
            SexId = result.SexId,
            Gender = result.Sex?.Name,
            Age = result.Age,
            MaritalStatusId = result.MaritalStatusId,
            MaritalStatus = result.MaritalStatus?.Status,
            IDOrPassportNumber = result.IDOrPassportNumber,
            CountyId = result.CountyId,
            County = result.County?.CountyName,
            SubCountyId = result.SubCountyId,
            SubCounty = result.SubCounty?.SubCountyName,
            LocationId = result.LocationId,
            Location = result.Location?.LocationName,
            SubLocation = result.SubLocation?.SubLocationName,
            SubLocationId = result.SubLocationId,
            VillageId = result.VillageId,
            Village = result.Village?.VillageName,
            PostalAddress = result.PostalAddress,
            PhysicalAddress = result.PhysicalAddress,
            TelephoneContact = result.TelephoneContact,
            UserId = result.UserId,
            User = result.User?.DisplayName,
        };

    }

    public List<GetApplicantsResponse> GetApplications(GetApplicantsRequest request)
    {
        var result = _unitOfWork.ApplicantRepository.GetApplications(request);

        return result.Select(x => new GetApplicantsResponse 
        { 
            Id = x.Id,
            Name = x.MiddleName is null ? $"{x.FirstName} {x.LastName}":$"{x.FirstName} {x.MiddleName} {x.LastName}",
            Status = x.Status,
            SexId = x.SexId,
            Gender = x.Sex?.Name,
            Age = x.Age,
            MaritalStatusId = x.MaritalStatusId,
            MaritalStatus = x.MaritalStatus?.Status,
            IDOrPassportNumber = x.IDOrPassportNumber,
            CountyId = x.CountyId,
            County = x.County?.CountyName,
            SubCountyId = x.SubCountyId,
            SubCounty = x.SubCounty?.SubCountyName,
            LocationId = x.LocationId,
            Location = x.Location?.LocationName,
            SubLocation = x.SubLocation?.SubLocationName,
            SubLocationId = x.SubLocationId,
            VillageId = x.VillageId,
            Village = x.Village?.VillageName,
            PostalAddress = x.PostalAddress,
            PhysicalAddress = x.PhysicalAddress,
            TelephoneContact = x.TelephoneContact,
            UserId = x.UserId,
            User = x.User?.DisplayName,
        }).ToList();
    }

    public BaseResponse RegisterApplication(Applicant request)
    {
        if(request.ProgramsAppliedFor is null) return BaseResponse<string>.Failure("Kindly select programs.");

        var response = _unitOfWork.ApplicantRepository.AddApplications(request);

        if (response.IsCompletedSuccessfully)
        {
            return BaseResponse<string>.Success("Applicant Added");
        }
        else
        {
            return BaseResponse<string>.Failure("Error occured.");
        }
    }

    public BaseResponse UpdateApplication(Applicant request)
    {
        var entity = _unitOfWork.Repository<Applicant>().GetById(request.Id);
        if (entity == null) { return BaseResponse<string>.Failure("Application not found."); }

        var response = _unitOfWork.ApplicantRepository.UpdateApplications(entity);

        if (response.IsCompletedSuccessfully)
        {
            return BaseResponse<string>.Success("Applicant Added");
        }
        else
        {
            return BaseResponse<string>.Failure("Error occured.");
        }
    }
}
