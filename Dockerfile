FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Catalog.WebApi/Catalog.WebApi.csproj", "Catalog.WebApi/"]
RUN dotnet restore "Catalog.WebApi/Catalog.WebApi.csproj"
COPY . .
WORKDIR /src/Catalog.WebApi
RUN dotnet build "Catalog.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Catalog.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "Catalog.WebApi.dll" ]