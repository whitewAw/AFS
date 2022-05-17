using System.Globalization;

namespace AFS.Core.Interfaces
{
    public interface ICultureStorageHandler
    {
        Task WriteCultureAsync(CultureInfo cultureInfo);

        Task<CultureInfo> ReadCultureAsync();

        Task InitializeCultureAsync();
    }
}
