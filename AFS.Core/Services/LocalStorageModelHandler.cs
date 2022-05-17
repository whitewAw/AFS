using AFS.Core.Interfaces;
using AFS.Core.Model;
using Blazored.LocalStorage;
using System.Text.Json;

namespace AFS.Core.Services
{
    public class LocalStorageModelHandler : IModelStorageHandler
    {
        private ILocalStorageService storage;
        private AFSModel model;

        public LocalStorageModelHandler(ILocalStorageService storage, AFSModel model)
        {
            this.storage = storage;
            this.model = model;
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
            var jsonModel = await storage.GetItemAsync<string>("model-json");
            if (jsonModel != null)
            {
                try
                {
                    return JsonSerializer.Deserialize<AFSModel>(jsonModel);
                    //UnicodeConverter.UnicodeEscapesIntoActualUnicodeCharacters(jsonModel)
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return null;
        }

        public async Task WriteModelAsync(AFSModel model)
        {
            string jsonString = JsonSerializer.Serialize(model);
            await storage.SetItemAsync("model-json", jsonString);
        }
    }
}
