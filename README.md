# RandomNumber Project:
1. Set as Start-up Project:
  - Right-click on the RandomNumber project.
  - Select "Set as Start-up Project" from the context menu.
2. Run the Project:
  - Press F5 or click on the "Run" button to execute the code.
#SearchFunction Project:
1. Add Data to Database:
  - Uncomment the code within the region labeled "Add Data to DB" in the Program.cs file.
2. Update Connection String:
  - Modify the connection string path as needed in the appsettings.json file.
3.Generate Migration:
  - Run the command Add-Migration YourMigrationName in the Package Manager Console to generate a migration based on your changes.
4.Update Database:
  - Execute the command Update-Database in the Package Manager Console to apply the migration and update the database schema.
5.Run the Project:
  - Press F5 or click on the "Run" button to execute the code.
  - Input the name of the search when prompted.
By following these steps, you'll be able to successfully run the code for both projects, RandomNumber and SearchFunction, after setting up the solution and making necessary adjustments.
