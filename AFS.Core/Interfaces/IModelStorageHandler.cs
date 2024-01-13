using AFS.Core.Models;

namespace AFS.Core.Interfaces
{
    public interface IModelStorageHandler
    {
        Task WriteModelAsync(AFSModel model);
        Task<AFSModel?> ReadModelAsync();
        Task InitializeModelAsync();
    }
}
