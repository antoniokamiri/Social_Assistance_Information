using Domain.DTO.Request;
using Domain.DTO.Response;
using Domain.Entities;
using Domain.Interface;
using Domain.IRepository;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Services;
public class ApplicationService(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor) : IApplicationService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IHttpContextAccessor _contextAccessor = contextAccessor;
    // Get application with Id
    public GetApplicantsResponse FindApplicant(int applicationId)
    {
        var result = _unitOfWork.ApplicantRepository.GetApplicationById(applicationId);
        if (result == null) return null;

        return new GetApplicantsResponse
        {
            Id = result.Id,
            Name = result.MiddleName is null ? $"{result.FirstName} {result.LastName}" : $"{result.FirstName} {result.MiddleName} {result.LastName}",
            Status = result.Status,
            SexId = result.SexId,
            Gender = result.Sex?.Name,
            Age = result.Age,
            ApplicationDate = result.ApplicationDate,
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
            ProgramsAppliedFor = [.. result.ProgramsAppliedFor],
        };

    }

    // Get application with filters if any
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
            ApplicationDate = x.ApplicationDate,
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
        }).OrderByDescending(i => i.Id).ToList();
    }
    // Register application
    public async Task<BaseResponse> RegisterApplication(RegisterApplicantsRequest request)
    {
        if(request.ProgramsAppliedFor is null) return BaseResponse<string>.Failure("Kindly select programs.");

        string[] words = request.Names is not null ? request.Names.Split(' ') : Array.Empty<string>();

        string firstName = words[0];
        string? middleName = words.Length == 2 ? string.Empty : words[1];
        string lastName = words.Length == 2 ? words[1] : words[2];

        var application = new Applicant
        {
            FirstName = firstName,
            MiddleName = middleName,
            LastName = lastName,
            Status = "NEW",
            SexId = request.SexId,
            Age = request.Age,
            MaritalStatusId = request.MaritalStatusId,
            IDOrPassportNumber = request.IDOrPassportNumber,
            PostalAddress = request.PostalAddress,
            ApplicationDate = request.ApplicationDate,
            PhysicalAddress = request.PhysicalAddress,
            TelephoneContact = request.TelephoneContact,
            CountyId = request.CountyId,
            SubCountyId = request.SubCountyId,
            LocationId = request.LocationId,
            SubLocationId = request.SubLocationId,
            VillageId = request.VillageId
        };
        _unitOfWork.ApplicantRepository.Add(application);

        var response = await _unitOfWork.SaveChangesAsync() > 0;

        foreach (var id in request.ProgramsAppliedFor!)
        {
            var attachProgram = new ApplicantProgram() { ApplicantId = application.Id, AssistanceProgramId = id, Applicant = application };
            _unitOfWork.ApplicantRepository.AddApplicantPrograms(attachProgram);
        }
        if (response)
        {
            return BaseResponse<string>.Success("Applicant Added");
        }
        else
        {
            return BaseResponse<string>.Failure("Error occured.");
        }
    }
    // updating Application 
    public async Task<BaseResponse> UpdateApplication(UpdateApplicantsRequest request)
    {
        var entity = _unitOfWork.Repository<Applicant>().GetById(request.Id);
        if (entity == null || entity.Status != "NEW") { return BaseResponse<string>.Failure("Application not found."); }

        // Approving applicant
        if(request.Status != "NEW" && entity.Status == "NEW")
        {
            var currentUser = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            if (currentUser == null) { return BaseResponse<string>.Failure("Error occured. User not valid."); }

            entity.Status = request.Status;
            entity.UserId = currentUser;
        }

        string[] words = request.Names is not null ? request.Names.Split(' ') : Array.Empty<string>();


        string firstName = words[0];
        string? middleName = words.Length == 2 ? string.Empty : words[1];
        string lastName = words.Length == 2 ? words[1]: words[2];

        entity.Age = request.Age;
        entity.FirstName = firstName;
        entity.MiddleName = middleName;
        entity.LastName = lastName;
        entity.MaritalStatusId = request.MaritalStatusId;
        entity.IDOrPassportNumber = request.IDOrPassportNumber;
        entity.ApplicationDate = request.ApplicationDate;
        entity.SexId = request.SexId;
        entity.LocationId = request.LocationId;
        entity.CountyId = request.CountyId;
        entity.SubCountyId = request.SubCountyId;
        entity.SubLocationId = request.SubLocationId;
        entity.VillageId = request.VillageId;
        entity.PhysicalAddress = request.PhysicalAddress;
        entity.PostalAddress = request.PostalAddress;
        entity.TelephoneContact = request.TelephoneContact;

        _unitOfWork.ApplicantRepository.Update(entity);

        var response = await _unitOfWork.SaveChangesAsync() > 0;

        var program = _unitOfWork.ApplicantRepository.DeleteApplicantPrograms(entity.Id);
        // Update programs if they are not oready in database.
        foreach (var id in request.ProgramsAppliedFor!)
        {
            var attachProgram = new ApplicantProgram() { ApplicantId = entity.Id, AssistanceProgramId = id };
            _unitOfWork.ApplicantRepository.AddApplicantPrograms(attachProgram);
        }


        if (response)
        {
            return BaseResponse<string>.Success("Applicant Added");
        }
        else
        {
            return BaseResponse<string>.Failure("Error occured when saving to database!!!");
        }
    }
}
