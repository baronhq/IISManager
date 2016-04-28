<%@ Page Trace="true" %>

<html>
<head>
  <title>Sample Page with Tracing</title>
</head>
<body>

<%
' Trace.Write information before the pause.
Trace.Write("Custom", "We are Sleeping for 1000 milliseconds")
' Pause/Sleep for 1 second.
System.Threading.Thread.Sleep(1000)
' Trace.Write to show when the pause has completed.
Trace.Write("Custom", "Done sleeping, time to wake up.")
%>

Done

</body>
</html>
