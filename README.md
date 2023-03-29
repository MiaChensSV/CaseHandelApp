# Insurance Issue Report
CaseHandel app made with .NET and Entity Framework Core. 

## About this app
-CaseHandel is a simple console application where you can register as a customer, register a case about damage as a user and severvice man can make a comment, update case status. 

The database schema is set up with Entity Framework using a code-first approach and the data is stored in a local SQL Server file: case_handel_local_db. The application has simple CRUD functionality.



## Running the app locally
❗ Make sure you have the latest version of the .NET sdk installed ❗
### Restore all the necessary NuGet dependencies:
```$ dotnet restore```
### Update the _connectionstring field found in DataContext.cs and make sure the path points to your local project.
```// TODO: Update this string to your local project path
string _connectionstring = @"C:\YOUR_PATH_HERE";```
