#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Redis.Cache.Sample/Redis.Cache.Sample.csproj", "Redis.Cache.Sample/"]
RUN dotnet restore "Redis.Cache.Sample/Redis.Cache.Sample.csproj"
COPY . .
WORKDIR "/src/Redis.Cache.Sample"
RUN dotnet build "Redis.Cache.Sample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Redis.Cache.Sample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Redis.Cache.Sample.dll"]