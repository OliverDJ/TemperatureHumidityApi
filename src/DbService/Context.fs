namespace DbService

namespace DbService
open Microsoft.EntityFrameworkCore
open Microsoft.EntityFrameworkCore.Proxies
open Microsoft.EntityFrameworkCore.SqlServer
open DbRepository
    
    module Context = 

        let configureSqlServerContext  (s:string) =
            let optionsBuilder =
                new DbContextOptionsBuilder<TemphumidContext>()

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(s) 
            |> ignore 

            new TemphumidContext(optionsBuilder.Options)
     