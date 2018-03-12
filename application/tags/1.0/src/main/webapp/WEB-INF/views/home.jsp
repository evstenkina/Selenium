<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ page session="false"%>

<%@ include file="mostPopular.jsp" %>
	
	<!--  categories -->
	<div class="categories">
		<ul class="categories-ul">
		<li>
			<a href="/">All</a>
		</li>
		<c:forEach items="${categories}" var="category">
			<li>
				<a href="/?category=${category.getId()}">${category.getTitle()}</a>
			</li>
		</c:forEach>
		</ul>
	</div>
	
	<!--  applications -->
	<div class="apps-container">
	<c:if test="${apps.size()>0}">
		<%@ include file="apps.jsp" %>
	</c:if>
	<c:if test="${apps.size()==0}">
		<i>no applications ...</i>
	</c:if>
	</div>
	
</body>
</html>
