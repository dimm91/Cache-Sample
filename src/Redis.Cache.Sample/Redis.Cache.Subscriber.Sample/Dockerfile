#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Redis.Cache.Subscriber.Sample/Redis.Cache.Subscriber.Sample.csproj", "Redis.Cache.Subscriber.Sample/"]
RUN dotnet restore "Redis.Cache.Subscriber.Sample/Redis.Cache.Subscriber.Sample.csproj"
COPY . .
WORKDIR "/src/Redis.Cache.Subscriber.Sample"
RUN dotnet build "Redis.Cache.Subscriber.Sample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Redis.Cache.Subscriber.Sample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Redis.Cache.Subscriber.Sample.dll"]