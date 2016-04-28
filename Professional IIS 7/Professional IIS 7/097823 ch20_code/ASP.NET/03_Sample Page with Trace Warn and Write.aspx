<%@ Page Trace="true" %>

<html>
<head>
  <title>Sample Trace.Write and Trace.Warn</title>
</head>
<body>

<%
' Write key information to the trace output
Trace.Write("The querystring information is: " _
	& Request.Querystring.ToString)

If Request.Querystring.ToString = "" Then
	Trace.Warn("No valid querystring is set.")
End If
%>

</body>
</html>
