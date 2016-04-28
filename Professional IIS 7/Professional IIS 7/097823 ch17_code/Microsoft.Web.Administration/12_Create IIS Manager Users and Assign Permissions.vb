Imports Microsoft.Web.Management.Server

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Create IIS Manager user and assign permissions
        Dim user As ManagementUserInfo

        'create IIS Manager user
        user = ManagementAuthentication.CreateUser("IISUser1", "password")

        'grant the freshly created user permissions to the site
        ManagementAuthorization.Grant(user.Name, "Site1", False)

        'additionally, great the Windows user permission to the site
        ManagementAuthorization.Grant("DomainA.local/User2", "Site1", False)

    End Sub
End Class
