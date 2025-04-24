using Domain.Entities;

namespace Domain.Interface;

public interface ICriteriaService
{
    List<AssistanceProgram> GetAssistanceProgram();
    List<MaritalStatus> GetMaritalStatus();
    List<Sex> GetGenders();
    List<County> GetCounties();
    List<SubCounty> GetSubCounties();
    List<Location> GetLocations();
    List<SubLocation> GetSubLocations();
    List<Village> GetVillages();
    List<string> GetStatus();
}
