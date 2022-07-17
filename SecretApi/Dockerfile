FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SecuringMicroserviceDemo/SecretApi/SecretApi.csproj", "SecretApi/"]
RUN dotnet restore "SecretApi/SecretApi.csproj"
COPY . .
WORKDIR "/src/SecretApi"
RUN dotnet build "SecretApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SecretApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SecretApi.dll"]
