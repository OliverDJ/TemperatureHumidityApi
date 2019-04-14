namespace TemperatureHumidityApi
open Giraffe
open Microsoft.AspNetCore.Http
open FSharp.Control.Tasks
open DbService.TemperatureHumidityServiceHandler
open DbHelper
open TemperatureHumidityMopper
    module TemperatureHumidityHandler =
        

        let getAllTempHumids = 
            fun (next : HttpFunc) (context : HttpContext) -> 
                task {
                    let! s = context |> getDbConnStringFromServices
                    let! q = getAllTempHumidsAsync s
                    let dsth = q |> Seq.map mapDbServiceToApi |> Seq.toList
                    let r = dsth |> context.WriteJsonAsync
                    return! r
                }
        

        let addNewTempHumid (nth : NewTemperatureHumidity) = 
            fun (next : HttpFunc) (context : HttpContext) ->
                task {
                    let! s = context |> getDbConnStringFromServices
                    let dsth = nth |> mapApiToDbService
                    let! m = (addNewTempHumidAsync s) dsth 
                    let r = m |> context.WriteJsonAsync
                    return! r                
                }

