FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["CryptoRatesManager.Web/CryptoRatesManager.Web.csproj", "CryptoRatesManager.Web/"]
RUN dotnet restore "CryptoRatesManager.Web/CryptoRatesManager.Web.csproj"
COPY . .
WORKDIR "/src/CryptoRatesManager.Web"
RUN dotnet build "CryptoRatesManager.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CryptoRatesManager.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CryptoRatesManager.Web.dll"]