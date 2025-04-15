using Domain.Entities;
using Domain.Interface;
using Domain.IRepository;

namespace Infrastructure.Services;

public class CriteriaService(IUnitOfWork unitOfWork) : ICriteriaService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public List<County> GetCounties()
    {
        return _unitOfWork.Repository<County>().GetAll();
    }

    public List<SubCounty> GetSubCounties()
    {
        return _unitOfWork.Repository<SubCounty>().GetAll();

    }

    public List<Location> GetLocations()
    {
        return _unitOfWork.Repository<Location>().GetAll();

    }
    public List<SubLocation> GetSubLocations()
    {
        return _unitOfWork.Repository<SubLocation>().GetAll();

    }
    public List<Village> GetVillages()
    {
        return _unitOfWork.Repository<Village>().GetAll();

    }

    public List<string> GetStatus()
    {
        return ["NEW", "APPROVED", "REJECTED"];
    }
}
