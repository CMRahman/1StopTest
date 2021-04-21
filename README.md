# 1Stop Project

#### To Run the project:

1. Setup the connection string in the `appsettings.json`

2. Run the migration in the `Infrastructure.Persistence` project
   
   1. Run `update-database` in PMC 

3. Set the `WebAPI` as the startup project



**Note** 

- To create a user provide `admin` as parameter, this is used as mock authorization

- Pleaes select any `State` and `PostCode` from below to create `Address`  for user. Currently a static list is being validated against an Azure Function. 

```csharp
States = ["NSW", "ACT", "QLD", "VIC", "SA"];
PostCodes = 2500 - 2599
```

        

        
