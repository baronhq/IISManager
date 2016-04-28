Imports Microsoft.Web.Administration

Module Sample

    Sub Main()

        'Get default documents on Site1
        Dim SM As New ServerManager

        Dim config As Configuration = SM.GetWebConfiguration("Site1")
        Dim section As ConfigurationSection = _
            config.GetSection("system.webServer/defaultDocument")
        Dim filescollection As ConfigurationElementCollection

        filescollection = section.GetCollection("files")

        For Each item As ConfigurationElement In filescollection
            Console.WriteLine(item.Attributes("value").Value)
        Next

    End Sub

End Module
