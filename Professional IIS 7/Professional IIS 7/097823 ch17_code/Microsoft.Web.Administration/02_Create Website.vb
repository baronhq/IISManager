Imports Microsoft.Web.Administration

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Create a website called Site1
        Dim SM As New ServerManager
        SM.Sites.Add("Site1", "http", ":80:", "c:\websites\Site1")
        SM.CommitChanges()

    End Sub
End Class
