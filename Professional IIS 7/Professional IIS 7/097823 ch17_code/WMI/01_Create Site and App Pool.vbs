Option Explicit
Dim oIIS, oBinding, oApp
Dim siteName, physicalPath, bindings
siteName = "Site1"
physicalPath = "c:\inetpub\wwwroot"
bindings = ":80:Site1.DomainA.local"

' Set oIIS to the WebAdministration class
Set oIIS = GetObject("winmgmts:root\WebAdministration")

' Create application pool
oIIS.Get("ApplicationPool").Create(siteName)

'Create the binding for the site
Set oBinding = oIIS.Get("BindingElement").SpawnInstance_
oBinding.BindingInformation = bindings
oBinding.Protocol = "http"

' Create the site
oIIS.Get("Site").Create siteName, array(oBinding), physicalPath

' Get the application that was created
Set oApp = oIIS.Get("Application.SiteName='" & siteName & "',Path='/'")
' Assign the new app pool to the application
oApp.ApplicationPool = siteName
' Commit the changes
oApp.Put_

' Write out a message
WScript.Echo "Site " & siteName & " has been created."
