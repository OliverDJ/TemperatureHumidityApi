
namespace DbService
open DbRepository
open FSharp.Control.Tasks.V2.ContextInsensitive
open TemperatureHumidityMopper
open Context
open System
open System.Threading.Tasks

    module TemperatureHumidityServiceHandler =
        open DbRepository


        let private _getAllTempHumidsAsync ( thsa : TemperatureHumidityServiceAccess): Task<ExistingTemperatureHumidity list> =
            task{
               let! q = thsa.getAllTempHumids()
               let dsth = q |> Seq.map mapDbRepositoryToDbService |> Seq.toList
               return dsth
            }
        
        let private _addNewTempHumidAsync (ctx: TemphumidContext) (nth : NewTemperatureHumidity)  =
            task {
                let rnth = nth |> mapDbServiceToDbRepository
                ctx.TemperaturesHumidities.Add(rnth) |> ignore
                let! r = ctx.SaveChangesAsync()
                return r
            }
        
        //let dbSettings = Configuration.getConfigModel()
        let createContext conn = conn |> Context.configureSqlServerContext

        let thsa s = TemperatureHumidityServiceAccess (createContext s)
        let getAllTempHumidsAsync s = _getAllTempHumidsAsync (thsa s)
        let addNewTempHumidAsync s = _addNewTempHumidAsync (createContext s)


