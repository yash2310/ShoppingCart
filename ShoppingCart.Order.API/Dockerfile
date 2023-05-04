#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ShoppingCart.Order.API/ShoppingCart.Order.API.csproj", "ShoppingCart.Order.API/"]
COPY ["ShoppingCart.Application/ShoppingCart.Application.csproj", "ShoppingCart.Application/"]
COPY ["ShoppingCart.Domain/ShoppingCart.Domain.csproj", "ShoppingCart.Domain/"]
COPY ["ShoppingCart.Order.Infra/ShoppingCart.Order.Infra.csproj", "ShoppingCart.Order.Infra/"]
RUN dotnet restore "ShoppingCart.Order.API/ShoppingCart.Order.API.csproj"
COPY . .
WORKDIR "/src/ShoppingCart.Order.API"
RUN dotnet build "ShoppingCart.Order.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShoppingCart.Order.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShoppingCart.Order.API.dll"]