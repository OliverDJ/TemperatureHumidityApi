namespace TemperatureHumidityApi.Moppers

open System

    module TemperatureHumidityMopper = 
        
        type TemperatureHumidity = 
            {   
                Id: int
                Temperature: double
                Humidity: double
                Timestamp: DateTime
                DeviceId: int
                Latitude: double
                Longitude: double
            }






