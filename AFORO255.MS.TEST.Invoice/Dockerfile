#FROM mcr.microsoft.com/dotnet/sdk:7.0
#WORKDIR /app
#
#COPY ./publish/ /app
#
#ENV ASPNETCORE_URLS=http://+:8080
#ENV ASPNETCORE_ENVIRONMENT docker
#
#EXPOSE 8080
#
#ENTRYPOINT ["dotnet","/app/AFORO255.MS.TEST.Invoice.dll"]

ARG PROJECT_NAME=AFORO255.MS.TEST.Invoice

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
ARG PROJECT_NAME
ENV PROJECT=$PROJECT_NAME
WORKDIR /app

COPY . .

RUN dotnet restore
RUN dotnet publish ${PROJECT}.csproj -c release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
ARG PROJECT_NAME
ENV PROJECT=$PROJECT_NAME
WORKDIR /app
COPY --from=build-env /app/out .
ENV ASPNETCORE_URLS http://*:8080
ENV ASPNETCORE_ENVIRONMENT docker
EXPOSE 8080
ENTRYPOINT dotnet ${PROJECT}.dll