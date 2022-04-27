FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HouseRentApi/HouseRentApi.csproj", "HouseRentApi/"]
RUN dotnet restore "HouseRentApi/HouseRentApi.csproj"
COPY . .
WORKDIR "/src/HouseRentApi"
RUN dotnet build "HouseRentApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HouseRentApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HouseRentApi.dll"]
