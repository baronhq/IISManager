Imports Microsoft.Web.Administration

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Create an app pool called Site1AppPool
        Dim SM As New ServerManager
        SM.ApplicationPools.Add("Site1AppPool")
        SM.CommitChanges()

    End Sub
End Class
