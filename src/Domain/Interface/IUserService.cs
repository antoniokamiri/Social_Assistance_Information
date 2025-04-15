using Domain.DTO.Response;

namespace Domain.Interface;

public interface IUserService
{
    Task<BaseResponse<string>> VerifyUserAsync(string email, string password);
    List<GetUserResponse> GetUsers();
}