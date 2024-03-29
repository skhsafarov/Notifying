FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY . .
RUN ls -la
RUN --mount=type=cache,id=Notifying.APINuget,target=/root/.nuget/packages
RUN dotnet restore "Notifying/Notifying.API/Notifying.API.csproj"

FROM build AS publish
RUN dotnet publish "Notifying/Notifying.API/Notifying.API.csproj" -c Development -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "Notifying.API.dll"]
