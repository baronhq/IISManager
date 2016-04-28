Imports Microsoft.Web.Administration

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Recycle app pool
        Dim SM As New ServerManager
        SM.ApplicationPools("Site1").Recycle()

    End Sub
End Class
