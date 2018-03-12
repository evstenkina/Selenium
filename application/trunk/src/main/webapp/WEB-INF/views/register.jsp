<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ page session="false"%>
	
	<h1>Fill this form to register.</h1>	
	<form action="/register" method="post">
	<table>
		<tr><td>
		<label for="name">Name</label></td>	
		<td><input type="text" name="name" value="${name}"/></td>
		</tr>
	<tr><td>
		<label for="fname">First Name</label></td>		
		<td><input type="text" name="fname" value="${fname}"/></td>
	</tr>
	<tr><td>			
		<label for="lname">Last Name</label></td>		
		<td><input type="text" name="lname" value="${lname}"/></td>	
	<tr><td>
		<label for="lname">Password</label></td>		
		<td><input type="password" name="password" /></td>	
	<tr><td>		
		<label for="lname">Confirm Password</label></td>
		<td><input type="password" name="passwordConfirm" /></td>	
	<tr><td>
		<label for="role">Role</label></td>		
		<td><select name="role">
			<c:forEach items="${roles}" var="role">
				<option value="${role.getName()}"
				
				<c:if test="${role.getName().equals(roleName)}">
					selected="selected" 				 
				 </c:if>				
				>${role.getTitle()}	</option>
			</c:forEach>
		</select></td>
		</tr></table>		
	<input type="submit" value="Register" />
	</form>
