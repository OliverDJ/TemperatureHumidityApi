
namespace DbService
open DbRepository
open FSharp.Control.Tasks.V2.ContextInsensitive
open DeviceMopper
open Context
open System
open System.Threading.Tasks

    module TemperatureHumidityServiceHandler =
        open DbRepository


        let private getTempHumidsAsync ( thsa : TemperatureHumidityServiceAccess): Task<TemperaturesHumidities list> =
            task{
                
                let! q = thsa.getAllTempHumids()
            
            }
