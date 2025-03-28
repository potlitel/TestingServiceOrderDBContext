#https://josiahmortenson.dev/blog/2020-06-08-aspnetcore-docker-https

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5001

ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["SOWebApi/SOWebApi.csproj", "SOWebApi/"]

RUN curl -L https://raw.githubusercontent.com/Microsoft/artifacts-credprovider/master/helpers/installcredprovider.sh  | sh
COPY ./nuget.config .
COPY ./MapsApiSSLCert.pfx /https
ENV VSS_NUGET_EXTERNAL_FEED_ENDPOINTS="{\"endpointCredentials\": [{\"endpoint\":\"https://pkgs.dev.azure.com/fsaltdaqqp/_packaging/FSA.NugetPackages%40Local/nuget/v3/index.json\", \"username\":\"docker\", \"password\":\"6xqkiqZd4aMMhxwqRliozxY5Z7qtDQ3edkLKBvwj1XqPy16K6IMhJQQJ99BCACAAAAAgJncgAAASAZDO2wAw\"}]}"


RUN apt-get update && apt-get install -y apt-utils

RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /usr/lib/ssl/openssl.cnf

RUN dotnet restore "SOWebApi/SOWebApi.csproj" --configfile nuget.config
COPY . .
WORKDIR "SOWebApi"
RUN dotnet build "SOWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SOWebApi.csproj" -c Release -o /app/publish --runtime linux-x64 --self-contained false

FROM base AS final

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SOWebApi.dll"]