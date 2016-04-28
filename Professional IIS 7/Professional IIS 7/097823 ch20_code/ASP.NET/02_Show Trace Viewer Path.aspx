<html>
<head>
  <title>Show Trace Viewer Path</title>
</head>
<body>

<%= "Trace Viewer Path: " & Request("SERVER_NAME") _
	& ":" & Request("SERVER_PORT") _
	& Request.ApplicationPath.TrimEnd("/") _
	& "/trace.axd" %>

</body>
</html>
