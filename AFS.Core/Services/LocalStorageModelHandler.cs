using AFS.Core.Interfaces;
using AFS.Core.Model;
using Blazored.LocalStorage;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using System.Text.Json;

namespace AFS.Core.Services
{
    public class LocalStorageModelHandler : IModelStorageHandler
    {
        private ILocalStorageService storage;
        private AFSModel model;
        private ILogger<LocalStorageModelHandler> logger;
        private HttpClient http;

        public LocalStorageModelHandler(ILocalStorageService storage, AFSModel model, ILoggerFactory loggerFactory, HttpClient http)
        {
            this.storage = storage;
            this.model = model;
            logger = loggerFactory.CreateLogger<LocalStorageModelHandler>();
            this.http = http;
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
            try
            {
                return await http.GetFromJsonAsync<AFSModel>("PJSC_AZOVSTAL_IRON_2019_2020.json");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
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