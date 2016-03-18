# Shopping Helper Application

- **Student Name:** Will Hogan
- **Student Number:** G00318460
- **College Name:** GMIT
- **Course:** Software Development
- **Module:** Windows Mobile Application Development
- **Lecturer:** Damien Costello
- **Current College Year:** 3rd Year 
- **Project Title:** Shopping Helper Application

# Application Overview
I have created a fully functional universal application that is very useful for storing lists of any type of items, ie Groceries and their
associated quantities and prices. Upon launching the app, the user will tap the main 'Shopping Helper' screen and start entering in desired list items. 
I have added some useful extras to the application, such as a count for total items entered and a Total price, so things don't get out of hand at the local shop! 

These extras dynamically change as items are entered and removed from the App. As my app stores all the information locally on each device using
SQLite, then in the event of the Application being interrupted (call) or the phone battery dying, the list is still available when the phone returns to its original state.
A user can remove items individually or in one go as they please, which allows for a convenient clean slate approach the next time the app is launched, especially if there were a large amount of items present in that current shopping session. 

The App is simple to understand and easy to use, with a clear menu at the bottom of the item entry screen, that displays four options:

| *Button Name* | *Function*      |
| ------------- |:-------------:|
| **Show All**    | Retrieves a list of items in the locally stored SQLite database, should any exist |
| **Add**         | Upon entering valid information into each of the textboxes, enters this information into the database |
| **Delete**      | Upon highlighting a specific screen item, removes that item from the Database |
| **Delete All**  | When any item is selected in the grid, Removes all items from the Database |

Note: Only when an item is selected in the item grid, do both ```Delete``` and ```Delete All``` buttons become available as to avoid validation issues.
Also, if a user doesn't enter in the correct values, ie text where a number is required, then the user is informed on screen and asked to re-enter valid data. 


### Compatibility
Because i created this as a Universal Application within Visual Studio 2015, it should download from the store and work on a number of different devices without any issues. I myself have personally tested as both a Desktop application and Mobile Phone (Nokia Lumia 520) application without any problem. 

### Language availability
I have made this application available in both English and German and once the user has set or changed their home language between either of these, then my application will respond by switching the language accordingly.

### Store Information
My Application has been fully certified and approved by Microsoft and can be found on the 
Windows store at this [link](https://www.microsoft.com/store/apps/9NBLGGH4R2V5), enjoy. 

---

# Technical Information
The Application was created using Visual Studio 2015. I chose a Universal App for this project to facilitate cross device deployment.

### Project Code / Pattern Structure
This project structure adheres to a Model View Controller paradigm, which consists of three programming languages.   

- C# - Which i used as the Controller, i also used a Bean Class with consists of only Getters and Setters
- XAML - The visual display or View
- SQLite - The data Model itself

I decided to use SQLite instead of general local storage settings to store information for a number of reasons, primarily i found it very reliable and from
my own perspective a bit easier to understand and implement. I also opted to avoid connecting remotely to a separate server, mainly because it simply wouldn't make sense with a project of this type. 

Note: Learning how SQLite works and how it's implemented was beyond the scope of my current college module, 
However i felt it would be extremely useful to have in my project. 

### Comments
Throughout this project i have provided in depth commenting for each page/Function that clearly and concisely explain what exactly
is happening with my code. For tidiness i have opted for multi-line commenting just before each Function detail

### Localisation / Globalisation
I have extracted all hard coded text and placed in separate resource files within the project solution folder, so at runtime the text is pulled 
from said files and rendered on the App display. 

For the Globalisation part of my application, i have German translations in another separate folder which enables my App to launch in German at Runtime

### GitHub
Throughout this projects development, I used the GitHub Plugin for VS 2015, which i found extremely useful for maintaining version control. 
Each time i made a commit i pushed to GitHub as to avoid any issues with backlogs in the event of any Technical issues that may have occurred, 
preventing me from doing a bulk Push for all commits at the end. 

### SQLite local installation instructions
To be able to run this application through Visual Studio 2015, you will need to install SQLite. 
Please follow these steps:

- Go to this site [https://www.sqlite.org/download.html](https://www.sqlite.org/download.html)
- Download the latest version of SQLite for ```Universal Windows Platform```
- Open up Visual Studio
- There should be a Reference to SQLite in the References Folder of your Solution Explorer, if so skip the next few steps and continue from 'Go to Tools'
- Right click on the ```References``` folder of your ```Solution Explorer``` and click ```Add Reference```
- On the pop up window, go to the Universal Windows section on the left and click ```Extensions``` 
- Tick the ```SQLite for Universal App platform``` box, then OK
- Go to tools => NuGet package manager => Package Manager Console
- In the package manager console, type the following ```Install-Package SQLite.Net-PCL```
- At this point you should be informed in screen that the package was successfully installed

If you are planning on building something similar using SQLite, you will need something to visualise the backend. 
My choice was a SQLite IDE called ```sqlitebrowser```, which will help you monitor and test values as they are being inserted and deleted. 
[Here](http://sqlitebrowser.org/) is the link to their site

### Instructions for Visual Studio 2015 deployment
- Download the zip file and unbundle to a folder of your choosing.
- Open using Visual Studio 2015. 
- Follow the steps to install SQLite as outlined in previous header. 
- Run.
