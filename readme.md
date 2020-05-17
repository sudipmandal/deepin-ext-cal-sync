# Sync External Cloud Calendars with Deepin Calendar

This project is an attempt to sync external Calendars like Google calendar with Deepin OS v20 beta Calendar ([dde-calendar](https://github.com/linuxdeepin/dde-calendar)).
Deepin Linux Calendar currently does not have any ability to add external calendars or accounts.

Program currently works only with google calendar. More calendars will be added in future.

This program may work with other versions of Deepin as well, however it is tested only against v20 beta.

Project is built using .NET Core C# and uses the [Tmds.Dbus](https://github.com/tmds/Tmds.DBus) nuget package to interact from the .NET Core framework to the dbus service.

## How to Install:
A one click installer does not exist yet.

Download the latest zip release (or build from code) and extract to some folder
Edit the config.json file (Change to duration to sync settings if default is not desired)

For Google Calendar, you would need a google developer Client ID and Secret (steps below to generate)

- Go To https://console.developers.google.com/cloud-resource-manager?organizationId=0&authuser=0
- Click Create Project and give a suitable name (eg Deepin-Calendar-Sync) and click create.
- Open the project and click on the upper left menu (Three lines)
- Select APIs & Services
- Click on Enable APIs and Services
- Search for "Calendar"
- Select Google Calendar API and Click Enable.
- From the left menu select API & Services > Credentials
- Click on Create Credentials
- Select oAuth Client ID
- Click on Configure Consent Screen
- Select External
- Click Create
- A form should open
- Fill in the form, put Application name
- Click save
- From Left menu select Credentials
- Click Create Credentials
- Select oAuth Client ID
- Select Application Type as Desktop app
- Put Name of the Desktop App as deepin-ext-cal-sync
- Click save
- A dialog containing Client ID and Secret will open
- Copy the Client ID and Secret
- Paste them in the config.json file under Providers > Google section

Leave the calendarid as primary if you need only your primary google calendar
If you want some other calendar from your google account, replace with that calendar id

To get Calendar ID 
- Go to https://calendar.google.com/calendar/r
- Click on Settings
- Open the desired calendar scroll down and copy the calendar id


Execute deepin-ext-cal-sync program either from terminal or by double clicking.

Currently the program does not run periodically to keep the calendar in sync
use crontab or similar for that functionality.


## Contribute/Build From Source :

### *Pre-requisite* : 

1. *Deepin OS* : https://www.deepin.org/en/

2. *Visual Studio Code*: https://code.visualstudio.com/download

3. *net core framework 3.0* Currently Tmds.DBus requires netcore 3.0 framework.
apt-get install dotnet-runtime-3.0

To regenerate Calendar.DBus.cs file (for newer or older versions of Deepin)
execute the following commands from project folder

`dotnet tool install -g Tmds.Dbus.Tool`

`dotnet dbus codegen --service com.deepin.daemon.Calendar`

### *To build the code*

Download/Clone the Deepin-Ext-Cal-Sync folder from github repo

`dotnet restore`

`dotnet build`
