# SCVNetFramework
[![Build Status](https://dev.azure.com/scanet9/SCV/_apis/build/status/scanet9.SCVNetFramework?branchName=master)](https://dev.azure.com/scanet9/SCV/_build/latest?definitionId=2&branchName=master)

Base framework for creating REST APIs in NET 5.

## Structure:
### Framework folder
Contains a DataLayer project for CosmosDB, including:
- BaseDocument abstract class.
- Repository pattern with CRUD operations.
- UnitOfWork pattern for habving atomic transactions.

### Demo folder:
Contains a full REST API using the framework project. Includes:
- Basic CRUD functionalities for user management
- JWT token-based authorization.
- Swagger UI.

### azure-pipelines.yml file
Builds the framework project and publishes it in a private Azure Devops Artifacts feed.

## Author
Sergi Canet Vela

## License
This project is licensed under the terms of the MIT license.
