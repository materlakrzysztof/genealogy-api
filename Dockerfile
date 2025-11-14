# Runtime stage - using .NET 10.0 runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

# Copy the published application
COPY GenealogyApi/publish/ .

# Expose port 8080
EXPOSE 8080

# Set the entry point
ENTRYPOINT ["dotnet", "GenealogyApi.dll"]
