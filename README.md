# ConvertionAPI

Steps to run api project
1) Get code from git repo copy to any local driver.

2) Restore SQL database from ConvertionDB.bak file. 
Note: If bak file didnt work we can create database name in sql with name "ConvertionDB" and run "ConvertionDB.sql" sql file on database.

3) Open ConvertionApi/ConvertionApi.sln 

4) Change connection string in appsetting.json
 - ConfigDB to database server connection

5) Run API project.
