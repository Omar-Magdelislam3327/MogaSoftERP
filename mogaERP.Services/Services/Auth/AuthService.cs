using Microsoft.AspNetCore.Identity;
using mogaERP.Domain.Contracts.Auth;
using mogaERP.Domain.Entities;
using mogaERP.Domain.Interfaces.Auth;
using mogaERP.Domain.Wrappers;

namespace mogaERP.Services.Services.Auth;
public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IJwtProvider _jwtProvider;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IJwtProvider jwtProvider,
        RoleManager<IdentityRole> roleManager

        )
    {
        _userManager = userManager;
        _jwtProvider = jwtProvider;
        _roleManager = roleManager;
        _signInManager = signInManager;
    }

    public async Task<ApiResponse<AuthResponse>> LoginAsync(LoginUserRequest request, CancellationToken cancellationToken)
    {
        if (await _userManager.FindByNameAsync(request.UserName) is not { } user)
            return ApiResponse<AuthResponse>.Failure(AppErrors.InvalidCredentials);

        var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);

        if (result.Succeeded)
        {
            var (token, expiresIn) = _jwtProvider.GenerateToken(user);

            var roles = await _userManager.GetRolesAsync(user);

            await _userManager.UpdateAsync(user);

            string roleId = null;

            if (!string.IsNullOrEmpty(roles.FirstOrDefault()))
            {
                var role = await _roleManager.FindByNameAsync(roles?.FirstOrDefault());
                roleId = role?.Id;
            }

            var response = new AuthResponse
            {
                UserId = user.Id,
                UserName = user.UserName,
                ExpiresIn = expiresIn,
                FullName = user.Name,
                Token = token
            };

            return ApiResponse<AuthResponse>.Success(AppErrors.SuccessLogin, response);
        }

        return ApiResponse<AuthResponse>.Failure(AppErrors.InvalidCredentials);
    }

    public async Task<ApiResponse<string>> RegisterAsync(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var emailIsExists = await _userManager.FindByEmailAsync(request.Email) is not null;

        if (emailIsExists)
            return ApiResponse<string>.Failure(AppErrors.DuplicateEmail);

        var user = new ApplicationUser
        {
            Name = request.Name,
            Email = request.Email,
            UserName = request.Username,
            IsActive = true,
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            //var roleAssignResult = await _userManager.AddToRoleAsync(user, request.RoleName);

            //if (!roleAssignResult.Succeeded)
            //    return ApiResponse<string>.Failure(AppErrors.TransactionFailed);

            return ApiResponse<string>.Success(AppErrors.SuccessRegister);
        }

        var error = result.Errors.First();

        return ApiResponse<string>.Failure(AppErrors.TransactionFailed);
    }
}
