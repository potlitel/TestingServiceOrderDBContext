## Project that showcases the use of a custom DBContext for working with service orders.

## Tech Stack

**UI:** [Swagger UI](https://swagger.io/tools/swagger-ui/)

**Build Tool:** [Visual Studio](https://visualstudio.microsoft.com/)

## Features

- Allowing the import of endpoints for handling CRUD operations on base entities.
- Docker deployment using https with custom cert.
- etc...

## Run Locally

Clone the project

```bash
  git clone https://github.com/potlitel/TestingServiceOrderDBContext.git
```

Go to the project directory

```bash
  cd TestingServiceOrderDBContext
```

Install dependencies

```bash
  dotnet restore --verbosity normal
```

Start the server

```bash
  dotnet run --project WebApiSO/WebApiSO.csproj
```



