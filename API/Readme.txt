dotnet tool install --global dotnet-ef
dotnet ef migrations add "InitialDB" --project DOTR.QLess.Infrastructure --startup-project DOTR.QLess.API -o ./Persistence/Migrations --context QLessDbContext
dotnet ef database update --startup-project DOTR.QLess.API --context QLessDbContext
	