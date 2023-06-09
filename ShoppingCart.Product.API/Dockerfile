#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ShoppingCart.Product.API/ShoppingCart.Product.API.csproj", "ShoppingCart.Product.API/"]
COPY ["ShoppingCart.Application/ShoppingCart.Application.csproj", "ShoppingCart.Application/"]
COPY ["ShoppingCart.Domain/ShoppingCart.Domain.csproj", "ShoppingCart.Domain/"]
COPY ["ShoppingCart.Product.Infra/ShoppingCart.Product.Infra.csproj", "ShoppingCart.Product.Infra/"]
RUN dotnet restore "ShoppingCart.Product.API/ShoppingCart.Product.API.csproj"
COPY . .
WORKDIR "/src/ShoppingCart.Product.API"
RUN dotnet build "ShoppingCart.Product.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShoppingCart.Product.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShoppingCart.Product.API.dll"]