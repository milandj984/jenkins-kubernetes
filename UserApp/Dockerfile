FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
LABEL stage=builder
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/ .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "UserApp.dll"]
