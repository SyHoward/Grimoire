using Grimoire.Models.Correspondence;

namespace Grimoire.Services.Correspondence;

public interface ICorrespondenceService
{
    Task<bool> CorrespondenceCreateAsync(CorrespondenceCreate icon);
    Task<List<CorrespondenceRead>> GetCorrespondencesAsnyc();
    Task<CorrespondenceDetail?> CorrespondenceByIdAsync(int correspondenceId);
    Task<CorrespondenceEdit> GetCorrespondenceEditAsync(int? correspondenceId);
    Task<bool>CorrespondenceEditAsync(int correspondenceId, CorrespondenceEdit icon);
    Task<bool> CorrespondenceDeleteAsync(int correspondenceId);
}
