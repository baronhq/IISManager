'Enable remote management, set to include IIS Manager Users
'Update service mode and start service

Const HKLM = &H80000002

strComputer = "."
strService = "WMSvc"

'Connect to the root namespace in WMI
Set objRegistry = GetObject("winmgmts:\\" & strComputer & _
	"\root\default:StdRegProv")

strKeyPath = "Software\Microsoft\WebManagement\Server"

'Turn on Remote Management
strValueName = "EnableRemoteManagement"
strValue = 1
call objRegistry.SetDWORDValue(HKLM, _
	strKeyPath, _
	strValueName, _
	strValue)

'Enable IIS Manager with Windows and IIS Manager Credentials
strValueName = "RequiresWindowsCredentials"
strValue = 0
objRegistry.SetDWORDValue HKLM, _
	strKeyPath, _
	strValueName, _
	strValue

'Connect to the cimv2 namespace in WMI
Set objWMIService = GetObject("winmgmts:" _
	& "{impersonationLevel=impersonate}!\\" & strComputer _
	& "\root\cimv2")

'Get all services called WMSvc (there will only be 1)
Set colServiceList = objWMIService.ExecQuery _
	("Select * from Win32_Service where Name='" & _
	strService & "'")

For Each objService in colServiceList
	'Change the service account to start automatically
	errChangeMode = objService.Change( , , , , "Automatic")
	'Start the service
	errStartService = objService.StartService()
Next