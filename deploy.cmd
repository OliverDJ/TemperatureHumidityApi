
fake run build.fsx 

powershell -file ".\deploy\upload.ps1" -settings "deploy\deploySettings.json"