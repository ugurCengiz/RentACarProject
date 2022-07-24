# ReCapProject (Rent A Car Back-end)
## Introduction
While developing this project, I learned new techniques and patterns and I developed myself very well. If you need detailed information, you can contact me.

## Technologies Used
- .NET
- ASP.NET for Restful api
- EntityFramework Core
- Autofac
- FluentValidation
- MsSql
## Techniques
- Layered Architecture Design Pattern
- OOP
- AOP
- JWT
- Autofac dependency resolver
- IOC
FluentValidation
- If you want to check content of entity when add, update etc. operations you can create validation for related entity.

## Aspects
- ValidationAspect
- CacheAspect
- CacheRemoveAspect
- PerformanceAspect
- SecuredOperationAspect
- TransactionAsepct
You can understand better if you examine the classes in the concrete folder in the business layer.
## Database objects
- Brand
- Car
- CarImage
- Color
- Customer
- CreditCard
- Rental
- OperationClaim(In the core layer)
- UserOperationClaim(In the core layer)
- User(In the core layer)
## Nuget Packages and Their Versions
- Autofac - Version = v6.4.0
- Autofac.Extensions.DependencyInjection - Version = v8.0.0
- Autofac.Extras.DynamicProxy - Version = v6.0.1
- FluentValidation - Version = v11.0.3
- Microsoft.AspNetCore.Authentication.JwtBearer - Version = v5.0.17
- Microsoft.AspNetCore.Http - Version = v2.2.2
- Microsoft.AspNetCore.Http.Abstractions - Version = v2.2.0
- Microsoft.AspNetCore.Http.Features - Version = v5.0.17
- Microsoft.EntityFrameworkCore.SqlServer - Version = v5.0.17
- Microsoft.IdentityModel.Tokens - Version = v6.19.0
- Newtonsoft.Json - Version = v13.0.1
- System.IdentityModel.Tokens.Jwt - Version = v6.19.0
