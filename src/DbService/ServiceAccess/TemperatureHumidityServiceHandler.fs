
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
        

        let con = @"Server=localhost; Database=TempHumid; User Id=sa; Password=pass123?;"
        let ctx = con |> Context.configureSqlServerContext
        let thsa = TemperatureHumidityServiceAccess ctx
        let getAllTempHumidsAsync() = _getAllTempHumidsAsync thsa
        let addNewTempHumidAsync = _addNewTempHumidAsync ctx


