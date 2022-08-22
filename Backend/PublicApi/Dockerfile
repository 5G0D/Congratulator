FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Congratulator/Congratulator.csproj", "Congratulator/"]
RUN dotnet restore "Congratulator/Congratulator.csproj"
COPY . .
WORKDIR "/src/Congratulator"
RUN dotnet build "Congratulator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Congratulator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Congratulator.dll"]
