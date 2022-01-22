# SCVNetFramework
[![Build Status](https://dev.azure.com/sergicanet9/SCV/_apis/build/status/sergicanet9.SCVNetFramework?branchName=master)](https://dev.azure.com/sergicanet9/SCV/_build/latest?definitionId=3&branchName=master)

Base framework for building REST APIs in NET 5.

## Structure
### Framework folder
Contains the DataLayer framework projects, one for Cosmos DB and the other for SQL server. Both projects include:
- BaseDocument/BaseEntity abstract class.
- Repository pattern with CRUD operations using Entity Framework.
- UnitOfWork pattern for having atomic transactions.

### Demo folder
Contains two REST APIs as examples for using the framework project. One API is Cosmos-based and the other is SQL-based. Both APIs include:
- Basic CRUD functionalities for user management
- JWT token-based authorization.
- Swagger UI.

### azure-pipelines.yml file
Builds the framework projects and publish them as nuget packages in a private Azure Devops Artifacts feed.

## Usage
For being able to install the framework nuget packages, the following private feed needs to be added in Visual Studio nuget sources: https://pkgs.dev.azure.com/sergicanet9/SCV/_packaging/SCVFeed/nuget/v3/index.json
## Author
Sergi Canet Vela

## License
This project is licensed under the terms of the MIT license.
