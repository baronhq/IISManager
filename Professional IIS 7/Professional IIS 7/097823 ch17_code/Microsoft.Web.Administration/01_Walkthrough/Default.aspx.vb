Imports Microsoft.Web.Administration

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub CreateSiteButton_Click(ByVal sender As Object, _
            ByVal e As System.EventArgs) _
            Handles CreateSiteButton.Click

        'Declare and instigate ServerManager
        Dim SM As New ServerManager
        Dim bindingInfo As String
        Dim mySite As Site

        'Create the bindingInfo variable which will be in the
        'form for “IP:Port:HostHeader”. Example “:80:” is
        'everything on port 80.
        bindingInfo = IPTextBox.Text & ":" & _
            PortTextBox.Text & ":" & _
            HostHeaderTextBox.Text

        'Create an App Pool for this site
        SM.ApplicationPools.Add(NameTextBox.Text)

        'Create the Site
        mySite = SM.Sites.Add(NameTextBox.Text, _
            "HTTP", _
            bindingInfo, _
            PathTextBox.Text)

        'Add site to app pool. Application(0) is the first and only
        'application in the site so far.
        mySite.Applications(0).ApplicationPoolName _
            = NameTextBox.Text

        'Changes will not take effect until CommitChanges is called.
        SM.CommitChanges()

        StatusLabel.Text = "Website " & NameTextBox.Text & " was created."

    End Sub
End Class
