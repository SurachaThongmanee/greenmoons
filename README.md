# How to Run the Code
To run the code, follow these steps to set up the solution with two projects: one for `RandomNumber` and the other for `SearchFunction`, and then refactor the code accordingly.
## RandomNumber Project:
1. Set as Start-up Project:
  - Right-click on the `RandomNumber` project.
  - Select "Set as Start-up Project" from the context menu.
2. Run the Project:
  - Press `F5` or click on the "Run" button to execute the code.
#SearchFunction Project:
1. Set as Start-up Project:
  - Right-click on the `SearchFunction` project.
  - Select "Set as Start-up Project" from the context menu.
2. Add Data to Database:
  - Uncomment the code within the region labeled "Add Data to DB" line 29-32 in the `Program.cs` file.
3. Update Connection String:
  -  Change path connection string the region labeled `Connection String` line 100 in the `Program.cs` file.
4.Generate Migration:
  - Run the command Add-Migration YourMigrationName in the Package Manager Console to generate a migration based on your changes.
5.Update Database:
  - Execute the command Update-Database in the Package Manager Console to apply the migration and update the database schema.
6.Run the Project:
  - Press `F5` or click on the "Run" button to execute the code.
  - Input the name of the search when prompted.
By following these steps, you'll be able to successfully run the code for both projects, RandomNumber and SearchFunction, after setting up the solution and making necessary adjustments.
