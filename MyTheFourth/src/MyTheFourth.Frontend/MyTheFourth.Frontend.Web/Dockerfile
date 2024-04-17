#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/MyTheFourth.Frontend/MyTheFourth.Frontend.Web/MyTheFourth.Frontend.Web.csproj", "src/MyTheFourth.Frontend/MyTheFourth.Frontend.Web/"]
COPY ["src/MyTheFourth.Frontend/MyTheFourth.Frontend.Web.Client/MyTheFourth.Frontend.Web.Client.csproj", "src/MyTheFourth.Frontend/MyTheFourth.Frontend.Web.Client/"]
RUN dotnet restore "./src/MyTheFourth.Frontend/MyTheFourth.Frontend.Web/MyTheFourth.Frontend.Web.csproj"
COPY . .
WORKDIR "/src/src/MyTheFourth.Frontend/MyTheFourth.Frontend.Web"
RUN dotnet build "./MyTheFourth.Frontend.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MyTheFourth.Frontend.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyTheFourth.Frontend.Web.dll"]