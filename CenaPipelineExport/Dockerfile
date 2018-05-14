FROM microsoft/dotnet:2.0-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.0-sdk AS build
WORKDIR /src
COPY CenaPipelineExport/CenaPipelineExport.csproj CenaPipelineExport/
COPY swiper.backend.data/ch.cena.swiper.backend.data.csproj swiper.backend.data/
COPY swiper.backend.services/ch.cena.swiper.backend.service.csproj swiper.backend.services/
RUN dotnet restore CenaPipelineExport/CenaPipelineExport.csproj
COPY . .
WORKDIR /src/CenaPipelineExport
RUN dotnet build CenaPipelineExport.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CenaPipelineExport.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CenaPipelineExport.dll"]
