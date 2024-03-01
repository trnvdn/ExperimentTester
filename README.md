# A/B Testing API with Statistical Analysis

This project is designed to facilitate A/B testing through a simple REST API, consisting of two endpoints, and provides statistical analysis of the experiments conducted. The API is built using .NET technologies and utilizes MS SQL database for storing experiment information and results.

# Features
REST API: Provides two endpoints for conducting A/B tests. <br>

Statistical Analysis: Generates statistics for experiments including the total number of devices participating and their distribution among options. <br>

MS SQL Database: Utilizes a Microsoft SQL Server database for storing experiment data. <br>

CRUD Operations: Implements direct queries or stored procedures for CRUD operations with the database.

# Endpoints
/experiment/multiple/{xName}/{count} <br>
Type: GET <br>
Parameters: "xName" - experiment name, count - amount of new experiments <br>
Return: {key: "X-name", value: "string"} <br>

/experiment/{xName}/{deviceToken} <br>
Type: GET <br>
Parameters: "xName" - experiment name, "device-token" <br>
Return: list of experiment results ({key: "X-name", value: "string"}) <br>


# Database Structure
The database consists of the following tables: <br>

Experiments:

ExperimentID (Primary Key)<br>
Key<br>
Value <br>
DistributionPercentage<br>

Participants:<br>

DeviceID (Primary Key)<br>
DeviceToken<br>

ExperimentParticipantAssociations:<br>

AssociationID (Primary key) <br>
ExperimentID (Foreign key to Experiment table) <br>
ParticipantID (Foreign key to Participant table) <br>

# Setup
Clone the repository from GitHub: https://github.com/trnvdn/ExperimentTester
Open the solution in Visual Studio.<br>
Configure the database connection string in the appsettings.json file.<br>
Run the migrations : Update-Database<br>
Build and run the application.<br>

# Usage
Access the Postman to interact with the API endpoints.<br>
Perform A/B tests by making GET requests to the ExperimentsController endpoint with the appropriate device token.<br>
Get the statistics by going to the appropriate page that gets the data in the StatisticsController.<br>
