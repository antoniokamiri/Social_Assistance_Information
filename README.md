# Social_Assistance_Information
This is a Blazor WebAssembly (or Server — specify if needed) application designed to connect to a SQL database. Follow the steps below to run the application locally and configure your database connection.

git clone https://github.com/antoniokamiri/Social_Assistance_Information.git
cd your-repo-name

🚀 Getting Started
Prerequisites
Visual Studio 2022 or later

.NET 9 SDK

SQL Server or any local SQL database instance

🔧 Configuration
Before running the app, you need to configure the connection string to point to your local SQL database.

Open the appsettings.json (or appsettings.Development.json) file.

Locate the ConnectionStrings section.

Replace the default connection string with your local SQL database connection. Example:

json
Copy
Edit
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=YourDbName;Trusted_Connection=True;MultipleActiveResultSets=true"
}


✅ Make sure the you update the connection string to match your setup.

▶️ Running the App
You can run the app directly from Visual Studio:

Open the solution (.sln) file in Visual Studio.

Set the Blazor project as the startup project.

Press F5 (Run with Debugging) or Ctrl + F5 (Run without Debugging).

The app will launch in your default browser.

UserName:admin@sais.com
Password:Reset!@123
