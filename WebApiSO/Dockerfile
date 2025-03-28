#https://josiahmortenson.dev/blog/2020-06-08-aspnetcore-docker-https

#Steps: 
#- Verificar que no se est� ejecutando ning�n servicio por el puerto 443
#- cd C:\Users\potli\source\repos\ServiceOrders\ServiceOrders
#- docker-compose -f "docker-compose.yml" up -d --build
#- https://laptop-2f5ufph3/swagger/index.html

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 7202

ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["WebApiSO/WebApiSO.csproj", "WebApiSO/"]

RUN curl -L https://raw.githubusercontent.com/Microsoft/artifacts-credprovider/master/helpers/installcredprovider.sh  | sh
COPY ./nuget.config .
COPY ./MapsApiSSLCert.pfx https/

ENV VSS_NUGET_EXTERNAL_FEED_ENDPOINTS="{\"endpointCredentials\": [{\"endpoint\":\"https://pkgs.dev.azure.com/fsaltdaqqp/_packaging/FSA.NugetPackages%40Local/nuget/v3/index.json\", \"username\":\"docker\", \"password\":\"6xqkiqZd4aMMhxwqRliozxY5Z7qtDQ3edkLKBvwj1XqPy16K6IMhJQQJ99BCACAAAAAgJncgAAASAZDO2wAw\"}]}"


RUN apt-get update && apt-get install -y apt-utils

RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /usr/lib/ssl/openssl.cnf

RUN dotnet restore "WebApiSO/WebApiSO.csproj" --configfile nuget.config
COPY . .
WORKDIR "WebApiSO"
RUN dotnet build "WebApiSO.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApiSO.csproj" -c Release -o /app/publish --runtime linux-x64 --self-contained false

FROM base AS final

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApiSO.dll"]