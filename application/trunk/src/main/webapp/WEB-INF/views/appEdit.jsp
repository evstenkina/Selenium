<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ page session="false"%>
	<h1>Edit application</h1>
	<form action="/edit" method="post" enctype="multipart/form-data">
	<input type="hidden" name="title" value="${application.getTitle()}" />
	<table>
	<tr>
		<td><label for="description">Description</label></td>		
		<td><textarea name="description" rows="6" cols="40">${application.getDescription()}</textarea></td>
	</tr>
	<tr>
		<td><label for="category">Category</label></td>		
		<td><select name="category">
			<c:forEach items="${categories}" var="category">
				<option value="${category.getId()}" <c:if test="${category.getId() == application.getCategory().getId()}">selected="selected"</c:if> >${category.getTitle()}</option>
			</c:forEach>
		</select></td>		
	</tr>
		<tr>
	 	<td><label for="image">Image jpeg (will be resied to fit 512x512)</label></td>		
		<td><input type="file" name="image"/></td>
	</tr>
	
	<tr>
	 	<td><label for="icon">Icon jpeg (will be resied to fit 128x128)</label></td>		
		<td><input type="file" name="icon"/></td>
	</tr>
	</table>	
		<input type="submit" value="Update" />
	</form>