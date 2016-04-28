Imports Microsoft.Web.Administration

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Set folder as application
        Dim SM As New ServerManager
        Dim site As Site

        site = SM.Sites("Site1")
        site.Applications.Add("/app1", "C:\websites\Site1\App1")

        SM.CommitChanges()

    End Sub
End Class
