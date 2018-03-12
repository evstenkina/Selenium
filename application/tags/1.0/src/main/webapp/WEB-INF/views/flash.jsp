<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ page session="false"%>
<c:if test="${flash != null}">
	<p class="flash">
		${flash}
	</p>
</c:if>

<c:if test="${error != null}">
	<p class="error">
		${error}
	</p>
</c:if>
