'List running worker processes (app pools)
Set oService = GetObject("winmgmts:root\WebAdministration")
Set oWorkerProcesses = oService.InstancesOf("WorkerProcess")

For Each WP In oWorkerProcesses
	strPID = "WP """ & WP.ProcessId & """"
	strAppPool = "(applicationPool:" _
	& WP.AppPoolName & ")"
	WScript.echo(strPID & " " & strAppPool)
Next