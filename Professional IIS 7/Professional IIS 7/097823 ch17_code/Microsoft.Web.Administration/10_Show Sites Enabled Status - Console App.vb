Imports Microsoft.Web.Administration

Module Sample

    Sub Main()

        'Displays whether or not Site1 default docs is enabled
        Dim SM As New ServerManager

        Dim config As Configuration = SM.GetWebConfiguration("Site1")
        Dim section As ConfigurationSection = _
            config.GetSection("system.webServer/defaultDocument")
        Dim enabled As ConfigurationAttribute = section.Attributes("enabled")

        Console.WriteLine(enabled.Value)

    End Sub

End Module
