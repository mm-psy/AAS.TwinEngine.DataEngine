# DataEngine

**DataEngine** is a .NET-based service that dynamically generates complete **Asset Administration Shell (AAS)** submodels by combining standardized templates with real-time data.
It integrates with **Eclipse BaSyx** and follows **IDTA specifications** to ensure interoperability.
When a submodel is requested, DataEngine retrieves its template, queries the **Plugin** for semantic ID values, and populates the structure automatically.
It supports nested and hierarchical data models, providing ready-to-use submodels for visualization or API consumption.
In short, DataEngine acts as the **core orchestration layer** that transforms static AAS templates into live digital representations.

## Features

- **Dynamic Submodel Generation**: Combines AAS templates with live data from plugins
- **IDTA Compliant**: Follows IDTA specifications for full interoperability
- **BaSyx Integration**: Works seamlessly with Eclipse BaSyx infrastructure
- **Multi-Plugin Support**: Aggregate data from multiple plugin sources with configurable conflict resolution
- **Template-Based**: Separation of structure (templates) from data (plugins)
- **RESTful APIs**: Exposes AAS Registry, AAS Repository, Submodel Registry, and Submodel Repository endpoints

## Quick Start

### Prerequisites

- Docker and Docker Compose
- .NET 8.0 SDK (for development)

### Running with Docker Compose

The easiest way to get started is using the provided Docker Compose setup:

```bash
docker-compose up -d
```

This will start:
- DataEngine service on port 8085
- Template repositories and registries
- Example plugin service
- Nginx gateway on port 8080

### Accessing the API

Once running, the DataEngine API is available at:
- **Gateway**: http://localhost:8080
- **Direct Access**: http://localhost:8085

## Documentation

For detailed information about architecture, concepts, and API endpoints, see:
- **[CoreConcepts.md](CoreConcepts.md)**: Comprehensive guide to DataEngine architecture and concepts
- **[example/](example/)**: Example configurations and API collections

## Project Structure

```
├── source/                          # Source code
│   ├── AAS.TwinEngine.DataEngine/          # Main service
│   ├── AAS.TwinEngine.DataEngine.UnitTests/     # Unit tests
│   ├── AAS.TwinEngine.DataEngine.ModuleTests/   # Module tests
│   └── AAS.TwinEngine.Plugin.TestPlugin/        # Test plugin implementation
├── example/                         # Example configurations and data
├── docker-compose.yml              # Docker Compose setup
└── CoreConcepts.md                 # Detailed documentation
```

## Development

### Building

```bash
cd source
dotnet build
```

### Running Tests

```bash
dotnet test
```

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

