Imports Microsoft.Web.Administration

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Create a new application pool and set samples properties
        Dim appPool As String = "ExampleAppPool"
        Dim sm As ServerManager = New ServerManager
        sm.ApplicationPools.Add(appPool)

        sm.ApplicationPools(appPool).ManagedRuntimeVersion = "v2.0"
        sm.ApplicationPools(appPool).ProcessModel.PingingEnabled = False

        sm.CommitChanges()

    End Sub
End Class
