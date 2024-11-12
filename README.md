Minimal ASP.NET Web API with JWT Authentication
This project demonstrates how to create a minimal ASP.NET Web API with JWT (JSON Web Token) authentication, providing a secure way to authenticate and authorize API requests.

Overview
This API is built with ASP.NET Core and uses JWT for authentication. The JWT tokens are generated and validated to control access to secure endpoints.

Features
JWT token generation and validation
Secured endpoints using [Authorize] attribute
Simple GET endpoint to test authenticated access

Getting Started
-Prerequisites
-.NET 6 SDK
-A code editor like Visual Studio or Rider

Setup Instructions
Clone this repository:
git clone https://github.com/your-username/minimal-aspnet-jwt-authentication.git
cd minimal-aspnet-jwt-authentication

Install Dependencies:

Make sure you have the following NuGet package:
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer


Project Structure
Controllers: Contains the API controllers for handling requests.
Other Services: Contains helper classes for generating and validating JWT tokens.
