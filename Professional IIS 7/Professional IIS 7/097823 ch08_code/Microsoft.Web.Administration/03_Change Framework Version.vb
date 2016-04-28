Imports Microsoft.Web.Administration

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Change framework version on app pool

        Dim appPool As String = "ExampleAppPool"
        Dim runtimeVersion As String = "v2.0"
        Dim sm As ServerManager = New ServerManager

        sm.ApplicationPools(appPool).ManagedRuntimeVersion = _
            runtimeVersion
        sm.CommitChanges()

    End Sub
End Class
