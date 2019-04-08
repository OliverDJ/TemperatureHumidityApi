
namespace DbService
open System.Data.Spatial

    module TemperatureHumidityMopper =


        type ExistingTemperatureHumidity = 
            {   
                Id: int
                Temperature: double
                Humidity: double
                Timestamp: DateTime
                DeviceId: int
                Latitude: double
                Longitude: double
            }
        
        type NewTemperatureHumidity = 
            {
                Temperature: double
                Humidity: double
                Timestamp: DateTime
                DeviceId: int
                geography: 
            }

