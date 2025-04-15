using Domain.DTO.Response;
using Domain.Entities;
using Domain.Interface;
using Domain.IRepository;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services;

public class UserService(SignInManager<User> signInManager, IUnitOfWork unitOfWork) : IUserService
{
    private readonly SignInManager<User> _signInManager = signInManager;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public List<GetUserResponse> GetUsers()
    {
        return _unitOfWork.Repository<User>().GetAll().Select(x => new GetUserResponse
        {
            Id = x.Id,
            Names = x.DisplayName,
            Email = x.Email,
        }).ToList();
    }

    public async Task<BaseResponse<string>> VerifyUserAsync(string email, string password)
    {
        var user = await _signInManager.UserManager.FindByEmailAsync(email);

        if (user is null)
        {
            return BaseResponse<string>.Failure("User not found");
        }

        var result = await _signInManager.UserManager.CheckPasswordAsync(user, password);

        if (!result)
        {
            return BaseResponse<string>.Failure("User not found");
        }
        else
        {
            return BaseResponse<string>.Success(user.UserName!);
        }
    }
}