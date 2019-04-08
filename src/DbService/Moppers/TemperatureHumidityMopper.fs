
namespace DbService
open System
open DbRepository
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

        let mapDbRepositoryToDbService (eth : DbRepository.TemperaturesHumidities): ExistingTemperatureHumidity = 
            {
                Id = eth.Id
                Temperature = (double) eth.Temperature
                Humidity = (double) eth.Humidity
                Timestamp = eth.Timestamp
                Latitude = (double) eth.Latitude
                Longitude = (double) eth.Longitude
                DeviceId = eth.DeviceId
            }
        
        let mapDbServiceToDbRepository (nth : NewTemperatureHumidity) : DbRepository.TemperaturesHumidities =
            new TemperaturesHumidities (
                Id = 0,
                Temperature =  (decimal) nth.Temperature,
                Humidity = (decimal) nth.Humidity,
                Timestamp = nth.Timestamp,
                DeviceId = nth.DeviceId,
                Latitude =(decimal) nth.Latitude,
                Longitude =(decimal) nth.Longitude
            )
