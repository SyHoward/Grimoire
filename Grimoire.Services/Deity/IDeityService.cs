using Grimoire.Models.Deity;
using Grimoire.Models.User;

namespace Grimoire.Services.Deity;

public interface IDeityService
{
    Task<List<DeityRead>> GetDeitiesAsnyc();
    Task<bool> DeityCreateAsync(DeityCreate deity);
    Task<DeityDetail?> DeityByIdAsync(int deityId);
    Task<DeityEdit> GetDeityEditAsync(int? deityId);
    Task<bool> DeityEditAsync(int deityId, DeityEdit deity);
    Task<bool> DeityDeleteAsync(int deityId);
    Task<List<UserDeityAdd>> GetDeitiesForUserAsnyc();
}