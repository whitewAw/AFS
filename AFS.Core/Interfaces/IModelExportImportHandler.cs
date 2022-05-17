using AFS.Core.Model;

namespace AFS.Core.Interfaces
{
    public interface IModelExportImportHandler
    {
        Task ExportAsync(AFSModel model);
        Task<AFSModel?> ImportAsync(Stream inputStream);
        void InitializeModelAsync(AFSModel? model);
    }
}
