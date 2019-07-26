FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["WebMvc/WebMvc.csproj", "WebMvc/"]
RUN dotnet restore "WebMvc/WebMvc.csproj"
COPY . .
WORKDIR "/src/WebMvc"
RUN dotnet build "WebMvc.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebMvc.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebMvc.dll"]