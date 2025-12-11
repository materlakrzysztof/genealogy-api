For update `dotnet ef` tool run following command:
```commandline
dotnet tool update --global dotnet-ef
```
Every migrations commands should be run from GenoAdvisor.Api project directory:
```commandline
cd .\GenealogyApi
```

For crating initial migration run commands:
```commandline
dotnet ef migrations add InitialCreate --context GenealogyDbContext --project ..\Genealogy.Database\Genealogy.Database.csproj --output-dir Migrations
```
 
For creating new migration run commands:
```commandline
dotnet ef migrations add [MigrationName] --context GenealogyDbContext --project ..\Genealogy.Database\Genealogy.Database.csproj --output-dir Migrations
```

For removing last migration run command:
```commandline
dotnet ef migrations remove --context GenealogyDbContext --project ..\Genealogy.Database\Genealogy.Database.csproj
```
