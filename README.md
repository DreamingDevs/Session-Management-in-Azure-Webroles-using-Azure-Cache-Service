Session Management in Azure WebRoles using Azure Cache Service
-----------

Traditional ASP.Net developers can't imagine their life without the usage of Session Object (either - InProc or State Server
or SQL Server or Custom modes). Devs use this powerful API not only to persist sensitive information on server for some
time intervals, but also to transfer data objects across postbacks between different pages.

Problems with session management arises when we go on to the Webfarm (or typically multiple instances of web server), especially where
a typical load balancer comes in between the client and server farm. When a ClientA makes a first request, which is being
routed to ServerA, then ServerA creates a session object. But what if simultaneous requests from ClientA goes to ServerB?
As Session object is in ServerA, there will be Null Object reference exception getting thrown.

This problem can be solved by using Sticky sessions at Load Balancer level, which makes sure that all requests from ClientA
will be routed to ONLY ServerA. Thereby preventing Null Object reference exceptions and giving us Data/Identity integrity.
In my opinion this is a kind of bottleneck for scalable architecture (for which most of us approach cloud infrastructure).

The main aim of this project is to provide a working scalable solution for session management in Windows Azure WebRoles
using distributed Azure Cache Service.

Please follow below description of the project - 

1. We create a Azure Cache Service in Azure Management Portal. Then we install Azure Cache nuget on the solution.
2. As a next step, enable Custom Session Provider based on Azure Cache Service in Web.Config file.
2. Next we create TWO Pages - Home and Detail.
3. On Home page we have a TextBox to enter the name of the person visiting our site. Then we store the same name in the 
Session object.
4. We use the same session object on the Details page to display in HTML.
5. On next consecutive requests to Details Page, user name is retrieved from Session object and will be displayer (until
Session expiry).

Specialties:
-------------
1. There is no need for us to program Load Balancer. So this gives us enough scalability scope.
2. Azure Cache is going to be on High availability setting defined on it and it is distributed. We get more better control on 
expiry, eviction, High availability, notifications and size.
3. For demo purpose, we displayed the ID of the role instance which is serving the response. So that we can clearly differentiate
that our Azure Cache is being utilized for persisting Session.


Technical Stack:
---------------
> 1. Azure WebRole
> 2. Azure Cache Service
> 4. ASP.Net MVC4 Web Application

Important Notes:
-------------
1. Azure configuration settings are having placeholders. Please replace config information with your own settings to make this solution work.
	* Have a proper Azure WebRole Publish credentials to deploy this solution.
	* Update Web.Config with Azure Cache specific credentials.

TODO Tasks:
-----------
> 1. Unit test WebApi endpoints.

Test Run:
----------
**Home page**  
![Home](https://raw.github.com/DreamingDevs/Session-Management-in-Azure-Webroles-using-Azure-Cache-Service/master/Images/Home.png "Home")

**Details Page**  
![Details](https://raw.github.com/DreamingDevs/Session-Management-in-Azure-Webroles-using-Azure-Cache-Service/master/Images/Details.png "Details")

**Details Page on Simultaneous Requests**  
![Details Simultaneous Requests](https://raw.github.com/DreamingDevs/Session-Management-in-Azure-Webroles-using-Azure-Cache-Service/master/Images/Details_Simultaneous.png "Details Simultaneous Request")

Credits:
-----------
> 1. Mohan (Code Contributor). Also do not forget to see contributors section. It is all their hard work.
> 3. MSDN Documentation.

Disclaimer:
-----------
All ideas and implementations made in this project are out of my own self thought process. Credits are given to
respective people, who directly or indirectly helped me in understanding the concepts of latest technologies.
It is also to be remembered that views/suggestions/practices involved in this project are strictly of my own 
representations. Present project/code/[Any thing to that matter which is from DreamingDevs] doesn't relate to my 
present/past employers in any way. Present project may suit some of the real world demands and also may not, 
it’s purely the responsibility of the person who intended to use any of the material placed in this project work.
