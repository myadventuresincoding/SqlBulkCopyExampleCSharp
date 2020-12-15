# SqlBulkCopyExampleCSharp
Simple example using SQL Server bulk insert from C#

## Prerequisites
If you already have SQL server, great! However, if you do not you can download and install SQL Express.

* Download [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
* Download [SQL Server Management Studio](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)

## Create Database
The scripts you will need are in the folder: db

* Create_Database_and_User.sql
    * Create a new database called "Examples" and the user "client"
* Create_Table.sql
    * Create the table dbo.DailySalesStats
* Select.sql
    * Example select statement to query dbo.DailySalesStats

## Run the Application
Open the solution in Visual Studio and run the main class in DataTableExample.cs

* You will need to edit the host in the connection string if you are not using localhost and SQLExpress