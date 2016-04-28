Imports Microsoft.Web.Administration

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim SM As New ServerManager
        Dim config As Configuration = SM.GetAdministrationConfiguration

        Dim section As ConfigurationSection = _
            config.GetSection("myCustomSection")

        section.GetAttribute("name").Value = "TheName"
        section.GetAttribute("Length").Value = 200
        section.GetAttribute("IsActive").Value = True
        section.GetAttribute("Color").Value = "Blue"

        SM.CommitChanges()

    End Sub
End Class
