# Базовый образ .NET Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Образ SDK для сборки приложения
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем файлы проекта
COPY . .

# Восстанавливаем зависимости
RUN dotnet restore "OnlineShop.csproj"

# Сборка и публикация в папку /app/publish
RUN dotnet publish "OnlineShop.csproj" -c Release -o /app/publish

# Финальный образ
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Точка входа
ENTRYPOINT ["dotnet", "OnlineShop.dll"]
