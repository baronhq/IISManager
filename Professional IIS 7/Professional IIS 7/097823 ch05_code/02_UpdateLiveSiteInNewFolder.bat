# Copy WebSite1 into a new folder and point IIS to the new folder


echo off

Set /P Src=[old folder date]
Set /P Dest=[new folder date]

xcopy c:\inetpub\wwwroot\WebSite1\%src% c:\inetpub\wwwroot\WebSite1\%dest% /c /e /i /o /y

AppCmd.exe set vdir WebSite1/ -physicalpath:"c:\inetpub\wwwroot\WebSite1\%dest%"
