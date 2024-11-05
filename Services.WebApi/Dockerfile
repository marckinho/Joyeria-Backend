FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /src
COPY . .
WORKDIR /src/Services.WebApi
EXPOSE 80
EXPOSE 443
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /app
COPY --from=build-env /src/Services.WebApi/out ./

ENTRYPOINT ["dotnet", "Services.WebApi.dll"]