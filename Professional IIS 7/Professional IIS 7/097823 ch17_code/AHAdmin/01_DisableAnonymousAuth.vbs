configFile = "MACHINE/WEBROOT/APPHOST/"
siteName = "Default Web Site"
configPath = configFile & siteName
configSectionName = _
	"system.webServer/security/authentication/anonymousAuthentication"

'create the ahManager object
Set ahManager = CreateObject("Microsoft.ApplicationHost.WritableAdminManager")

'get the anonymous authentication section
set anonymousAuth = _
	ahManager.GetAdminSection(configSectionName, configPath)

'set the enabled attribute to false
anonymousAuth.Properties.Item("enabled").Value = False

'commit the changes
ahManager.CommitChanges()
