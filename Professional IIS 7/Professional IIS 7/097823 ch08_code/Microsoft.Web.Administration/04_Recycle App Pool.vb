Imports Microsoft.Web.Administration

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Recycle app pool
        Dim apppool As String = "DefaultAppPool"

        Dim sm As ServerManager = New ServerManager
        sm.ApplicationPools(apppool).Recycle()

    End Sub
End Class
