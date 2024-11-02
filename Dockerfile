FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY CookDinnerMinimalApi/*.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /out .

ENV USE_KESTREL=true

EXPOSE 8081

ENTRYPOINT ["dotnet", "CookDinnerMinimalApi.dll"]