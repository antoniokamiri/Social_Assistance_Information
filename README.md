📋 Overview
This is a web-based Applicant Registration and Management System built using Blazor, bootstrap and MudBlazor UI Components. The system allows you to:

  1. Register new applicants
  
  2. Manage application statuses
  
  3. View applicant details
  
  4. Filter and paginate records
  
  5. Use dynamic form controls based on configuration parameters

🚀 Getting Started
🔧 Prerequisites
Before running the solution, make sure you have the following installed:

  a) .NET 9 SDK or later
  
  b) Visual Studio 2022 or later
  
  c) SQL Server or LocalDB (if database is used)
  
  d) Git (optional, for cloning the repository)

🛠️ Setup Instructions
1. 📥 Clone the Repository
  bash
  git clone https://github.com/antoniokamiri/Social_Assistance_Information.git
  cd Social_Assistance_Information

2. 🛠️ Open the Solution
Open the .sln file in Visual Studio

3. ⚙️ Configure appsettings.json
Navigate to the Server or API project and update the connection string:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}

4. 📦 Restore NuGet Packages
In Visual Studio, go to:
  - Tools > NuGet Package Manager > Package Manager Console
Then run:
  - dotnet restore

5. 🧱 Apply Database Migrations
  cd YourProject.Infrastructure
  dotnet ef database update

6. ▶️ Run the Application
In Visual Studio:
  - Set the Server project as the startup project.
  - Press F5 or click Run
Then visit:
📍 https://localhost:5001
  

The app will launch in your default browser.

UserName:admin@sais.com
Password:Reset!@123
