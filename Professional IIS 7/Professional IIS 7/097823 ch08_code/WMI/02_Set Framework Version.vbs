' update .NET framework version on app pool
strAppPool = "DefaultAppPool"
strRuntimeVersion = "v2.0"

' Set oIIS and oAppPool
Set oIIS = GetObject("winmgmts:root\WebAdministration")
Set oAppPool = oIIS.Get("ApplicationPool.Name='" _
	& strAppPool & "'")

' Set the ManagedRuntimeVersion and commit the changes
oAppPool.ManagedRuntimeVersion = strRuntimeVersion
oAppPool.Put_
