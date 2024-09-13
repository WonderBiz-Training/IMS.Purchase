# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Purchase.Api/Purchase.Api.csproj", "Purchase.Api/"]
COPY ["Purchase.Application/Purchase.Application.csproj", "Purchase.Application/"]
COPY ["Purchase.Domain/Purchase.Domain.csproj", "Purchase.Domain/"]
COPY ["Purchase.Infrastructure/Purchase.Infrastructure.csproj", "Purchase.Infrastructure/"]
RUN dotnet restore "./Purchase.Api/Purchase.Api.csproj"
COPY . .
WORKDIR "/src/Purchase.Api"
RUN dotnet build "./Purchase.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Purchase.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Purchase.Api.dll"]