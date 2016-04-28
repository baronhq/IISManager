Imports Microsoft.Web.Administration

Module Sample

    Sub Main()

        'Show running worker processes
        Dim SM As New ServerManager

        For Each wp As WorkerProcess In SM.WorkerProcesses
            Console.WriteLine(wp.AppPoolName & " " & wp.ProcessId)
        Next

    End Sub

End Module
