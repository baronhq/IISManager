Imports Microsoft.Web.Administration

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Create app pool and change framework version 
        Dim SM As New ServerManager
        Dim apppool As ApplicationPool

        apppool = SM.ApplicationPools.Add("Site2AppPool")
        apppool.ManagedRuntimeVersion = "v1.1"

        SM.CommitChanges()

    End Sub
End Class
