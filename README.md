# UserCrudWithAspNetWebApi2

<img src="https://github.com/dpalat/UserCrudWithAspNetWebApi2/blob/Feature-01/Documentation/logo_transparent.png" width="150px" />

# User Crud

UserCrudWithAspNetWebApi2 is a project to show an example for a simple User CRUD with Asp.Net Web API 2
In this proyect you can see how to connect a ASP.NET MVC 5 with ASP.NET WebAPI2 with Basic Authentication all in .NET Framework (Full Framework).




## How to use it?

1. Clone Repo

2. Open .Sln File in the ```src``` folder  with Visual Studio 2017 or highter

3. You must to set the "Multiple startup projects" to start WebUI and WebApi both at the same time.

<img src="https://github.com/dpalat/UserCrudWithAspNetWebApi2/blob/Feature-01/Documentation/multiplestart.png" width="400px" />

https://www.nuget.org/packages/Xamarin.Forms.PancakeView

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
In User Crud exist tree roles

- PAGE_1 => Only allow access to Page 1.
- PAGE_2 => Only allow access to Page 2.
- PAGE_2 => Only allow access to Page 3.

And one super admin Role:
- ADMIN => Allow access to everything.

## Admin view

> Detail 1
<img src="https://github.com/dpalat/UserCrudWithAspNetWebApi2/blob/Feature-01/Documentation/Admin_detail_0.gif" width="400px" />

> Detail 2
<img src="https://github.com/dpalat/UserCrudWithAspNetWebApi2/blob/Feature-01/Documentation/Admin_detail_1.gif" width="400px" />

> Detail 3
<img src="https://github.com/dpalat/UserCrudWithAspNetWebApi2/blob/Feature-01/Documentation/Admin_detail_2.gif" width="400px" />

> Detail 4
<img src="https://github.com/dpalat/UserCrudWithAspNetWebApi2/blob/Feature-01/Documentation/Admin_detail_0.gif" width="400px" />


## User with common role view

> User 1@user.com (1234) login and only can access to Page 1. The others pages show an Fordbideen message.
<img src="https://github.com/dpalat/UserCrudWithAspNetWebApi2/blob/Feature-01/Documentation/User_detail.gif" width="400px" />


## User with common role view

> The api User is allow only a User with ADMIN Role.
<img src="https://github.com/dpalat/UserCrudWithAspNetWebApi2/blob/Feature-01/Documentation/api_admin.gif" width="400px" />

> The api implent a content negotiatorn in the User [GET] and you can ask for XML response.
<img src="https://github.com/dpalat/UserCrudWithAspNetWebApi2/blob/Feature-01/Documentation/api_xml.gif" width="400px" />

> The api implent a content negotiatorn in the User [GET] and you can ask for Json response.
<img src="https://github.com/dpalat/UserCrudWithAspNetWebApi2/blob/Feature-01/Documentation/api_json.gif" width="400px" />

> The api implent a content negotiatorn in the User [GET] and you use Quality Factor.
<img src="https://github.com/dpalat/UserCrudWithAspNetWebApi2/blob/Feature-01/Documentation/api_quality_factor.gif" width="400px" />


## Coverage
> Now are 100% Coverage in the layer wicht not are WebApi and WebUI.
https://github.com/dpalat/UserCrudWithAspNetWebApi2/blob/Feature-01/Documentation/Coverage.png

Visual Studio don't include native tool for view the Code Coverage in Community Edition and  OpenCover and ReporGenerator is a good alternative. 


## Store

This example is build with a In Memory store, witch is a simple clases, keep in mind because if you restart the application you will lost your users :).



