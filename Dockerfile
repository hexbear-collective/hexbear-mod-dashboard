#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/nightly/sdk:8.0 AS base
WORKDIR /app
EXPOSE 7081
#EXPOSE 8081

FROM mcr.microsoft.com/dotnet/nightly/sdk:8.0 AS build
WORKDIR /src
COPY ./hexbear-dashboard/hexbear-dashboard.csproj ./hexbear-dashboard/
COPY ./hexbear-dashboard.Client ./hexbear-dashboard.Client
COPY ./Hexbear.Lib ./Hexbear.Lib
RUN dotnet restore "hexbear-dashboard/hexbear-dashboard.csproj"
COPY ./hexbear-dashboard ./hexbear-dashboard
WORKDIR "/src/hexbear-dashboard"
ARG AppSettings="{}"
RUN echo $AppSettings > ../hexbear-dashboard.Client/wwwroot/appsettings.json
RUN dotnet build "hexbear-dashboard.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "hexbear-dashboard.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "hexbear-dashboard.dll"]