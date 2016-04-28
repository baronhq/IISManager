Imports Microsoft.Web.Administration

Module Sample

    Sub Main()

        'Show all running page requests
        Dim SM As New ServerManager

        'loop through each running worker process
        For Each wp As WorkerProcess In SM.WorkerProcesses
            Console.WriteLine("App Pool Name: " & wp.AppPoolName)
            Console.WriteLine("Worker Process PID: " & wp.ProcessId)
            'loop through each running page request

            For Each request As Request In wp.GetRequests(0)
                Console.WriteLine(" &nbsp; Request:" & request.Url)
            Next
        Next

    End Sub

End Module
