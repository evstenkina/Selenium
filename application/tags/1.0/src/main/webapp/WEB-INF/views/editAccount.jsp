<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ page session="false"%>

	<h1>Edit account</h1>
	
	<form action="/account" method="post">
	<table>		
		<tr>
			<td><label for="fname">First Name</label></td>		
			<td><input type="text" name="fname" value="${currentUser.getFname()}"/></td>
		</tr>
		<tr>		
			<td><label for="lname">Last Name</label></td>		
			<td><input type="text" name="lname" value="${currentUser.getLname()}"/></td>
		</tr>
	
	<tr>
		<td><label for="lname">Current password</label></td>		
		<td><input type="password" name="currentPassword" /></td>
	</tr>
	
	<tr>
		<td><label for="lname">New Password</label></td>		
		<td><input type="password" name="password" /></td>
	</tr>
	<tr>		
		<td><label for="lname">Confirm Password</label></td>
		<td><input type="password" name="passwordConfirm" /></td>
	</tr>	
	</table>		
		<input type="submit" value="Update" />
	</form>
