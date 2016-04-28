'Create new application pool and set sample properties

strAppPool = "ExampleAppPool"
Set oService = GetObject("winmgmts:root\WebAdministration")

'create the app pool
oService.Get("ApplicationPool").Create strAppPool, True

'get the app pool instance
Set oAppPool = oService.Get("ApplicationPool.Name='" & strAppPool & "'")

'set a property
oAppPool.Enable32BitAppOnWin64 = True

'commit them
oAppPool.Put_
