using Grimoire.Data;
using Grimoire.Data.Entities;
using Grimoire.Models.Correspondence;
using Microsoft.EntityFrameworkCore;

namespace Grimoire.Services.Correspondence;

public class CorrespondenceService : ICorrespondenceService
{
    private readonly AppDbContext _context;
    public CorrespondenceService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> CorrespondenceCreateAsync(CorrespondenceCreate icon)
    {
        CorrespondenceEntity entity = new ()
        {
            CorrespondenceId = icon.CorrespondenceId,
            Name = icon.Name
        };
    _context.Correspondences.Add(entity);
    return await _context.SaveChangesAsync() == 1;
    }

    public async Task<List<CorrespondenceRead>> GetCorrespondencesAsnyc()
    {
        List<CorrespondenceRead> icons = await _context.Correspondences
            .Select(i => new CorrespondenceRead
            {
                CorrespondenceId = i.CorrespondenceId,
                Name = i.Name,
            })
            .ToListAsync();
        return icons;
    }

    public async Task<CorrespondenceDetail?> CorrespondenceByIdAsync(int correspondenceId)
    {
        CorrespondenceEntity? icon = await _context.Correspondences
            .FirstOrDefaultAsync(d => d.CorrespondenceId == correspondenceId);

        return icon is null ? null : new()
        {
            CorrespondenceId = icon.CorrespondenceId,
            Name = icon.Name,
        };
    }

    public async Task<CorrespondenceEdit> GetCorrespondenceEditAsync(int? correspondenceId)
    {
        var icon = await _context.Correspondences.FindAsync(correspondenceId);

        CorrespondenceEdit model = new()
        {
            CorrespondenceId = icon.CorrespondenceId,
            Name = icon.Name,

        };

        return model;
    }


    public async Task<bool>CorrespondenceEditAsync(int correspondenceId, CorrespondenceEdit icon)
    {
        var entity = await _context.Correspondences.FindAsync(correspondenceId);

        if(entity is null)
            return false;

        entity.Name = icon.Name;

        _context.Correspondences.Update(entity);
        await _context.SaveChangesAsync();

        return true;
    }


    public async Task<bool> CorrespondenceDeleteAsync(int correspondenceId)
    {
        var correspondenceEntity = await _context.Correspondences.FindAsync(correspondenceId);

        _context.Correspondences.Remove(correspondenceEntity);
        return await _context.SaveChangesAsync() == 1;
    }

}
