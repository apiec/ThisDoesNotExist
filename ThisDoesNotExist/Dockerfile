#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
RUN apt update -y && apt install python3 -y && apt install pip -y
RUN pip install Pillow
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ThisDoesNotExist/ThisDoesNotExist.csproj", "ThisDoesNotExist/"]
RUN dotnet restore "ThisDoesNotExist/ThisDoesNotExist.csproj"
COPY . .
WORKDIR "/src/ThisDoesNotExist"
RUN dotnet build "ThisDoesNotExist.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ThisDoesNotExist.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ThisDoesNotExist.dll"]