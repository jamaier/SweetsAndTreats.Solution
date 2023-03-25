# Pierres Sweets and Treats

### Creator

_Jacob Maier_

## Description

_This web application uses many to many relationships by combining `Flavors` and `Treats` together together in any fashion the user choses._ 
_It also has full CRUD capablility to alter the data however the user sees fit._
_It currently has authorization to the extent that the user must create an account to alter any data but outside viewers can view existing data._
_The ability to add admin roles is present but not currently working._

## Technologies Used

* _C#_
* _Entity Framework Core_
* _ASP .NET6_
* _ASP Identity_
* _MySQL_
* _Html_
* _CSS_
* _BootStrap_

## Setup/Installation Requirements

* _Clone this repo to your local machine._
* _Install MySQL Community Server and MySQL Workbench's latest version using legacy Password of your choice_
    - _[For Windows](https://downloads.mysql.com/archives/get/p/25/file/mysql-installer-web-community-8.0.19.0.msi)_
    - _[For Mac](https://dev.mysql.com/downloads/file/?id=508094)_
* _Install tool to update database with `dotnet tool install --global dotnet-ef --version 6.0.1`_
* _Restore required packages: change directory to `SweetsAndTreats` and restore with `$ dotnet restore`._

## Database Setup

* _To connect your database, create file `appsettings.json` in the `SweetsAndTreats` directory. (Make sure not to create it in the root folder)_
* _Fill in the file with the following code: Be sure to replace the required fields marked with `[]` that must contain the database name, user id, and password._
```
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=[DB-NAME-HERE];uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
    }
}
```
* _From the top level of the directory use `$ dotnet build` to build the program or `dotnet run` to view the app in the browser from `localhost:5001`._
* _To include this projects' data structure, change directory to `SweetsAndTreats`, and run `dotnet ef migrations add Initial` and then run `dotnet ef database update`_


## Known Bugs

* _Currently Roles are not working as intended._ 

## License

_MIT_

_Copyright (c) 2023 Jacob Maier_

