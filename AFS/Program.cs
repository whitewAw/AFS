using AFS;
using AFS.Core.Interfaces;
using AFS.Core.Model;
using AFS.Core.Services;
using AFS.Core.Services.DataCalculations;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<AFSModel>();
builder.Services.AddSingleton<AFSConstraints>();
builder.Services.AddLocalization(options => options.ResourcesPath = "");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<ICultureStorageHandler, LocalStorageCultureHandler>();
builder.Services.AddScoped<IModelStorageHandler, LocalStorageModelHandler>();
builder.Services.AddScoped<IModelExportImportHandler, BrowserExportImportHandler>();
builder.Services.AddScoped<JsInterop>();
builder.Services.AddScoped<DialogService>();

builder.Services.AddTransient<CharacteristicsOfCapital>();
builder.Services.AddTransient<IndicatorsOfTurnoverOfCurrentAssets>();
builder.Services.AddTransient<FactorsAffectingTurnoverOfWorkingCapital>();
builder.Services.AddTransient<IndicatorsOfEfficiencyOfWorkingCapital>();
builder.Services.AddTransient<AvailabilityAndMovementOfFixedAssets>();
builder.Services.AddTransient<IndicatorsOfStateAndMovementOfFixedAssets>();
builder.Services.AddTransient<CalculationOfIndicatorsOfEfficiencyOfUseOfFixedAssets>();
builder.Services.AddTransient<FactorAnalysisOfFixedAssets>();
builder.Services.AddTransient<IndicatorsOfEfficiencyOfUseOfIntangibleAssets>();
builder.Services.AddTransient<SourcesOfCapitalFormation>();
builder.Services.AddTransient<AssessmentOfReceivableAndPayable>();
builder.Services.AddTransient<IndicatorsOfBusinessActivity>();
builder.Services.AddTransient<LiquidityIndicatorsOfBalance>();
builder.Services.AddTransient<SolvencyRatios>();
builder.Services.AddTransient<GeneralIndicatorsOfFinancialStability>();
builder.Services.AddTransient<ClassificationOfTypesOfFinancialStability>();
builder.Services.AddTransient<IndicatorsOfFinancialStability>();
//Charts
builder.Services.AddTransient<CompositionOfAssets>();
builder.Services.AddTransient<WorkingCapitalTurnoverTime>();
builder.Services.AddTransient<SourcesOfCapitalFormationChart>();

builder.Logging.SetMinimumLevel(LogLevel.Warning);

var host = builder.Build();

ICultureStorageHandler? cultureStorageService = host.Services.GetService<ICultureStorageHandler>();
if (cultureStorageService != null)
{
    await cultureStorageService.InitializeCultureAsync();
}
IModelStorageHandler? modelStorageHandler = host.Services.GetService<IModelStorageHandler>();
if (modelStorageHandler != null)
{
    await modelStorageHandler.InitializeModelAsync();
}

await host.RunAsync();