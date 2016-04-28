Imports Microsoft.Web.Administration

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Create a vdir.  path folder must exist.

        Dim subdir As String = "/ExampleSubDir"
        Dim path As String = "c:\inetpub\wwwroot\defaultroot\examplesubdir"

        Dim sm As ServerManager = New ServerManager

        'Create the application
        sm.Sites("Default Web Site").Applications.Add( _
            "/ExampleSubDir", _
            path)

        'Assign the application to an application pool
        sm.Sites("Default Web Site").Applications( _
            subdir).ApplicationPoolName = "DefaultAppPool"

        sm.CommitChanges()

    End Sub
End Class
