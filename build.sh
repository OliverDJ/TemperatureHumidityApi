#!/bin/sh
dotnet restore src/TemperatureHumidityApi
dotnet build src/TemperatureHumidityApi

dotnet restore tests/TemperatureHumidityApi.Tests
dotnet build tests/TemperatureHumidityApi.Tests
dotnet test tests/TemperatureHumidityApi.Tests
