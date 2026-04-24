# Forum app

## A web application that mimics a small forum, focusing on user interaction and data ownership.

## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Features](#features)
* [Setup](#setup)

## General info
This project is simple forum app that allows the user to create topics and posts to communicate with each other. 
The main asset is that only the owner of a given item (topic or post) can manage it (edit or delete).

## Technologies
* **Architecture:** MVC (Model-View-Controller)
* **Backend:** .NET 8, C#, Entity Framework Core
* **Frontend:** Razor views
* **Database:** SQL Server

## Features
* **Authentication:** Only logged-in users can create new topics and posts. Guests are restricted to view-only mode.
* **Ownership-based Access Control:** Only the original author can edit or delete their own content.
* **Dynamic Content Statistics:** Real-time reply count for each topic.

## Setup
To run this project locally, follow these steps:

1. **Clone the repository:**
   ```bash
   git clone https://github.com/Navytree/ForumAppMVC.git

2. **Update Database Connection:**
Open appsettings.json and update the DefaultConnection string to point to your local SQL Server instance.

3. **Apply Migrations:**
Run the following command in the Package Manager Console (Visual Studio) or Terminal to create the database:
   ```bash
    dotnet ef database update
   
4. **Run the application:**
  Press F5 in Visual Studio 2022 or use the command:
     ```bash
     dotnet run

