<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ page session="false"%>

<div class="apps">
	<c:forEach items="${apps}" var="app">
		<div class="app">
		<img alt="${app.getTitle()}" src="/icon?id=${app.getTitle()}" />
		<div class="name">		
			${app.getTitle()}
		</div>
		
		<div class="description">		
			${app.getDescription()} 
			
		</div>
		<div class="downloads"># of downloads: ${app.getNumberOfDownloads()}</div>
		<a href="/app?title=${app.getTitle()}">Details</a>
		</div>
	</c:forEach>
</div>