# RealmForge API container (used by Render, see render.yaml). Build from the repository root:
#   docker build -f RealmForge/RealmForge.Api/Dockerfile -t realmforge-api .
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Project files first, so the package restore is cached while only the code changes
COPY RealmForge/RealmForge.Api/RealmForge.Api.csproj RealmForge/RealmForge.Api/
COPY RealmForge/RealmForge.Domain/RealmForge.Domain.csproj RealmForge/RealmForge.Domain/
COPY RealmForge/RealmForge.Infrastructure/RealmForge.Infrastructure.csproj RealmForge/RealmForge.Infrastructure/
COPY RealmForge/RealmForge.Shared/RealmForge.Shared.csproj RealmForge/RealmForge.Shared/
RUN dotnet restore RealmForge/RealmForge.Api/RealmForge.Api.csproj

COPY RealmForge/RealmForge.Api/ RealmForge/RealmForge.Api/
COPY RealmForge/RealmForge.Domain/ RealmForge/RealmForge.Domain/
COPY RealmForge/RealmForge.Infrastructure/ RealmForge/RealmForge.Infrastructure/
COPY RealmForge/RealmForge.Shared/ RealmForge/RealmForge.Shared/
RUN dotnet publish RealmForge/RealmForge.Api/RealmForge.Api.csproj --configuration Release --no-restore --output /app

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app .
ENV ASPNETCORE_ENVIRONMENT=Production
USER $APP_UID

# The hosting platform passes the port in PORT (Render: 10000); 8080 otherwise
CMD ["sh", "-c", "ASPNETCORE_HTTP_PORTS=${PORT:-8080} exec dotnet RealmForge.Api.dll"]
