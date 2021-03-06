# todo-list
ToDo List manager allows users to register using email and then login to add ToDos with Description, Due date and Priority, and the ability to edit, delete and mark a ToDo as completed.

<b>Design Patterns</b><br/>
Domain Driven Design pattern is used to implement the backend which can be seen in the implementation of different layers, the use of Single Responsiblity Principle, the Repository pattern even when we are using EF and CQRS for Domain Model's abstraction from the outside world. Domain Driven Design helps immensely in case of maintaining large and evolutionary projects.

<b>Architecture</b><br/>
Backend is developed in C# using the .NET Framework and utilizes:<br/>
    - ASP.NET Web Api for providing RESTful architecture<br/>
    - Entity Framework as ORM<br/>
    - Ninject as the dependency resolver<br/>
    - Microsoft Identity for handling users and account<br/>
    - OWIN(Katana) pipeline as the interface between the web application and web server.<br/>
    <br/>
Frontend is created as a .NET Core project, and uses AngularJS to create a Single-Page-Application. Grunt copy tasks are used to copy the javascript files to the wwwroot folder as soon as they are added or updated.
<br/><br/>
<b>Prerequisites</b><br/>
Visual Studio 2017<br/>
MySql Community Server 5.7 (Having MySql Workbench installed too is a plus)<br/>
<br/>
<b>How to Run</b><br/>
Database:<br/>
Even though EF Code first is being used, the database structure is dumped as a .sql file which needs to be imported. The reason for this is that having the database created with every run is risky in production environments which can result in data loss. Thus, having a backup file and loading it manually is the right approach in my opinion. To do that:<br/>
- Create a new database using WorkBench or the command line<br/>
- Open MySql WorkBench<br/>
- Log in with the root account. Create one if this is the first time you are logging in.<br/>
- Click Server --> Data Import. Choose the database to import to. Locate the sql dump in the solution: Backend/Data/MySql/create.sql.<br/>
- Click Import. The sql dump will be imported, and the database is all set to be used.<br/>
- The connection string for the application is located inside Backend/Common/ToDoApp.Common.WebHost project, inside web.config file with the name "MySql". The username and password can be changed. The account credentials that the application is using are testuser:Wired987#, so either change the credentials in the web.config or create a user with these credentials in MySql. This can be done in Myql WorkBench by going to Server -> Users & Privileges and creating a new user.
- Allow 'MaintenanceAdmin' Priviliges to this user. This can be done in MySql WorkBench by going to Server -> Users & Privileges, click on the desired user and then select the Administrative Roles tab.

Backend:<br/>
- Right click on the Solution and choose 'Restore Nuget Packages'<br/>
- Once the packages are restored, right click the project Backend/Common/ToDoApp.Common.WebHost -> Debug -> Start New Instance.<br/>

Frontend:
 - Click Views --> Other Windows --> Task Runner Explorer.
 - Once the task runner explorer window appears, you should be able to see GruntFile.js -> Alias Tasks -> Default. Right click on Default and select Run.
 - Right click the project Frontend/ToDoApp.Frontend, Debug -> Start New Instance.
 <br/>
 A new window will appear with the login screen and is ready to register new users, log them in and have new ToDos created.<br/>
