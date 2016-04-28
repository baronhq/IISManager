Set objAdmin = CreateObject(“Microsoft.ApplicationHost.WritableAdminManager”)
Set objIISCertMap = objAdmin.GetAdminSection( _
“system.webServer/security/authentication/” & _
“iisClientCertificateMappingAuthentication”, _
“ machine/webroot/apphost/Default Web Site”)
objIISCertMap.Properties.Item(“enabled”).Value = “true”
objIISCertMap.Properties.Item(“oneToOneCertificateMappingsEnabled”).Value = “true”