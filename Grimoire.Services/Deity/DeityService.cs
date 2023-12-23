using Grimoire.Data;

namespace Grimoire.Services.Deity;

public class DeityService : IDeityService
{
    private readonly AppDbContext _context;
    public DeityService(AppDbContext context)
    {
        _context = context;
    }


}
