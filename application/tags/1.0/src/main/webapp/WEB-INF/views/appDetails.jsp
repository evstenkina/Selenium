<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ page session="false"%>

<%@ include file="mostPopular.jsp" %>

<div class="application">


<img alt="${app.getTitle()}" src="/image?id=${app.getTitle()}" />
<div class="name">
	${app.getTitle()}
</div>
<div class="description">
	Description: ${app.getDescription()}
</div>
<div class="description">
	Category: ${app.getCategory().getTitle()}
</div>
<div class="description">Author: ${app.getAuthor().getName()}
</div>
<div class="downloads"># of downloads: ${app.getNumberOfDownloads()}</div>

<div class="download-button">
	<a href="/download?title=${app.getTitle()}">Download</a>
</div>


<div class="edit-app-button">
	<c:if test="${allowEdit}">
		<a href="/delete?title=${app.getTitle()}" onclick="return confirmDelete();">Delete</a>
		<a href="/edit?title=${app.getTitle()}">Edit</a>
	</c:if>
</div>

Avg rate: ${rateAvg}
<form action="/app?title=${app.getTitle()}" method="post">
	<input type="hidden" name="title" value="${app.getTitle()}" />
	<c:if test="${canRate}">
		Rate it now	
		<select name="rate">			
			<option value="5">5</option>			
			<option value="4">4</option>
			<option value="3">3</option>
			<option value="2">2</option>
			<option value="1">1</option>
		</select>
		<input type="submit" name="save" value="Save"/>	
	</c:if>
	
	<c:if test="${!canRate}">
			Your rate: ${myRate}
			<input type="submit" name="clear" value="Clear"/>
	</c:if>
</form>
</div>

<script type="text/javascript">
	function confirmDelete(){
		return confirm("Do you want to delete this application?");
	}
</script>