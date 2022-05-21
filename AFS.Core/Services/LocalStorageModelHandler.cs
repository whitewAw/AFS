using AFS.Core.Interfaces;
using AFS.Core.Model;
using Blazored.LocalStorage;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace AFS.Core.Services
{
    public class LocalStorageModelHandler : IModelStorageHandler
    {
        private ILocalStorageService storage;
        private AFSModel model;
        private ILogger<LocalStorageModelHandler> logger;

        public LocalStorageModelHandler(ILocalStorageService storage, AFSModel model, ILoggerFactory loggerFactory)
        {
            this.storage = storage;
            this.model = model;
            logger = loggerFactory.CreateLogger<LocalStorageModelHandler>();
        }

        public async Task InitializeModelAsync()
        {
            var readModel = await ReadModelAsync();
            if (readModel != null)
            {
                model.Init(readModel);
            }
        }

        public async Task<AFSModel?> ReadModelAsync()
        {
            var jsonModel = await storage.GetItemAsync<string>(AFSConstraints.ModelJsonName);
            if (jsonModel != null)
            {
                try
                {
                    return JsonSerializer.Deserialize<AFSModel>(jsonModel);
                    //UnicodeConverter.UnicodeEscapesIntoActualUnicodeCharacters(jsonModel)
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                }
            }
            return null;
        }

        public async Task WriteModelAsync(AFSModel model)
        {
            string jsonString = JsonSerializer.Serialize(model);
            await storage.SetItemAsync(AFSConstraints.ModelJsonName, jsonString);
        }
    }
}
