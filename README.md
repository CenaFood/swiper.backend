# swiper.backend

Holds the backend for the swiper.android and swiper.ios applications. The API can be accessed as REST structure. It is based on [ASP.Net Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-2.1) 2.x Web API with [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/index)

## Project Structure

### ch.cena.swiper.backend.api

API entry point and Configuration setup.
Handling of validation Errors and correct response to the requesting User
Authentication and Authorization is handled in this layer.

`Program.cs` starts the WebServer with the configuration made in `Startup.cs`. ASP.Net Core is heavily built around dependency injection. Configuration and Services can be therefore injected very easily. All injection configuration and registration is done inside `configureServices()` We use [Configuration and options in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-2.1) for easy configuration prioritization for different environments. Services can be added like:

```csharp
services.AddTransient<IAnnotationService, AnnotationService>();
```

Interchangeable services should be masked by any Interface. These and other Contracts may be defined inside `ch.cena.swiper.backend.service/Contracts`.

#### API Endpoints / Controllers

Each API Endpoint is defined inside `./Controllers`. All controllers must follow `NAMEController.cs`-Naming convention. Different HTTP verbs and routes can then be defined on each controller and/or method.

The constructor may use any injectable instance from `Startup.cs`. All changes to the Database should be done through the service layer.


### ch.cena.swiper.backend.data

This project holds Entity Framework Models and the DBContext. 
Migrations for code first DB creation is inside ./Migrations
All saved entities are represented as Classes inside ./Models. Swipercontext.cs represents the DB-Context on which changes can be applied. All entities must be registered here.


### ch.cena.swiper.backend.service

This project holds services to handle API requests in a separate Layer. Validation could be done here before storing to DB. Each service should be defined by any interface inside `./Contracts`.

## Deployment

### Docker 

`ch.cena.swiper.backend.api` contains a Dockerfile to build the image. Use Visual Studio 2017 if not familiar with Docker build. Use Release config. The docker image will be tagged with `chcenaswiperbackendapi:latest`. This image can be retagged and published with (publish.sh):

```bash
docker tag chcenaswiperbackendapi:latest YOURREGISTRYSERVER:5000/chcenaswiperbackendapi:latest
docker push YOURREGISTRYSERVER:5000/chcenaswiperbackendapi:latest

```

Use and adapt following `docker-compose.yml` for deployment on your server with `docker-compose up`.

```yaml
version: '3.4'
services:
  ch.cena.swiper.backend.api:
    image: chcenaswiperbackendapi
    build:
      context: .
      dockerfile: swiper.backend.api/Dockerfile
    # added port, in Dockerfile 80 is exposed which is mapped to 5000
    ports:
      - "80:80"
    # Mount your local path to /images
    volumes:
      - /images:/images
      - /pickup:/pickup
    #Overwrite default values
    environment:
      ConnectionStrings__PostgresConnection: 'Host=db;Database=cena;Username=cena;Password=yourStrong(!)Password'
      Hosting__HostingUri: 'https://YOURSERVER'
      Hosting__JwtKey: 'secret' #Exchange with actual JwtKey
      Hosting__JwtIssuer: 'https://YOURSERVER'
      Hosting__JwtExpireDays: 5

      #Only define if migration is needed.
      Migration__CreateProject: 'false'
      Migration__Migrate: 'false'
      Migration__ProjectName: 'cena'
      Migration__ChallengeTypeName: 'cenaSwiper'
      Migration__ChallengeQuestion: 'Would you like to eat this here and now?'
      Migration__ChallengeAnswers: '["Yes", "No", "No Food"]'
    # make the backend dependent on the sql server
    depends_on:
        - db
    # include the sql server into the container
  db:
    image: "postgres"
    environment:
      POSTGRES_USER: 'cena'
      POSTGRES_PASSWORD: 'yourStrong(!)Password'
```

## REST-API

### Authentication

POST to `auth/register` or `auth/login`
in (json):

```json
{
  "email":"your@email.com",
  "password":"Minimun6Long"
}
```

out (string) JWT token or 401 Unauthorized it email already in use:

```json
"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"
```

### Protected Routes

Use JWT Token as Authorization header like:
`"Authorization":"Bearer eyJ...w5c"`

### Get Challenges (Protected)

GET `/challenges` returns list of 20 challenges:

```json
[
{
  "id": "57abccec-53a8-4c0a-8680-1ce09aeced5a",
  "projectID": "998e45a4-d23b-41fb-aa1d-d8f47fc8ce11",
  "challengeType": "cenaSwiper",
  "description": "Would you like to eat this here and now?",
  "image": {
    "fileName": "1675552031564067609.jpg",
    "fileExtension": ".jpg",
    "height": 512,
    "width": 512,
    "url": "https://cenaswiper.luethi.rocks/images/1675552031564067609.jpg"
  },
  "answers": [
    "Yes",
    "No"
  ]
},
{
  ...
}
]
```

### Make annotation (Protected)

POST to `/annotations` with json:

```json
{
 challengeID: "57abccec-53a8-4c0a-8680-1ce09aeced5a",
 answer: "No",
 latitude: 47.4809342,
 longitude: 8.2117488,
 localTime: "2018-07-05T13:59:33.966Z"
}
```

## Useful commands

create a migration inside data with config from api startup. Migrations are not driver agnostic.

```bash
dotnet ef migrations add -s ../swiper.backend.api/ <NAME_OF_MIGRATION>
```

update database with current migrations

```bash
dotnet ef database update -s ../swiper.backend.api/
```

or

```bash
dotnet ef database update -s ../swiper.backend.api/ <NAME_OF_MAX_MIGRATION>
```

Run **Docker MSSQL** instance on Linux basis to be used in DevEnv

```bash
docker run --name cenaDevSQL -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 -d microsoft/mssql-server-linux
```

Run **Docker Postgres** instance. for DevEnv

```bash
docker run --name cenaPostgres -e 'POSTGRES_USER=cena' -e 'POSTGRES_PASSWORD=yourStrong(!)Password' -p 5432:5432  -d postgres
```
