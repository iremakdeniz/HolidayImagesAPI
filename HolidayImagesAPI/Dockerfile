# 1. Base image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# 2. Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HolidayImagesAPI.csproj", "./"]
RUN dotnet restore "HolidayImagesAPI.csproj"
COPY . .
RUN dotnet build "HolidayImagesAPI.csproj" -c Release -o /app/build

# 3. Publish stage
FROM build AS publish
RUN dotnet publish "HolidayImagesAPI.csproj" -c Release -o /app/publish

# 4. Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HolidayImagesAPI.dll"]
