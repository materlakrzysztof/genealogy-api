FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Kopiuj pliki solution i projektów
COPY *.sln .
COPY GenealogyApi/*.csproj ./GenealogyApi/
COPY Genealogy.Application/*.csproj ./Genealogy.Application/
COPY Genealogy.Database/*.csproj ./Genealogy.Database/
COPY Genealogy.Domain/*.csproj ./Genealogy.Domain/
# Dodaj inne projekty jeśli masz więcej

# Przywróć zależności
RUN dotnet restore

# Kopiuj resztę kodu
COPY . .

# Zbuduj i opublikuj główny projekt
WORKDIR /src/GenealogyApi
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Etap 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

# Kopiuj opublikowaną aplikację z etapu build
COPY --from=build /app/publish .

# Ustaw port
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# Uruchom aplikację
ENTRYPOINT ["dotnet", "GenealogyApi.dll"]


# Runtime stage - using .NET 10.0 runtime
#
#
#
#FROM mcr.microsoft.com/dotnet/aspnet:10.0
#WORKDIR /app
#
## Copy the published application
#COPY GenealogyApi/publish/ .
#
## Expose port 8080
#EXPOSE 8080
#
## Set the entry point
#ENTRYPOINT ["dotnet", "GenealogyApi.dll"]
