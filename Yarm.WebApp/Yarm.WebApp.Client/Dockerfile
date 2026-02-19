FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Yarm.WebApp/Yarm.WebApp.Client/Yarm.WebApp.Client.csproj", "Yarm.WebApp/Yarm.WebApp.Client/"]
RUN dotnet restore "Yarm.WebApp/Yarm.WebApp.Client/Yarm.WebApp.Client.csproj"
COPY . .
WORKDIR "/src/Yarm.WebApp/Yarm.WebApp.Client"
RUN dotnet build "./Yarm.WebApp.Client.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Yarm.WebApp.Client.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Yarm.WebApp.Client.dll"]
