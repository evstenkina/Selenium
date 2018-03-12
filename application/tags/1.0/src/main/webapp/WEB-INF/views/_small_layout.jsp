<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ page session="false"%>
<html>
<head>
	<title>Selenium test application</title>
	<link href="/resources/login.css" rel="stylesheet" media="all" />
</head>
<body>

	<div class="form">		
		<%@ include file="flash.jsp" %>
		<jsp:include page="${template}.jsp" />
	</div>	
</body>
</html>
