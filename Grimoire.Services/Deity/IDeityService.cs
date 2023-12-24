namespace Grimoire.Services.Deity;

public interface IDeityService
{
    Task<List<DeityViewModel>> GetDeitiesAsnyc();
}
