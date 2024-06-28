# Install

## Run on Docker

> [!WARNING] > **Install [Docker CLI](https://docs.docker.com/engine/install) > version `26.0.0`**

> [!WARNING] > **Install [Docker Compose CLI](https://docs.docker.com/compose/install) > version `v2.27.1`**

```bash
$ make docker.up # Run app
$ make docker.build # Rebuild & delete old images
$ make docker.down # Stop all container
```

## Manual start

### SQLServer

> [!WARNING] > **Install [Docker CLI](https://docs.docker.com/engine/install) > version `26.0.0`**

```bash
$ make mssql.create # Create container SQLServer (Warning: First run)
$ make mssql.start # Run container SQLServer
$ make mssql.delete # Delete container & volume SQLServer (Warning: All data will be deleted)
```

### Database

> [!WARNING] > **Install [EF Tool](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) version `8.0.6`**

```bash
$ make db.add name=Initial # Create migrations name={New name migration}
$ make db.update # Update tables in database
$ db.remove # Remove last migration
$ db.list # List migration
$ make db.drop # Delete database (Warning: All data will be deleted)
```

### Run

```bash
$ make
```

## Endpoint

- Api:

  - Host: `localhost`
  - Port: `5000`

- Sql server:

  - Username: `SA`
  - Password: `Password123`
  - Host: `localhost`
  - Port: `1433`

- MailHog:
  - Web:
    - Host: `localhost`
    - Port: `8025`
  - SMTP:
    - Host: `localhost`
    - Port: `1025`

