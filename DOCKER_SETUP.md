# HomeServer Docker Compose Setup

This setup containerizes the HomeServer solution with Docker Compose.

## Services

- **homerserver-extapi**: The main ASP.NET Core API service running on port 8080/8443
- **netdata**: Netdata monitoring service on port 3004

## Quick Start

### Build and start all services:

```bash
docker-compose up -d
```

### View logs:

```bash
# All services
docker-compose logs -f

# Specific service
docker-compose logs -f homerserver-extapi
```

### Stop all services:

```bash
docker-compose down
```

### Rebuild images after code changes:

```bash
docker-compose up -d --build
```

## Configuration

Edit the `.env` file to configure:
- `NETDATA_BEARER_TOKEN`: Your Netdata bearer token
- `ASPNETCORE_ENVIRONMENT`: Development or Production

## Accessing Services

- **API**: http://localhost:8080
- **Swagger/OpenAPI**: http://localhost:8080/swagger
- **Netdata**: http://localhost:3004

## Development

For development with live reloading, you can use:

```bash
docker-compose up -d homerserver-extapi
```

Mount your source code in the container by editing the `docker-compose.yml` volumes section to reflect your local development path.

## Building Production Images

To build a production-ready image:

```bash
docker build -t homerserver-extapi:latest --target runtime .
```

## Network Communication

Services communicate via the `homeserver-network` Docker network. Internal service names can be used:
- API: `http://homerserver-extapi:8080`
- Netdata: `http://netdata:3004`
