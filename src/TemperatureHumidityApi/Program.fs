module TemperatureHumidityApi.App

open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Cors.Infrastructure
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open Giraffe
open TemperatureHumidityApi.DeviceHandler
open TemperatureHumidityApi.TemperatureHumidityHandler
open TemperatureHumidityApi.Moppers.DeviceMopper
open TemperatureHumidityApi.TemperatureHumidityMopper
open Microsoft.Extensions.Configuration
open ConfigModel
// ---------------------------------
// Web app
// ---------------------------------

let webApp =
    choose [
        subRoute "/api"
            (choose [
                GET >=> choose [
                    route "/devices" >=> getAllDevices
                    routef "/deviceById/%i" getDeviceById 
                    route "/temphumids" >=> getAllTempHumids
                ]
                POST >=> choose [
                    route "/addDevice" >=> bindJson<NewDevice> addNewDevice
                    route "/addTempHumid" >=> bindJson<NewTemperatureHumidity> addNewTempHumid
                ]
            ])
        setStatusCode 404 >=> text "Not Found" ]

// ---------------------------------
// Error handler
// ---------------------------------

let errorHandler (ex : Exception) (logger : ILogger) =
    logger.LogError(ex, "An unhandled exception has occurred while executing the request.")
    clearResponse >=> setStatusCode 500 >=> text ex.Message

// ---------------------------------
// Config and Main
// ---------------------------------
let getConfiguration (env:IHostingEnvironment) = 
    let builder = 
         ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            //.AddJsonFile("appsettings.json", true, true)
            //.AddJsonFile(sprintf "appsettings.%s.json" env.EnvironmentName, true)
            .AddEnvironmentVariables();

    builder.Build();


let configureCors (builder : CorsPolicyBuilder) =
    builder
        .AllowAnyOrigin()
        //WithOrigins("http://localhost:8080")
        .AllowAnyMethod()
        .AllowAnyHeader()
        |> ignore

let configureApp (app : IApplicationBuilder) =
    let env = app.ApplicationServices.GetService<IHostingEnvironment>()
    (match env.IsDevelopment() with
    | true  -> app.UseDeveloperExceptionPage()
    | false -> app.UseGiraffeErrorHandler errorHandler)
        .UseHttpsRedirection()
        .UseCors(configureCors)
        .UseGiraffe(webApp)

let configureServices (services : IServiceCollection) =
    //services.AddCors()    |> ignore
    let env = services.BuildServiceProvider().GetService<IHostingEnvironment>()
    let iconfig = getConfiguration env
    services.AddGiraffe() |> ignore
    services.AddCors() |> ignore
    let settings = iconfig.Get<WebApiSettings>()
    services.AddSingleton<WebApiSettings>(fun _ -> iconfig.Get<WebApiSettings>() ) |> ignore

let configureLogging (builder : ILoggingBuilder) =
    builder.AddFilter(fun l -> l.Equals LogLevel.Error)
           .AddConsole()
           .AddDebug() |> ignore

[<EntryPoint>]
let main _ =
    WebHostBuilder()
        .UseKestrel()
        .UseIISIntegration()
        .Configure(Action<IApplicationBuilder> configureApp)
        .ConfigureServices(configureServices)
        .ConfigureLogging(configureLogging)
        .Build()
        .Run()
    0