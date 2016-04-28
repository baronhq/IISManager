# This cmd uses For to add web sites 4 through 50 

for /l %1 IN (4,1,50) do mkdir c:\inetpub\wwwroot\website%1 | c:\windows\system32\inetsrv\appcmd.exe add site /name:www.website%1.com /id:%1 /bindings:http://www.website%1.com:80 /physicalpath:c:\inetpub\wwwroot\website%1