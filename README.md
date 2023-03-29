# Running the app locally
❗ Make sure you have the latest version of the .NET sdk installed ❗
## Restore all the necessary NuGet dependencies:
```$ dotnet restore```
## Update the _connectionstring field found in DataContext.cs and make sure the path points to your local project.
```// TODO: Update this string to your local project path
string _connectionstring = @"C:\YOUR_PATH_HERE";```
