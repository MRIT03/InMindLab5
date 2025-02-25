# Hello Andrea !

# Database 

To solve the given tasks I implemented the following database. The design allowed me to perform the needed operations with relatively simple queries, as well as store all the needed data.

![image](https://github.com/user-attachments/assets/f021573f-24b9-4e41-a533-e73bfa77a7ba)

The database was first codded as entities in dotnet, and it was later translated into PostgreSql through the entity framework. To do so, the entities were declared in the Entities folder as part of the Domain section.

In the Persistence layer, I installed the Entity Framework and declared it as a dependency, then I defined the DBContext as UmcContext. 

Finally, to allow the movement of objects between the Persistence layer and other layers I used the Repository pattern. 

I discovered the Repository pattern as I was reseatching mediatR through its documentation. After researching the pattern itself, I decided to try and implement it in my project. 

The pattern allows me to define what I want to expose from my persistence layer to other layers by defining them in repositories. 
In my code, I declared a repository for each Entity defined in the domain layer. By doing so, data was moved around between layers using repositories instead of injecting the dbcontext everywhere.

Although my code did not create a fully correct application of the pattern, the goal was to simply try and implement the pattern and work with it in the simplest way possible.

# Application Layer

I started the application layer by creating the view models and the mappers. The goal was to turn data taken from the domain layer and the persistence layer and expose them to the API layer. 

The view models were straightforward, they were just the original entities with sometimes fewer properties or renamed properties. While automapper could have been used to map between the entities and their respective DTOs, I decided to keep it simple and use my own custom mappers.

Finally, for mediatR integration, I used the command and queries directories. I used the commands to perfrom the wanted operations, and the queries to perform entity retrieval. 

The commands and queries are simple as they leveraged the pre existing repositories and view models to perfrom data transfer and CRUD operations. 

# Redis Caching

Caching through Redis was also done in the persistence layer and through the repositories. Initially, caching was done for students, courses, and teachers for their GetAll() command. 
However, later on as I was working on setting the grade and grade point average for a student, I run into the issue where the data was being read from and written to the cache instead of the actual database, particularly for the Students table.
Fixing this would require a write policy between the cache and the database, and due to the time constraint of the project, I had to refrain from implementing that. 

# API Versioning and ODATA

Api versioning was done through the API layer using the ASP.Versioning.MVC/ODATA. Intially I was going to use the Microsoft.AspNet.MVC.Versioning library, however that library has been deperecated. 
Through the ASP.Versioning documentation and stackoverflow I was able to get the feature working in my application.

To test it, I set up 2 controllers. One controller for the regular routes that follows version 1 of the api. The second controller that uses ODATA follows version 2 of the api. 
After testing this feature with postman, both versions worked completely.

# File upload 

File upload was done by modifying the database, where the Students table now holds an attribute for the URL of the Student's profile picture. The Profile pictures are all saved on wwwroot/images/ and the attribute would just lead to the specific image in that path.


