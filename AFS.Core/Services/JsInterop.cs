using Microsoft.JSInterop;

namespace AFS.Core.Services
{
    public class JsInterop : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public JsInterop(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/AFS.ComponentLibrary/JsInterop.js").AsTask());
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }

        public async ValueTask ExportToFile(string fileName, DotNetStreamReference streamRef)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);
        }

        public async ValueTask TriggerClick(string id)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("triggerClick", id);
        }

    }
}