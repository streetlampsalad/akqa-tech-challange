# AKQA Tech Challange
I consider this a VERY basic implementation to this challenge, I approached it like a prototype/proof of concept (PoC) where I wanted to limit myself to about 3 hours and try and get a functioning web app that fulfilled the requirements. 

If I were to continue working on this app and extending its functionality I would definitely change a few things to make it more production ready.

### Tech

The number converter a few open source projects to work properly:

* [Twitter Bootstrap] - great UI boilerplate for modern web apps
* [jQuery] - JS framework
* [MSTest] - Unit testing framework
* [Web API 2] - .Net web API framework
* [Newtonsoft.Json] - .Net JSON serializer/deserializer

Some technologies I would use if I were to make this a production ready app.

* [Dependency Injection] - To make it easier to referance the different services
* [nUnit] - I felt MSTest was fine for this PoC but I would want to switch to nUnit for better exception handling tests
* [Moq] - Just so I can mock the DI interfaces and also mock requests for better API testing
* [MVM Framework] - I chose not to implement an MVM framework just out of time requirements but I would definitely implement one if I was to keep building on this app (probably angularJS) 
* [Webpack/Gulp] - Just so I can use sass for the stlying and also implement a build watcher
* [Mongo DB/Data store] - I would move all the names of the numbers into a data store so their is a more common location to access all the strings and also enable the ability to add support for multiple languages
* [Security] - Protect the API call with a client_id and client_secret which could be encrypted into a cookie on the users browser


### Installation

1. Make sure akqa-tech-challange.Web is set to the start up project
2. Build the solution so NuGet can download the required packages
3. Press F5 and run the project using visual studios debugger and IIS Express
