<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form" %>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring" %>
 
<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%> 
<h1>Login</h1>
<form action="../j_spring_security_check" method="post" > 
<table>
<tr><td><label for="j_username">Username</label></td>
<td><input id="j_username" name="j_username" type="text" /></td>
</tr>
<tr><td>
<label for="j_password">Password</label></td>
<td><input id="j_password" name="j_password" type="password" /></td>
</tr>

</table>
<input  type="submit" value="Login"/>       
 
</form>
<a href="../register">Register as a new user</a>
