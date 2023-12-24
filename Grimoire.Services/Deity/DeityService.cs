using Grimoire.Data;
using Grimoire.Models.Deity;


namespace Grimoire.Services.Deity;

public class DeityService : IDeityService
{
    private readonly AppDbContext _context;
    public DeityService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<DeityViewModel>> GetDeitiesAsnyc()
    {
        return await _c
    }

}
