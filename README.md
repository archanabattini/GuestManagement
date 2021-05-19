# GuestManagement

## Solution Approach:

Created a Visual Studio Solution consisting of 3 projects; 
A Class Library for Core Models and interfaces [GMServices]
A Class Library for Data Access and Repositories [GMDAO]
An MVC Core project for presentation using Knockout JS as MVVM framework [Guests]

## Visual Studio Steps

* Git clone or download the project - https://github.com/archanabattini/GuestManagement.git

* Open the solution in Visual studio

* Change ConnectionString in GMDAO --> Contexts --> GuestDbContext file

* Migration file exists GMDAO --> Migrations folder. Please execute 'Update-Database' in Package Manager Console (If any issues, please remove the migrations file and run 'Add-Migration Initial')

* Change Connection strings in Guests --> appsettings.json file

* Set Guests as a start up project

* Build and Run the project



