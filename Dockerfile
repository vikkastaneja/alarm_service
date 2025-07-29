# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "AlarmService.Api/AlarmService.Api.csproj"
RUN dotnet build "AlarmService.Api/AlarmService.Api.csproj" -c Release -o /app/build
RUN dotnet publish "AlarmService.Api/AlarmService.Api.csproj" -c Release -o /app/publish

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "AlarmService.Api.dll"]