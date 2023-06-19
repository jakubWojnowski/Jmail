# Jmail
# Description
Jmail is a mail communication application created with ASP.NET Core MVC. The application provides an interface for sending messages and a mailbox screen where received messages can be viewed. Jmail also includes an admin role, which has access to messages between users within the application and can delete accounts.

The application is built using Clean Architecture, divided into four layers: presentation, application, domain, and infrastructure. All of this is implemented using Mediator CQRS, making the application scalable and easy to maintain.

# Technologies
The project is implemented using the following technologies:

ASP.NET Core MVC
Docker
Entity Framework
ASP.NET Core Identity
Mediator CQRS
Clean Architecture

# Requirements
To run this project, you need Docker installed.

# Installation
To run this project, follow these steps:

Clone the repository to your local computer:
git clone https://github.com/jakubWojnowski/Jmail.git
Navigate to the project folder:
cd Jmail
Run the Docker command:
docker-compose up -d
Update the database:
Update-Database
Registration and login
In order to use the application functions, you first need to register. You can do this by clicking the registration button in the top right corner of the page. Registration and login are implemented using ASP.NET Core Identity.

# Usage
After installation, launch, and registration, the application enables sending and receiving messages between users. As an administrator, you also have access to messages between users within the application and can delete accounts.

# Future updates
Additional features and improvements are planned. Details will be provided soon.

# Support
If you encounter any problems during installation or usage of the application, create an issue in the Issues section on GitHub.

