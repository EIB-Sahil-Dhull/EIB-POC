GDPR Project Documentation

Table of Contents:
•	Introduction
•	Technologies Used
•	Getting Started
•	API Endpoints
•	Frontend Overview (Angular)
•	State Management (Angular Redux)
•	Database (MongoDB)
•	Running the Application
•	Conclusion

Introduction
Welcome to the GDPR Project documentation. This project is designed to handle user management under the GDPR regulations, ensuring data privacy and protection. It provides endpoints to create and retrieve users, with the frontend built using Angular (standalone) and the backend utilizing .NET Core Web Api’s with MongoDB as the database. Angular Redux is used to manage application state in the frontend.

Technologies Used
Backend
.NET Core 8.0: The latest version of the cross-platform framework for building modern cloud-based applications. It offers enhanced performance and security features, making it a robust choice for GDPR-compliant applications. The project also utilizes the Repository Pattern with Generic Functions to handle data access in a clean and reusable manner, making it easier to maintain and extend.
Frontend
Node.js: Version 20.18.0 is used in this project for JavaScript runtime, enabling efficient management of the development process.
Angular (Standalone): Angular 18 is set up as a standalone project for the frontend, offering a modular, scalable architecture for building dynamic SPAs (Single-Page Applications).
Angular Redux: Manages the global state of the Angular application, ensuring smooth and predictable state transitions across different components.
Database
MongoDB: A NoSQL database used to store user data efficiently.
MongoDB Compass: A GUI tool for MongoDB to manage and visualize data in the database, making database administration more user-friendly.

Requirements
To run this project, you will need the following tools installed on your machine:
1.	.NET Core 8.0 SDK: For running the backend API.
2.	Node.js 20.18.0: For managing the Angular frontend project.
3.	MongoDB: To store user data.
4.	MongoDB Compass: For interacting with MongoDB in a graphical interface.
5.	Angular CLI: Used for managing and serving the Angular project.
6.	Angular Redux for managing application state.
Getting Started
Running the Application
Backend:-
•	cd gdprWebApi
•	cd gdprApp
•	dotnet run
Frontend:
•	cd gdpr-frontend
  Setting Up Angular CLI:	
•	npm install -g @angular/cli
•	ng serve
Database:
•	Ensure MongoDB is running on your system.
•	By default, it will connect to mongodb://localhost:27017/GdprAppDatabase.

API Endpoints
Base URL: http://localhost:5081
1-Create User
•	Endpoint: /api/users
•	Method: POST
•	Description: This endpoint is used to create a new user in the system
 
2-Get All Users
Endpoint: /api/users
Method: GET
Description: This endpoint retrieves all users stored in the system.

Frontend Overview (Angular)
Angular 18 (Standalone) Overview
The frontend of the GDPR project is built as a standalone Angular application. It uses the Angular CLI for development and building, and Angular Redux to manage state. This ensures efficient data management and predictable state transitions across components.
State Management with Angular Redux
Angular Redux is used to manage the global state of the application. It allows the user data and other application state to be maintained centrally, ensuring that components can easily access or modify the data they need without manual prop drilling.

Components:
User Form Component: This component handles user creation.
HTML: Contains a form for user input.
TypeScript: Manages the form submission to the /api/users/create endpoint.
User List Component: This component displays a list of all users.
HTML: Uses an Angular table to list users.
TypeScript: Fetches user data from the /api/users endpoint.
Styling:
CSS/SCSS: Provides the styling for components, ensuring the UI is sleek and responsive.

Database (MongoDB)
MongoDB is used for storing user data in this project. Each user document contains:
id: The unique identifier for each user (auto-generated by MongoDB).
First name: The First name of the user.
Last name: The Last name of the user.
Address: The Address of the user.
email: The email address of the user (must be unique).
dateOfBirth: The user's date of birth.
Phone Number: The user’s Phone Number

MongoDB Compass
We use MongoDB Compass to interact with the database. This GUI tool simplifies database management tasks like querying, indexing, and managing collections.

Conclusion
The GDPR project leverages the latest tools and frameworks, including .NET Core 8.0, Angular (Standalone) with Redux, and MongoDB to provide an efficient and scalable solution for managing user data while adhering to GDPR guidelines. With MongoDB Compass for database management, the project is built with both development efficiency and user data security in mind.

For further assistance or contributions, feel free to check the repository link.
