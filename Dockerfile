# =========================================
# STAGE 1: Build
# =========================================
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

# Chỉ có 1 .csproj — copy thẳng vào thư mục hiện tại
COPY ["Movie_Reservation_System.csproj", "."]
RUN dotnet restore "Movie_Reservation_System.csproj"

COPY . .

RUN dotnet publish "Movie_Reservation_System.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore

# =========================================
# STAGE 2: Runtime
# =========================================
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

RUN useradd --create-home --shell /bin/bash appuser
USER appuser

EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT ["dotnet", "Movie_Reservation_System.dll"]