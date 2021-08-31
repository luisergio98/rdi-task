# rdi-task
Simple Token Generator API with CRUD

## English

### How to run the project

This project was built on top of .NET 5.0 using Visual Studio 2019 and SQL Server 2019. It is highly recommended that you use these platforms to run it.

First check if the project nugets are installed in the solution. To do this open the Solution Explorer, right-click on the solution and then click Manage Nuget Packages for Solution. Then on the Installed tab check if the following packages are installed:

<div align="center">
  
![image](https://user-images.githubusercontent.com/28768906/131436269-25e46b5f-cc60-422b-9647-a7d99f09a927.png)
  
</div>

The second step to run the project is to create a database and get its connection string. For this you will need to have SQL Server installed on your machine and do the following steps: Click in View tab and then click SQL Server Object Explorer. Then click on the the server symbol with a green plus sign to create a new connection. In the window that opens, click on one of the databases that will appear. In case you already have an instance created on your machine it will appear in this list too. 

<div align="center">
  
![image](https://user-images.githubusercontent.com/28768906/131436369-e5113065-a7e1-4232-a2ee-0698d997356d.png)

![image](https://user-images.githubusercontent.com/28768906/131436422-4fca0aa1-31c2-4cd5-8e91-06a4a82c1190.png)

![image](https://user-images.githubusercontent.com/28768906/131436461-362eaa8d-ed58-4e55-8772-d23646096b09.png)
  
</div>

After selecting the database and filling in its credentials if necessary, expand the database's attributes and right-click on it and then click in Properties. With that you see the connection string and copy it in its entirety. After copying it you will need to replace the line in the appsettings.Development.json file with the new copied one. If you want, you can configure the database any way you want, however there may be a need to make changes to the project. 

<div align="center">
  
![image](https://user-images.githubusercontent.com/28768906/131436526-a9ca8d6a-d482-4561-bfd1-b19ca9d8fdc5.png)

![image](https://user-images.githubusercontent.com/28768906/131436568-3e5bb4af-29e2-4f1f-b380-ccd54e1ccf29.png)

![image](https://user-images.githubusercontent.com/28768906/131436631-3bb8cf74-fc14-4e51-9885-49e3202e8115.png)
  
</div>

If you want to automatically create a new database for your data (without running migrations) just add "Initial Catalog=YOURDATABASENAME;" in the connection string after the "Data Source".

Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CreditCardDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False

If you are unsure how to set up a database, visit the Microsoft documentation:
https://docs.microsoft.com/pt-br/sql/ssdt/how-to-connect-to-a-database-and-browse-existing-objects?view=sql-server-ver15

By doing these steps you can now run the Web project and test the system.

After you run the project you can test the API. All the methods hava a simple description and are documented.

<div align="center">
  
![image](https://user-images.githubusercontent.com/28768906/131436925-65036476-6fee-4885-b612-003bbafdd064.png)

</div>

If you need some support you can send a message.
