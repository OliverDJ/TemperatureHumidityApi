namespace TemperatureHumidityApi

open System

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
                Latitude: double
                Longitude: double
            }

        
        let mapDbServiceToApi ( eth : DbService.TemperatureHumidityMopper.ExistingTemperatureHumidity) : ExistingTemperatureHumidity =
            {
                Id = eth.Id
                Temperature = eth.Temperature
                Humidity = eth.Humidity
                Timestamp = eth.Timestamp
                Latitude = eth.Latitude
                Longitude = eth.Longitude
                DeviceId = eth.DeviceId
            }

        let mapApiToDbService (nth : NewTemperatureHumidity) : DbService.TemperatureHumidityMopper.NewTemperatureHumidity =
            {
                Temperature = nth.Temperature
                Humidity = nth.Humidity
                Timestamp = nth.Timestamp
                Latitude = nth.Latitude
                Longitude = nth.Longitude
                DeviceId = nth.DeviceId
            }


