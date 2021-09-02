Running the API

1. Open the API folder
2. Open DOTR.QLess.Api.sln solution file
3. On the DOTR.QLess.Api project, open the appsettings.json file and replace the connection string value according to checker’s SQL server configuration. Save the file.
4. Open Package Manager Console  and run the following command
	- dotnet tool install --global dotnet-ef
	- dotnet ef migrations add "InitialDB" --project DOTR.QLess.Infrastructure --startup-project DOTR.QLess.API -o ./Persistence/Migrations --context QLessDbContext
	- dotnet ef database update --startup-project DOTR.QLess.API --context QLessDbContext
5. Run the API(Press F5)
6. Take note the auto generated  assigned port number by to the WEB API.


Running the Angular APP

1. Open command prompt/terminal and points the current directory to the exam’s Web folder, and run the following command.
	
       npm install

   2. Open environtment.ts file from /src/environments/ and replace the 
       The port number on baseApiUrl property using the assigned port   	 number for the API.

  3.  Run the following command
	npm serve —open