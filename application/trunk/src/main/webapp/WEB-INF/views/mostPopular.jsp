<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ page session="false"%>
<div class="popular-container">
	<div class="title" >Popular apps</div>
	
	<c:forEach items="${popularapps}" var="app">
		<div class="popular-app">
			<a href="/app?title=${app.title}">
				<img alt="${app.title}" src="/icon?id=${app.title}" />
				<div>${app.title}</div>
			</a>
		</div>		
	</c:forEach>	
</div>
