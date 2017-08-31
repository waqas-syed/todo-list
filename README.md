# todo-list
ToDo List manager with complete functionality to add ToDos with Description, Due date and Priority, and the ability to edit delete and mark a ToDo as completed.
Domain Driven Design pattern is used to implement the backend which can be seen in the implementation of different layers, the use of Single Responsiblity Principle, the Repository pattern even when we are using EF and CQRS for Domain Model's abstraction from the outside world. Domain Driven Design helps immensely in case of maintaining large and evolutionary projects.

<b>Architecture</b>

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
Even though EF Code first is being used, the database structure is dumped as a .sql file which needs to be imported. To do that:<br/>
- Create a new database using WorkBench or the command line<br/>
- Open MySql WorkBench<br/>
- Log in with the root account. Create one if this is the first time you are logging in.<br/>
- Click Server --> Data Import. Choose the database to import to. Locate the sql dump in the solution: Backend/Data/MySql/create.sql.<br/>
- Click Import. The sql dump will be imported, and the database is all set to be used.<br/>

Backend:<br/>
- Right click on the Solution and choose 'Restore Nuget Packages'<br/>
- Once the packages are restored, right click the project Backend/Common/ToDoApp.Common.WebHost -> Debug -> Start New Instance.<br/>
<br/>
Frontend:<br/>
 - Click Views --> Other Windows --> Task Runner Explorer.<br/>
 - Once the task runner explorer window appears, you should be able to see GruntFile.js -> Alias Tasks -> Default. Right click on Default and select Run.<br/>
 - Right click the project Frontend/ToDoApp.Frontend, Debug -> Start New Instance.<br/>
 <br/>
 A new window will appear with the login screen and is ready to register new users, log them in and have new ToDos created.<br/>
