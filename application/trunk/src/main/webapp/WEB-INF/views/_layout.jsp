<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ page session="false"%>
<html>
<head>
	<title>Selenium test application</title>
	<link href="/resources/all.css" rel="stylesheet" media="all" />
</head>
<body>

	<div class="header">
		<div class="welcome">Welcome ${currentUser.fname} ${currentUser.lname}</div>
		<div class="title">Selenium test application</div>
		<div class="navigation">
		    <a href="/calc/">Ajax test page</a>
		    <a href="/js/">JS test page</a>
			<a href="/">Home</a>
			<c:if test="${currentUser.roleModel.isDeveloper()}">
				<a href="/my">My applications</a>
			</c:if>
		</div>
		<div class="account">
			<a href="/account">Edit account</a>
			<a href="/auth/logout">Logout</a>
		</div>
		<br/>
	</div>
	<div class="content">
		<%@ include file="flash.jsp" %>
		<jsp:include page="${template}.jsp" />
	</div>	
	<div class="footer">
		<a href="/dump/">dump</a>
	</div>
</body>
</html>
