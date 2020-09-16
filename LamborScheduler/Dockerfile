#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
ARG BuildConfiguration=Release
WORKDIR /src
COPY ["LamborScheduler/LamborScheduler.csproj", "LamborScheduler/"]
COPY ["LamborDatabaseJobs/LamborDatabaseJobs.csproj", "LamborDatabaseJobs/"]
RUN dotnet restore "LamborScheduler/LamborScheduler.csproj"
COPY . .
WORKDIR "/src/LamborScheduler"
RUN dotnet build "LamborScheduler.csproj" -c ${BuildConfiguration:-Release} -o /app/build

FROM build AS publish
ARG BuildConfiguration=Release
RUN dotnet publish "LamborScheduler.csproj" -c ${BuildConfiguration:-Release} -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LamborScheduler.dll"]