‘ Set variable values here
‘ Can be supplied via argument scripts, or read from a file
strUser = “DomainA\User1”
strPassword = “Password1”
‘ Supply contents of Base64 encoded .cer file or read .cer file in using
‘ the File System Object
strCertificate = “xxxxxxxxxxxxxxx”
Set objAdmin = CreateObject(“Microsoft.ApplicationHost.WritableAdminManager”)
Set objIISCertMap = objAdmin.GetAdminSection( _
“system.webServer/security/authentication/” & _
“iisClientCertificateMappingAuthentication”, _
“ machine/webroot/apphost/Default Web Site”)
Set obj1t1MappingsElement = objIISCertMap.ChildElements.Item(“oneToOneMappings”)
Set objMapping = obj1t1MappingsElement.collection.createNewElement()
objMapping.Properties.Item(“username”).Value = strUser
objMapping.Properties.Item(“password”).Value = strPassword
objMapping.Properties.Item(“certificate”).Value = strCertificate
objMapping.Properties.Item(“enabled”).Value = true
obj1t1MappingsElement.Collection.AddElement(objMapping)
objAdmin.CommitChanges()