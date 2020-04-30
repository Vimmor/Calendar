# Calendar
Project for an university course about .Net Framework.
The goal was to create a program to create own Calendar with data saved in database.
The other small task was to make connection between calendar and external Weather Forecast Api.
Application provides a User Interface, that was created with Windows Presentation Foundation.

## Funcionality 
- Create events with parametres location, title, startdate and description
- Push data to the MSSQLServer LocalDB inbuild in Visual Studio
- Display all events or filtred by dates
- Download weather forecast data from Api and display in appropriate format

## Endpoints
- http://localhost:1998/Events/{eventDay} - returns list of the events from database filtered by specified date
- http://localhost:1998/Events/allDayBooks - returns all events from database
- http://localhost:1998/Events/{Day} - puts event into database from Body
- http://localhost:1998/Weather/ - returns forecast for default city 
- http://localhost:1998/Weather/{name} - returns forecast for specified city 
- http://localhost:1998/Weather/{zip_code}/{country_code} - returns forecast specified by zip and country codes (it works for a small part of the zip codes from USA)

## Technologies
- ASP.Net Core
- Windows Presentation Foundation
- Microsoft Entity Framework Core
- NUnit Framework
- Newtonsoft.Json
