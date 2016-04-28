Imports Microsoft.Web.Administration

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Add info to extended schema
        Dim SM As New ServerManager
        Dim config As Configuration = SM.GetApplicationHostConfiguration

        Dim section As ConfigurationSection = _
        config.GetSection("system.applicationHost/sites")

        Dim mySite As Site = SM.Sites("Default Web Site")
        Dim ownerInfo As ConfigurationElement = mySite.GetChildElement("OwnerInfo")

        ownerInfo.GetAttribute("name").Value = "Abraham Lincoln"
        ownerInfo.GetAttribute("email").Value = "16@whitehouse.gov"
        ownerInfo.GetAttribute("role").Value = "Admin"

        SM.CommitChanges()

    End Sub
End Class
