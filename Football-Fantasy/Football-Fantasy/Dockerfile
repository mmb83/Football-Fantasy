FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Football-Fantasy/Football-Fantasy.csproj", "Football-Fantasy/"]
RUN dotnet restore "Football-Fantasy/Football-Fantasy.csproj"
COPY . .
WORKDIR "/src/Football-Fantasy"
RUN dotnet build "Football-Fantasy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Football-Fantasy.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Football-Fantasy.dll"]
