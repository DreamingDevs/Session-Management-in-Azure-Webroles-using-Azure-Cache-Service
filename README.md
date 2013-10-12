Session Management in AzureWebsites using Azure Cache Service
-----------

Traditional ASP.Net developers can't imagine their life without the usage of Session State (either - InProc or State Server
or SqlServer or Custom modes). Devs use this powerfull api not only to persist sensitive information on server, but also
to tranfer data objects between across postbacks.

Problems with session management arises when one go on to Webfarm (or typically multiple instances of web server), where
a typical load balancer comes in between the client and server farm. When a ClientA makes a first request, which is being
routed to ServerA, then ServerA creates a session object. But what if simultaneous requests from ClientA goes to ServerB?
As Session object in ServerA, there will be Null Object reference exception getting thrown.

This problem can be solved by using Sticky sessions at Load Balancer level, which makes sure that all requests from ClientA
will be routed to ONLY ServerA. Thereby preventing Null Object reference exceptions and giving us Data/Identity integrity.
In my opinion this is a kind of bottlenect for scalable architecture (for which most of us approach cloud infrastructure).

The main aim of this project is to provide a working scalable solution for session management in Windows Azure AzureWebsites
using distributed Azure Cache Service.

Please follow below description of the project - 

1. We create a Azure Cache Service in Azure Management Portal. Then we install Azure Cache nuget on the solution.
2. Next we create TWO Pages - Home and Detail.
3. On Home page we have a TextBox to enter the name of the person visiting our site. Then we store the same name in the 
Session object.
4. We use the same session object on the Details page to display in HTML.
5. On next consecutive requests to Details Page, user name is retrieved from Session object and will be displayer (until
Session expiry).
6. On Details page we also have Remove button, through which we can abandon the same session.

Specialties:
-------------
1. There is no need for us to touch Load Balancer. So this gives us enough sacalability scope.
2. Azure Cache is going to be on Hihn availability defined on it and it is distributed. We get more better control on 
expiry, eviction, High availability, notifications and size.


Technical Stack:
---------------
> 1. AzureWebsites
> 2. Azure Cache Service
> 4. ASP.Net MVC4 Web Application

Important Notes:
-------------
1. Azure configuration settings are havinf placeholders. Please replace config information with your own settings to make this solution work.
	* Have a proper AzureWebsites Publish Profile credentials to deploy this solution.
	* Update Web.Config with Azure Cache specific credentials.

TODO Tasks:
-----------
> 1. Unit test WebApi endpoints.

Test Run:
----------
Home page
![Test Iteration1](https://raw.github.com/DreamingDevs/large-file-upload-to-azure-blob-using-webapi/master/Images/tTest-Iteration1.png "Test 
Iteration1")

Details Page 
![Test Iteration2](https://raw.github.com/DreamingDevs/large-file-upload-to-azure-blob-using-webapi/master/Images/tTest-Iteration2.png "Test 
Iteration2")

Credits:
-----------
> 1. Mohan (Code Contributor). Also do not forget to see contributors section. It is all their hardwork.
> 3. MSDN Documentation.

Disclaimer:
-----------
All ideas and implementations made in this project are out of my own self thought process. Credits are given to
respective people, who directly or indirectly helped me in understanding the concepts of latest technologies.
It is also to be remembered that views/suggestions/practices involved in this project are strictly of my own 
representations. Present project/code/[Any thing to that matter which is from DreamingDevs] doesn't relate to my 
present/past employers in any way. Present project may suit some of the real world demands and also may not, 
it’s purely the responsibility of the person who intended to use any of the material placed in this project work.
