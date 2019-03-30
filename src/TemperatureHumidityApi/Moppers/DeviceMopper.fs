namespace TemperatureHumidityApi.Moppers

open System

    module DeviceMopper =
        
        type ExisitngDevice = 
            {
                Id : int
                Name: string
                CreatedAt: DateTime
            }
        
        type NewDevice = {
            Name: string
        }
        
        
