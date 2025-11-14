# genealogy-api

A simple .NET 10.0 Web API with Docker support.

## Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Docker](https://www.docker.com/get-started)

## Project Structure

```
genealogy-api/
├── GenealogyApi/          # Main Web API project
│   ├── Program.cs         # Application entry point
│   ├── GenealogyApi.csproj
│   └── ...
├── Dockerfile             # Docker configuration
└── README.md
```

## Running Locally

### 1. Run with .NET CLI

```bash
cd GenealogyApi
dotnet run
```

The API will be available at `http://localhost:5181`

### 2. Build and Run

```bash
cd GenealogyApi
dotnet build
dotnet run
```

## Running with Docker

### 1. Publish the Application

First, publish the application:

```bash
cd GenealogyApi
dotnet publish -c Release -o ./publish
```

### 2. Build Docker Image

From the root directory:

```bash
docker build -t genealogy-api:latest .
```

### 3. Run Docker Container

```bash
docker run -d -p 8080:8080 --name genealogy-api genealogy-api:latest
```

The API will be available at `http://localhost:8080`

### 4. Stop Docker Container

```bash
docker stop genealogy-api
docker rm genealogy-api
```

## Running with Docker Compose

Docker Compose provides an easier way to manage the container lifecycle:

### Start the Application

```bash
# Build and start in detached mode
docker-compose up -d

# View logs
docker-compose logs -f
```

### Stop the Application

```bash
docker-compose down
```

The API will be available at `http://localhost:8080`

## API Endpoints

### Weather Forecast

- **GET** `/weatherforecast` - Returns a sample weather forecast

Example:
```bash
curl http://localhost:8080/weatherforecast
```

## Technology Stack

- **.NET 10.0** - Latest .NET framework
- **ASP.NET Core** - Web API framework
- **OpenAPI** - API documentation
- **Docker** - Containerization

## Development

### Build

```bash
cd GenealogyApi
dotnet build
```

### Clean

```bash
cd GenealogyApi
dotnet clean
```

### Restore Dependencies

```bash
cd GenealogyApi
dotnet restore
```

## License

This project is licensed under the MIT License.