namespace TemperatureHumidityApi

    module ConfigModel =

        [<CLIMutable>]
        type ConnectionStrings = 
            {   
                TempHumidDatabase: string
            }
        
        [<CLIMutable>]
        type WebApiSettings = 
            {
                ConnectionStrings : ConnectionStrings
            }

