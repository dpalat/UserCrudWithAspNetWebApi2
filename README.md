
<p align="center">
  <img src="https://github.com/dpalat/UserCrudWithAspNetWebApi2/blob/Feature-01/Documentation/logo_transparent.png" width="460px" />
</p>


# User Crud

UserCrudWithAspNetWebApi2 is a project to show an example for a simple User [CRUD](https://es.wikipedia.org/wiki/CRUD) with Asp.Net Web API 2
In this proyect you can see how to connect a ASP.NET MVC 5 with ASP.NET WebAPI2 with Basic Authentication all in .NET Framework (Full Framework).


## How to use it?

1. Clone Repo

2. Open ```.sln``` File in the ```src``` folder  with Visual Studio 2017 or highter

3. Clean and Rebuild all Solution.

3. You must to set the "Multiple startup projects" to start WebUI and WebApi both at the same time.

<img src="https://github.com/dpalat/UserCrudWithAspNetWebApi2/blob/Feature-01/Documentation/multiplestart.png" width="600px" />


## Stack

- Visual Studio 2019
- ASP.NET MVC 5
- ASP.NET WebApi 2
- .NET Framework 4.7
- CodeMaid (Visual Studio pluging) (http://www.codemaid.net/) 
- OpenCove + ReportGenerator.
- System.HTTP Default Content Negotiation
- Moq (https://github.com/moq/moq)
- C# 
- Native SHA256 for Hashpassword.
- Autofac for IoC & DI.
- Automapper
- Swagger
- ASP.NET Identity (manage roles and users)
- Insomnia REST Client (https://www.insomnia.rest/)

Others tool:
- Hatchful (https://hatchful.shopify.com/)
- ScreenToGif (https://www.screentogif.com/)
- Trello (https://trello.com/)


## Default user

There are default users:

- admin@user.com (password: 1234)
- 1@user.com (password: 1234)
	- Role: PAGE_1
- 2@user.com (password: 1234)
	- Role: PAGE_2
- 3@user.com (password: 1234)
	- Role: PAGE_3

## Roles

In User Crud exist tree roles:

- PAGE_1 => Only allow access to Page 1.
- PAGE_2 => Only allow access to Page 2.
- PAGE_2 => Only allow access to Page 3.

And one super admin Role:
- ADMIN => Allow access to everything.

## Admin view

> Admin user can access to User Directory View and Edit or Delete any user.
<img src="https://github.com/dpalat/UserCrudWithAspNetWebApi2/blob/Feature-01/Documentation/Admin_detail_0.gif" width="600px" />

> Admin user have only ADMIN role and with this Role can access to all pages ,Page 1, Page 2, Page 3 and User directory.
<img src="https://github.com/dpalat/UserCrudWithAspNetWebApi2/blob/Feature-01/Documentation/Admin_detail_1.gif" width="600px" />

> There is a LogOut button to force log off and if you try to access with the direct URL without previous login you can see a page for introduce your credentials.
<img src="https://github.com/dpalat/UserCrudWithAspNetWebApi2/blob/Feature-01/Documentation/Admin_detail_2.gif" width="600px" />


## User with common role view

> User 1@user.com (1234) can login and only can access to Page 1. The others pages show a Forbidden message.
<img src="https://github.com/dpalat/UserCrudWithAspNetWebApi2/blob/Feature-01/Documentation/User_detail.gif" width="600px" />


## User with common role view

> The api User is allow only a User with ADMIN Role.
<img src="https://github.com/dpalat/UserCrudWithAspNetWebApi2/blob/Feature-01/Documentation/api_admin.gif" width="600px" />

> The api implent a content negotiatorn in the User [GET] and you can ask for XML response.
<img src="https://github.com/dpalat/UserCrudWithAspNetWebApi2/blob/Feature-01/Documentation/api_xml.gif" width="600px" />

> The api implent a content negotiatorn in the User [GET] and you can ask for Json response.
<img src="https://github.com/dpalat/UserCrudWithAspNetWebApi2/blob/Feature-01/Documentation/api_json.gif" width="600px" />

> The api implent a content negotiatorn in the User [GET] and you use Quality Factor.
<img src="https://github.com/dpalat/UserCrudWithAspNetWebApi2/blob/Feature-01/Documentation/api_quality_factor.gif" width="600px" />


## Coverage

> Now are 100% Coverage in the layer wicht not are WebApi and WebUI.
<img src="https://github.com/dpalat/UserCrudWithAspNetWebApi2/blob/Feature-01/Documentation/Coverage.png" width="600px" />

Visual Studio don't include native tool for view the Code Coverage in Community Edition and OpenCover and ReporGenerator is a good alternative. 


You can run coverage executing ```CoverageTest.bat``` file which is in the solution.
<img src="https://github.com/dpalat/UserCrudWithAspNetWebApi2/blob/Feature-01/Documentation/CoverageBat.png" width="400px" />


## Store

This example is build with a In Memory store, which is a simple clases, keep in mind because if you restart the application you will lost your users :).

## License

Licensed under MIT see License file.


# More about me

- https://www.linkedin.com/in/diegopalat/
- https://twitter.com/diegotepalat
- https://about.me/diegopalat
