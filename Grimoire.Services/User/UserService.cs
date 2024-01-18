using Grimoire.Data;
using Grimoire.Data.Entities;
using Grimoire.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Grimoire.Services.User;

public class UserService : IUserService
{

    private readonly AppDbContext _context;
    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;

    public UserService(AppDbContext context, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }


    public async Task<bool> LoginAsync(UserLogin model)
    {
        var user = await _userManager.FindByNameAsync(model.UserName);
        if (user is null)
            return false;
        
        var isValidPassword = await _userManager.CheckPasswordAsync(user, model.Password);
        if (isValidPassword == false)
            return false;


        await _signInManager.SignInAsync(user, true);
        return true;
    }

    public async Task LogoutAsync() => await _signInManager.SignOutAsync();


    public async Task<bool> RegisterUserAsync(UserRegister model)
    {
        if(await UserExistsAsync(model.Email, model.UserName))
            return false;

        UserEntity user = new()
        {
            UserName = model.UserName,
            Email = model.Email
        };

        var createResult = await _userManager.CreateAsync(user, model.Password);
        return createResult.Succeeded;
    }

    public async Task<bool> AddDeityToUser(int userId, int[] selectedDeityIds)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user != null)
        {
            var selectedDeities = await _context.Deities
                .Where(d => selectedDeityIds.Contains(d.DeityId))
                .ToListAsync();

            ((List<DeityEntity>)user.Deities).AddRange(selectedDeities);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }


    private async Task<bool> UserExistsAsync(string email, string userName)
    {
        var normalizedEmail = _userManager.NormalizeEmail(email);
        var normalizedUserName = _userManager.NormalizeName(userName);

        return await _context.Users.AnyAsync(u => 
            u.NormalizedEmail == normalizedEmail ||
            u.NormalizedUserName == normalizedUserName
        );
    }
}
