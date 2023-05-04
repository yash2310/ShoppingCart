#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ShoppingCart.User.API/ShoppingCart.User.API.csproj", "ShoppingCart.User.API/"]
COPY ["ShoppingCart.User.Infra/ShoppingCart.User.Infra.csproj", "ShoppingCart.User.Infra/"]
COPY ["ShoppingCart.Application/ShoppingCart.Application.csproj", "ShoppingCart.Application/"]
COPY ["ShoppingCart.Domain/ShoppingCart.Domain.csproj", "ShoppingCart.Domain/"]
RUN dotnet restore "ShoppingCart.User.API/ShoppingCart.User.API.csproj"
COPY . .
WORKDIR "/src/ShoppingCart.User.API"
RUN dotnet build "ShoppingCart.User.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShoppingCart.User.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShoppingCart.User.API.dll"]