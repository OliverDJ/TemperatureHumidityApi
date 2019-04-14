namespace DbService


    module ConfigModels =
        0

        [<CLIMutable>]
        type ConnectionStrings = 
            {   
                TempHumdDatabase: string
            }
        

        type DbServiceSettings = 
            {
                ConnectionStrings : ConnectionStrings
            }


