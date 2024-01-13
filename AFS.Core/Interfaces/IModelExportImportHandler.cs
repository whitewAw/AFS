using AFS.Core.Models;

namespace AFS.Core.Interfaces
{
    public interface IModelExportImportHandler
    {
        Task ExportAsync(AFSModel model);
        Task<AFSModel?> ImportAsync(Stream inputStream);
        void InitializeModel(AFSModel? model);
    }
}
