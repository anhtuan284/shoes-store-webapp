#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["QLBG.WEB/QLBG.WEB.csproj", "QLBG.WEB/"]
COPY ["QLBG.BLL/QLBG.BLL.csproj", "QLBG.BLL/"]
COPY ["QLBG.Common/QLBG.Common.csproj", "QLBG.Common/"]
COPY ["QLBG.DAL/QLBG.DAL.csproj", "QLBG.DAL/"]
RUN dotnet restore "QLBG.WEB/QLBG.WEB.csproj"
COPY . .
WORKDIR "/src/QLBG.WEB"
RUN dotnet build "QLBG.WEB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QLBG.WEB.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QLBG.WEB.dll"]