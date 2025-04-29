# Movie Recommendation System

To be implemented:  
A web application for managing movies, user reviews, and ratings.  
Users can add new movies, write reviews, and rate movies.  
Based on user preferences and ratings, the system provides personalized movie recommendations.  

----------------------------------------------------  

## Tools and Technologies
C#  
ASP.NET Core MVC  
ASP.NET Core Web API    
Entity Framework Core  
PostgreSQL  

## Setup  

### Dependencies
WebApp:  
Microsoft.VisualStudio.Web.CodeGeneration.Design  
Microsoft.EntityFrameworkCore.SqlServer  

To WebApp and DAL:  
Npgsql.EntityFrameworkCore.PostgreSQL  
Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore  
Microsoft.AspNetCore.Identity.EntityFrameworkCore  

### Database migration
dotnet ef migrations add --project DAL --startup-project WebApp --context AppDbContext InitialCreate  
dotnet ef database   --project DAL --startup-project WebApp drop  
dotnet ef database   --project DAL --startup-project WebApp update  

### Identity Razor Pages Generation
cd WebApp  
dotnet aspnet-codegenerator identity -dc DAL.AppDbContext -f  

### MVC controllers Generation 
cd WebApp  
dotnet aspnet-codegenerator controller -name CastAndCrewsController        -actions -m  Domain.Entities.CastAndCrew        -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f  
dotnet aspnet-codegenerator controller -name CountriesController        -actions -m  Domain.Entities.Country        -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f  
dotnet aspnet-codegenerator controller -name GenresController        -actions -m  Domain.Entities.Genre        -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f  
dotnet aspnet-codegenerator controller -name MoviesController        -actions -m  Domain.Entities.Movie        -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f  
dotnet aspnet-codegenerator controller -name RatingsController        -actions -m  Domain.Entities.Rating        -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f  
dotnet aspnet-codegenerator controller -name RatingValuesController        -actions -m  Domain.Entities.RatingValue        -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f  
dotnet aspnet-codegenerator controller -name ReviewsController        -actions -m  Domain.Entities.Review        -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f  

