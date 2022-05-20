using AFS.Core.Interfaces;
using Blazored.LocalStorage;
using Microsoft.Extensions.Logging;
using System.Globalization;
namespace AFS.Core.Services
{
    public class LocalStorageCultureHandler : ICultureStorageHandler
    {
        private ILocalStorageService storage;
        private ILogger<LocalStorageCultureHandler> logger;

        public LocalStorageCultureHandler(ILocalStorageService storage, ILoggerFactory loggerFactory)
        {
            this.storage = storage;
            logger = loggerFactory.CreateLogger<LocalStorageCultureHandler>();
        }

        public async Task<CultureInfo> ReadCultureAsync()
        {
            var langCulture = await storage.GetItemAsync<string>("lang_culture");
            if (langCulture != null)
            {
                try
                {
                    return new CultureInfo(langCulture);
                    //UnicodeConverter.UnicodeEscapesIntoActualUnicodeCharacters(langCulture)
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                }
            }
            return new CultureInfo("uk-UA");
        }

        public async Task InitializeCultureAsync()
        {
            CultureInfo defualtCulture = await ReadCultureAsync();
            CultureInfo.DefaultThreadCurrentCulture = defualtCulture;
            CultureInfo.DefaultThreadCurrentUICulture = defualtCulture;
        }

        public async Task WriteCultureAsync(CultureInfo cultureInfo)
        {
            await storage.SetItemAsync("lang_culture", cultureInfo.Name);
        }
    }
}
