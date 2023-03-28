using System.Security.Claims;
using Blog.BLL.Services.Contracts;
using Blog.DAL.DbConfig;
using Blog.DAL.Entities.DTOs;
using Blog.DAL.Entities.Models.Domain;
using Blog.DAL.Entities.Responses;
using Blog.DAL.Entities.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Blog.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthorizationController : ControllerBase
{
    private readonly DataContext _context;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ITokenService _tokenService;

    public AuthorizationController(
        DataContext context,
        UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager,
        ITokenService tokenService
    )
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
        _tokenService = tokenService;
    }

    [HttpPost("Registration")]
    public async Task<IActionResult> Register([FromBody] RegistrationDto model)
    {
        var status = new Status();
        if (!ModelState.IsValid)
        {
            status.StatusCode = 0;
            status.Message = "Please pass all the required fields.";
            return Ok(status);
        }

        // Check if user exists
        var userExist = await _userManager.FindByNameAsync(model.Username);
        if (userExist != null)
        {
            status.StatusCode = 0;
            status.Message = "Username already exists.";
            return Ok(status);
        }

        var user = new AppUser()
        {
            UserName = model.Username,
            SecurityStamp = Guid.NewGuid().ToString(),
            Email = model.Email,
            Fullname = model.Fullname,
            PhoneNumber = model.PhoneNumber
        };

        // Create user here
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            status.StatusCode = 0;
            status.Message = "User creation failed";
            return Ok(status);
        }

        // Add roles
        // For admin registration, make use of UserRole.Admin instead of UserRole.User
        if (!await _roleManager.RoleExistsAsync(UserRole.User))
            await _roleManager.CreateAsync(new IdentityRole(UserRole.User));

        if (await _roleManager.RoleExistsAsync(UserRole.User))
            await _userManager.AddToRoleAsync(user, UserRole.User);

        status.StatusCode = 1;
        status.Message = "Successfully registered";

        return Ok(status);
    }

    [HttpPost("Login")]
    public async Task<ActionResult> Login([FromBody] LoginDto model)
    {
        var user = await _userManager.FindByNameAsync(model.Username);
        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var token = _tokenService.GetToken(authClaims);
            var refreshToken = _tokenService.GetRefreshToken();
            var tokenInfo = await _context.TokenInfos.FirstOrDefaultAsync(x => x.Username == user.UserName);
            if (tokenInfo == null)
            {
                var info = new TokenInfo()
                {
                    Username = user.UserName,
                    RefreshToken = refreshToken,
                    RefreshTokenExpiryDate = DateTime.Now.AddDays(7)
                };
            }
            else
            {
                tokenInfo.RefreshToken = refreshToken;
                tokenInfo.RefreshTokenExpiryDate = DateTime.Now.AddDays(7);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(new LoginResponse()
            {
                Name = user.Fullname,
                Username = user.UserName,
                Token = token.TokenString,
                Expiration = token.ValidTo,
                StatusCode = 1,
                Message = "Logged In"
            });
        }

        // Login failed condition
        return Ok(new LoginResponse()
        {
            StatusCode = 0,
            Message = "Invalid username or password",
            Token = "",
            Expiration = null
        });
    }

    [HttpPost("ChangePassword")]
    public async Task<IActionResult> ChangePassword(ChangePasswordDto model)
    {
        var status = new Status();
        // check validations
        if (!ModelState.IsValid)
        {
            status.StatusCode = 0;
            status.Message = "Please pass all the valid fields";
            return Ok(status);
        }

        // lets find the user
        var user = await _userManager.FindByNameAsync(model.Username);
        if (user is null)
        {
            status.StatusCode = 0;
            status.Message = "Invalid username";
            return Ok(status);
        }

        // check current password
        if (!await _userManager.CheckPasswordAsync(user, model.CurrentPassword))
        {
            status.StatusCode = 0;
            status.Message = "Invalid current password";
            return Ok(status);
        }

        // change password here
        var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        if (!result.Succeeded)
        {
            status.StatusCode = 0;
            status.Message = "Failed to change password";
            return Ok(status);
        }

        status.StatusCode = 1;
        status.Message = "Password change was successful";
        return Ok(result);
    }

    [HttpPost("AdminRegistration")]
    public async Task<IActionResult> AdminRegistration([FromBody] RegistrationDto model)
    {
        var status = new Status();
        if (!ModelState.IsValid)
        {
            status.StatusCode = 0;
            status.Message = "Please pass all the required fields";
            return Ok(status);
        }

        // check if user exists
        var userExists = await _userManager.FindByNameAsync(model.Username);
        if (userExists != null)
        {
            status.StatusCode = 0;
            status.Message = "Username already exists.";
            return Ok(status);
        }

        var user = new AppUser
        {
            UserName = model.Username,
            SecurityStamp = Guid.NewGuid().ToString(),
            Email = model.Email,
            Fullname = model.Fullname,
            PhoneNumber = model.PhoneNumber
        };
        // create a user here
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            status.StatusCode = 0;
            status.Message = "User creation failed";
            return Ok(status);
        }

        // add roles here
        // for admin registration UserRoles.Admin instead of UserRoles.Roles
        if (!await _roleManager.RoleExistsAsync(UserRole.Admin))
            await _roleManager.CreateAsync(new IdentityRole(UserRole.Admin));

        if (await _roleManager.RoleExistsAsync(UserRole.Admin))
            await _userManager.AddToRoleAsync(user, UserRole.Admin);

        status.StatusCode = 1;
        status.Message = "Sucessfully registered";
        return Ok(status);
    }
}
