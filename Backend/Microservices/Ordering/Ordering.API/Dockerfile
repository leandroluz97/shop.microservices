#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Microservices/Ordering/Ordering.API/Ordering.API.csproj", "Microservices/Ordering/Ordering.API/"]
COPY ["Microservices/Ordering/Ordering.Application/Ordering.Application.csproj", "Microservices/Ordering/Ordering.Application/"]
COPY ["Common.Messaging/Common.Messaging.csproj", "Common.Messaging/"]
COPY ["Common/Common.csproj", "Common/"]
COPY ["Microservices/Ordering/Ordering.Domain/Ordering.Domain.csproj", "Microservices/Ordering/Ordering.Domain/"]
COPY ["Microservices/Ordering/Ordering.Infrastructure/Ordering.Infrastructure.csproj", "Microservices/Ordering/Ordering.Infrastructure/"]
RUN dotnet restore "./Microservices/Ordering/Ordering.API/./Ordering.API.csproj"
COPY . .
WORKDIR "/src/Microservices/Ordering/Ordering.API"
RUN dotnet build "./Ordering.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Ordering.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ordering.API.dll"]