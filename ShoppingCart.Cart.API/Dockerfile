#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ShoppingCart.Cart.API/ShoppingCart.Cart.API.csproj", "ShoppingCart.Cart.API/"]
COPY ["ShoppingCart.Application/ShoppingCart.Application.csproj", "ShoppingCart.Application/"]
COPY ["ShoppingCart.Domain/ShoppingCart.Domain.csproj", "ShoppingCart.Domain/"]
COPY ["ShoppingCart.Cart.Infra/ShoppingCart.Cart.Infra.csproj", "ShoppingCart.Cart.Infra/"]
RUN dotnet restore "ShoppingCart.Cart.API/ShoppingCart.Cart.API.csproj"
COPY . .
WORKDIR "/src/ShoppingCart.Cart.API"
#RUN dotnet build "ShoppingCart.Cart.API.csproj" -c Release -o /app/build
RUN dotnet build "ShoppingCart.Cart.API.csproj" -o /app/build

FROM build AS publish
#RUN dotnet publish "ShoppingCart.Cart.API.csproj" -c Release -o /app/publish /p:UseAppHost=false
RUN dotnet publish "ShoppingCart.Cart.API.csproj" -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShoppingCart.Cart.API.dll"]