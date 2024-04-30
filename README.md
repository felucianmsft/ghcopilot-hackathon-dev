# Developers Hackathon 🧑‍💻👩‍💻
Welcome to the Developers Hackathon. The goal is to develop a software described in the "Goal" section using the most modern development tools: Azure DevOps Repos/Pipeline for code and automation, GitHub Codespaces as development environment and obtaining assistance from GitHub Copilot.

## Codespace Environment 💻
**Installed Software:** SQL Server 2019, .NET Core, Python, Node.js, JavaScript, TypeScript, C++, Java, C#, F#,  PHP, Go, Ruby, Conda  
**VS Code Extensions:** GitHub Copilot, C#, SQL Server 2019  

**SQL Server Connection**: Server: localhost,1433 - Username: sa - Password: P@ssw0rd  
**Connection string:**  Server=localhost,1433;User Id=sa;Password=P@ssw0rd;Database=[yourDbName];MultipleActiveResultSets=true;Encrypt=False

## Start the Hackathon 🏁
1) Connect to your GitHub Organization
2) Click on 'Code -> Select Codespaces tab -> New with options' and select a machine size to start the codespace
3) Wait for the inizialization of the codespace
4) Select the branch corresponding to your username (i.e. devuser01)
5) Happy coding 😊

# Goal: Audiologist App 👂

The basic workflow of the Application would be as follows:  
	• Audiologist can enter customer data such as name, age, contact information, etc. This data gets stored in the Azure SQL Database.  
	• Audiologist can then enter prescription data for each customer - details of their eye check-up, prescribed glasses/lenses, etc. This data is also stored in the Azure SQL Database.  
	• The app service then retrieves this data from the database and presents it in a user-friendly format. Audiologist can view, update or delete the data as required.  

## Challenges ## 

1. User Interface:
   - The system is a WebApplication and should have an intuitive, user-friendly interface.
2. Customer Management:
   - The system should allow Audiologist to add new customers into the system.
   - The system should allow Audiologist to view, update, and delete customer data.
   - The system should validate customer data input (e.g., check the format of email addresses).
3. Prescription Management:
   - The system should allow Audiologist to add prescription details for each customer.
   - The system should allow Audiologist to view, update, and delete prescription details.
   - The system should allow Audiologist to search prescriptions based on various parameters like customer name, prescription date, etc.
4. Reporting:
   - The system should allow Audiologist to export data in various formats (e.g., PDF, Excel).
5. Performance:
   - The system should be able to handle multiple concurrent users without performance degradation.
   - The system should load data quickly and efficiently.
6. Integration:
   - The system should integrate smoothly with the Azure SQL Database for data storage.
   - The system should integrate with Azure App Service for hosting and scaling the web application.
7. User Authentication:
   - The system should provide a secure login interface for Audiologist.

NOTES:  
Make sure the database structure is initialized by the app when it runs. When deployed a connection string named "DatabaseConnection" for access the final database will be exposed by the Operation teams as Connection String in the App Service and accesible trough an [environment variable](https://learn.microsoft.com/en-us/azure/app-service/configure-common?tabs=portal#configure-connection-strings). For local development you can create your own database by leveraging SQL Server configured within the Codespace.

### Azure DevOps Pipeline
- The application must be build and deployed with the Azure DevOps YAML Pipelines

# GitHub Copilot assistance 🤖
Given the application requirments, try to ask to GitHub Copilot for help, following some suggestions for build a .NET Web Application:
<table>
	<tr><th>Requirements</th><th>Ask to GitHub Copilot…</th></tr>
	<tr>
		<td>The system is a WebApplication and should have an intuitive, user-friendly interface.</td>
		<td>Generate a .NET web application</td></tr>
	<tr>
		<td>Customer Management: <br>
		- The system should allow Audiologist to add new customers into the system. <br>
		- The system should allow Audiologist to view, update, and delete customer data. <br>
		- The system should validate customer data input (e.g., check the format of email addresses). <br>
		</td>
		<td>
		1. Generate a model a Customer with following data: ID, Name, Surname, Address, BirthDate, Mail, Phone  <br>
		2. Add NuGet packages for Entity Framework  <br>
		3. Generate Razor Pages for Create, Read, Update, and Delete by using scaffold tool for model Customer  <br>
		4. Add EF Initial database schema  <br>
		</td>
	</tr>
	<tr>
		<td>Prescription Management: <br>
		- The system should allow Audiologist to add prescription details for each customer. <br>
		- The system should allow Audiologist to view, update, and delete prescription details. <br>
		- The system should allow Audiologist to search prescriptions based on various parameters like customer name, prescription date, etc. <br>
		</td>
		<td>
		1. Generate a model for prescriptions associated to a Customer <br>
		2. Generate Razor Pages for Create, Read, Update, and Delete by using scaffold tool for model prescriptions <br>
		3. Add EF migration for prescription <br>
		4. Add search to prescription. Allow to search for customer name and prescription date to prescription <br>
		</td>
	</tr>
	<tr>
		<td>
		Reporting: <br>
		- The system should allow Audiologist to export data in various formats (e.g., PDF, Excel). 
		</td>
		<td>
		1. Export customer in excel and pdf<br>
		2. Export prescription in excel and pdf
		</td>
	</tr>
	 <tr>
		<td>
		    Azure DevOps Pipeline
		</td>
		<td>
		1. Generate an Azure DevOps YAML pipeline that: build a .NET Application, deploys it in Azure App Service
		</td>
	</tr>
</table>

# Solution
An example of solution implemented following the Hackathon instructions can be found in "/solution" folder of this repo. 