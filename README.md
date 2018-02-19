# swiper.backend
Holds the backend for the swiper.android and swiper.ios applications. The API can be accessed as REST structure

## ch.cena.swiper.backend.api
API entry point and Configuration setup.
Handling of validation Errors and correct response to the requesting User
Authentication and Authorization is done inside this project. (Future Reqirement)

## ch.cena.swiper.backend.data
This project holds Entity Framework Models and the DBContext. 
Migrations for code first DB creation is inside ./Migrations

### useful commands:
create a migration inside date with config from api startum
```
dotnet ef migrations add -s ../swiper.backend.api/ <NAME_OF_MIGRATION>
```
update database with current migrations
```
dotnet ef database update -s ../swiper.backend.api/ 
```
or
```
dotnet ef database update -s ../swiper.backend.api/ <NAME_OF_MAX_MIGRATION>
```
Run **Docker MSSQL** instance on Linux basis to be used in DevEnv 
```
docker run --name cenaDevSQL -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 -d microsoft/mssql-server-linux
```

Run **Docker Postgres** instance. for DevEnv
```
docker run --name cenaPostgres -e 'POSTGRES_USER=cena' -e 'POSTGRES_PASSWORD=yourStrong(!)Password' -p 5432:5432  -d postgres
```

## ch.cena.swiper.backend.service
This project holds services to handle API reqests in a seperate Layer. Validation sould be done here.
