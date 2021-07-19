#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ElixrMarket.Web/ElixrMarket.Web.csproj", "ElixrMarket.Web/"]
RUN dotnet restore "ElixrMarket.Web/ElixrMarket.Web.csproj"
COPY . .
WORKDIR "/src/ElixrMarket.Web"
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"
RUN mkdir ../app/data
RUN touch ../app/data/elixr.db
RUN dotnet ef database update -- --environment Production
RUN dotnet build "ElixrMarket.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ElixrMarket.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ElixrMarket.Web.dll"]