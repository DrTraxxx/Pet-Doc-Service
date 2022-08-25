#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Pet-Doc-BE/Pet-Doc-BE.csproj", "Pet-Doc-BE/"]
RUN dotnet restore "Pet-Doc-BE/Pet-Doc-BE.csproj"
COPY . .
WORKDIR "/src/Pet-Doc-BE"
RUN dotnet build "Pet-Doc-BE.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pet-Doc-BE.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pet-Doc-BE.dll"]