FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim AS build
WORKDIR /src
COPY ["Nuget.config", "."]
COPY ["AntiForgeryExperience/AntiForgeryExperience.csproj", "AntiForgeryExperience/"]

RUN dotnet restore "AntiForgeryExperience/AntiForgeryExperience.csproj"
COPY . .
WORKDIR "/src/AntiForgeryExperience"
RUN dotnet build "AntiForgeryExperience.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AntiForgeryExperience.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AntiForgeryExperience.dll"]