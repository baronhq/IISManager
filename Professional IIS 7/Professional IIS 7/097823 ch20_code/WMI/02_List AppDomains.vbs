'List all running AppDomains
Set oService = GetObject("winmgmts:root\WebAdministration")
Set oAppDomains = oService.InstancesOf("AppDomain")

For Each AppDomain In oAppDomains
	WScript.echo("ID: " & AppDomain.Id)
	WScript.echo(" ApplicationPath: " & AppDomain.ApplicationPath)
	WScript.echo(" PhysicalPath: " & AppDomain.PhysicalPath)
	WScript.echo(" Process Id: " & AppDomain.ProcessId)
	WScript.echo(" SiteName: " & AppDomain.SiteName)
	WScript.echo(" IsIdle: " & AppDomain.IsIdle)
	WScript.echo("")
Next
