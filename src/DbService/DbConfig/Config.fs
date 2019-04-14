namespace DbService
open Microsoft.Extensions.Configuration
open ConfigModels
    module Configuration = 
        
        let getConfiguration(IHostingEnvironment) = 
            let builder = 
                ConfigurationBuilder()
                    .AddEnvironmentVariables()
            builder.Build()
    
        let getConfigModel () =
            let iconfig = getConfiguration()
            let m = iconfig.Get<DbServiceSettings>()
            m
