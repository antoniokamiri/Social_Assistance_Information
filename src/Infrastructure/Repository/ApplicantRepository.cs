﻿using Domain.DTO.Request;
using Domain.Entities;
using Domain.IRepository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Repository;

public class ApplicantRepository(AppDBContext dbContext) : GenericRepository<Applicant>(dbContext), IApplicantRepository
{
    public async Task<bool> AddApplications(Applicant request)
    {
        try
        {
            var application = _dbContext.Applicants.Add(request);


            foreach (var item in request.ProgramsAppliedFor!)
            {
                var attachProgram = new ApplicantProgram() { ApplicantId = request.Id, Applicant = request, AssistanceProgramId = item.Id };
                _dbContext.ApplicantPrograms.Add(attachProgram);
            }

            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {

            return false;
        }

    }

    public async Task<bool> UpdateApplications(Applicant request)
    {
        try
        {
            var application = _dbContext.Applicants.Add(request);
            await _dbContext.SaveChangesAsync();

            var program = await _dbContext.ApplicantPrograms.Where(a => a.ApplicantId == request.Id).ToListAsync();

            foreach (var item in request.ProgramsAppliedFor!)
            {
                if (!program.Any(p => p.AssistanceProgramId == item.Id))
                {
                    var attachProgram = new ApplicantProgram() { ApplicantId = request.Id, AssistanceProgramId = item.Id };
                    _dbContext.ApplicantPrograms.Add(attachProgram);
                }
            }

            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            return false;
        }

    }

    public List<Applicant> GetApplications(GetApplicantsRequest request)
    {
        IQueryable<Applicant> query = _dbContext.Set<Applicant>()
                    .Include(x => x.Sex)
                    .Include(x => x.User)
                    .Include(x => x.MaritalStatus)
                    .Include(x => x.County)
                    .Include(x => x.SubCounty)
                    .Include(x => x.Location)
                    .Include(x => x.SubLocation)
                    .Include(x => x.Village);

        if (request is null) return [.. query];

        if (!string.IsNullOrEmpty(request.Name))
        {
            query = query.Where(x => (EF.Functions.Like(x.FirstName, $"%{request.Name}%")) 
            || (EF.Functions.Like(x.MiddleName, $"%{request.Name}%")) || (EF.Functions.Like(x.LastName, $"%{request.Name}%")));
        }
        if (request.Status != null && request.Status.Count() > 0)
        {
            query = query.Where(x => request.Status.Contains(x.Status));
        }
        if (request.ApprovedBy != null && request.ApprovedBy.Count() > 0)
        {
            query = query.Where(x => request.ApprovedBy.Contains(x.UserId));
        }
        if (request.ApplicationDate.HasValue)
        {
            query = query.Where(x => request.ApplicationDate.Value.Date == x.ApplicationDate.Date);
        }
        if (request.CountyId != null && request.CountyId.Count() > 0)
        {
            query = query.Where(x => request.CountyId.Contains(x.CountyId));
        }

        if (request.SubCountyId != null && request.SubCountyId.Count() > 0)
        {
            query = query.Where(x => request.SubCountyId.Contains(x.SubCountyId));
        }

        if (request.LocationId != null && request.LocationId.Count() > 0)
        {
            query = query.Where(x => request.LocationId.Contains(x.LocationId));
        }

        if (request.SubLocationId != null && request.SubLocationId.Count() > 0)
        {
            query = query.Where(x => request.SubLocationId.Contains(x.SubLocationId));
        }

        if (request.VillageId != null && request.VillageId.Count() > 0)
        {
            query = query.Where(x => request.VillageId.Contains(x.VillageId));
        }

        return [.. query.OrderByDescending(x => x.ApplicationDate)];
    }
}
