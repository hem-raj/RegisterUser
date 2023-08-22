## Simple CRUD operation in ASP.Net Core MVC with ASP.Net Core WebApi and PostgreSQL database


It is an example project in .NET Core 7.0. To run the project in VS Code:
- Clone the repository and open the root folder in VS Code. Right/Control-click the RegisterUserAPI project and select Open in Terminal. Check that RegisterUserAPI project folder is the current folder in the path in terminal window. Run the following commands:
- Install PostgreSQL package & entity framework tool:
```shell
dotnet add package Npgsql.EntityFrameworkCore.
dotnet tool install --global dotnet-ef
```

- Install other packages (You can try to skip this step, if it will give error of below packages/tools, then you can install these packages/tools also.)
```shell
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design -v 7.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design -v 7.0.0
dotnet add package Microsoft.EntityFrameworkCore.SqlServer -v 7.0.0
dotnet tool uninstall -g dotnet-aspnet-codegenerator
dotnet tool install -g dotnet-aspnet-codegenerator
dotnet tool update -g dotnet-aspnet-codegenerator
```
- Create Database from your Entity Classes/Models:
```shell
dotnet ef database update --verbose
```
- and now click on the Run & Debug button in left bar of VS Code and then select "WebApp & RegisterUserAPI" from the "RUN AND DEBUG" drop down and click on the Start Debugging button which is on left to this drop down list or press F5 to run the project. If you have [.NET 7.0 SDK](https://dotnet.microsoft.com/en-us/download) installed with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) Visual Studio Code extension then you will be able to run it easily.

- If it will show a warning dialog box for https/ssl certificate then trust that.

Note: It is not recommended to handle password this way i.e. we should always store passwords with some kind of encryption. It is just to show the CRUD operations in .Net Core 7.0. I will make it's second version which will have DTO to return only the requied data and not password when it is not required and something more.

### Projects in the solution RegisterUser.sln

1. RegisterUserAPI:
> It is the .NET Core Web API Project. You can check UserDetailsController.cs which is returning data from Database.

2. WebApp:
> It is the .NET Core MVC Project to display the CRUD UI. You can check UserDetailsController.cs which has all the Action Methods of Create, Read, Update & Delete. The related Views are in Views/UserDetails Folder.
