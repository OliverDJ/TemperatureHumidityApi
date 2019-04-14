namespace TemperatureHumidityApi
open Giraffe
open Microsoft.AspNetCore.Http
open ConfigModel
open FSharp.Control.Tasks
    module DbHelper =
        
        let getDbConnStringFromServices (ctx : HttpContext) =
            task {
                let s = ctx.GetService<WebApiSettings>()
                let dbconn = s.ConnectionStrings.TempHumidDatabase
                return dbconn
            }


