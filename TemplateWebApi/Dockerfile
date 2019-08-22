FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["TemplateWebApi/TemplateWebApi.csproj", "TemplateWebApi/"]
RUN dotnet restore "TemplateWebApi/TemplateWebApi.csproj"
COPY . .
WORKDIR "/src/TemplateWebApi"
RUN dotnet build "TemplateWebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TemplateWebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TemplateWebApi.dll"]