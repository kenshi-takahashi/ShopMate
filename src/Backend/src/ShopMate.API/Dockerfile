FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Копируем все проекты
COPY ./src/ShopMate.API/ShopMate.API.csproj ./ShopMate.API/
COPY ./src/ShopMate.Application/ShopMate.Application.csproj ./ShopMate.Application/
COPY ./src/ShopMate.Domain/ShopMate.Domain.csproj ./ShopMate.Domain/
COPY ./src/ShopMate.Infrastructure/ShopMate.Infrastructure.csproj ./ShopMate.Infrastructure/
COPY ./src/ShopMate.Persistence/ShopMate.Persistence.csproj ./ShopMate.Persistence/

# Восстанавливаем зависимости
RUN dotnet restore ./ShopMate.API/ShopMate.API.csproj

# Копируем остальной код
COPY ./src/ ./ 

# Публикуем
WORKDIR /src/ShopMate.API
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ShopMate.API.dll"]
