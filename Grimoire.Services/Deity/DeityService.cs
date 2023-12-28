using Grimoire.Data;
using Grimoire.Data.Entities;
using Grimoire.Models.Deity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;


namespace Grimoire.Services.Deity;

public class DeityService : IDeityService
{
    private readonly AppDbContext _context;
    public DeityService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> DeityCreateAsync(DeityCreate deity)
    {
        DeityEntity entity = new ()
        {
            Name = deity.Name,
            Power = deity.Power
        };
    _context.Deities.Add(entity);
    return await _context.SaveChangesAsync() == 1;
    }

    public async Task<List<DeityRead>> GetDeitiesAsnyc()
    {
        List<DeityRead> deities = await _context.Deities
            .Select(d => new DeityRead
            {
                DeityId = d.DeityId,
                Name = d.Name,
                Power = d.Power
            })
            .ToListAsync();
        return deities;
    }

    public async Task<DeityDetail?> DeityByIdAsync(int deityId)
    {
        DeityEntity? deity = await _context.Deities
            .FirstOrDefaultAsync(d => d.DeityId == deityId);

        return deity is null ? null : new()
        {
            DeityId = deity.DeityId,
            Name = deity.Name,
            Power = deity.Power
        };
    }

    public async Task<DeityEdit> GetDeityEditAsync(int? deityId)
    {
        var deity = await _context.Deities.FindAsync(deityId);

        DeityEdit model = new()
        {
            DeityId = deity.DeityId,
            Name = deity.Name,
            Power = deity.Power
        };

        return model;
    }


    public async Task<bool> DeityEditAsync(int deityId, DeityEdit deity)
    {
        var entity = await _context.Deities.FindAsync(deityId);

        if(entity is null)
            return false;

        entity.Name = deity.Name;
        entity.Power = deity.Power;

        _context.Deities.Update(entity);
        await _context.SaveChangesAsync();

        return true;
    }


    public async Task<bool> DeityDeleteAsync(int deityId)
    {
        var deityEntity = await _context.Deities.FindAsync(deityId);

        _context.Deities.Remove(deityEntity);
        return await _context.SaveChangesAsync() == 1;
    }

}
