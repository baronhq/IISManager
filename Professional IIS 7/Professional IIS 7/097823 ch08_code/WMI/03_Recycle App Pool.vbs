'Recycle app pool
strAppPool = "DefaultAppPool"

Set oService = GetObject("winmgmts:root\WebAdministration")

'get the app pool instance
Set oAppPool = oService.Get("ApplicationPool.Name='" & strAppPool & "'")

oAppPool.Recycle
