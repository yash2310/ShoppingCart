#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ShoppingCart.Discount.API/ShoppingCart.Discount.API.csproj", "ShoppingCart.Discount.API/"]
COPY ["ShoppingCart.Application/ShoppingCart.Application.csproj", "ShoppingCart.Application/"]
COPY ["ShoppingCart.Domain/ShoppingCart.Domain.csproj", "ShoppingCart.Domain/"]
COPY ["ShoppingCart.Discount.Infra/ShoppingCart.Discount.Infra.csproj", "ShoppingCart.Discount.Infra/"]
RUN dotnet restore "ShoppingCart.Discount.API/ShoppingCart.Discount.API.csproj"
COPY . .
WORKDIR "/src/ShoppingCart.Discount.API"
RUN dotnet build "ShoppingCart.Discount.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShoppingCart.Discount.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShoppingCart.Discount.API.dll"]