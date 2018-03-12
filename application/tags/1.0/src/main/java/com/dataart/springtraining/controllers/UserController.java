package com.dataart.springtraining.controllers;

import com.dataart.springtraining.models.UserModel;
import com.dataart.springtraining.models.enums.StaticPages;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
public class UserController extends BasicController {
	
	@RequestMapping(value = "/account", method = RequestMethod.GET)
	public String edit(Model model) {
		return renderStd(model, "editAccount");
	}
	
	@RequestMapping(value = "/account", method = RequestMethod.POST)
	public String update(
			@RequestParam("lname") String lname,
			@RequestParam("fname") String fname,			
			@RequestParam("password") String password,
			@RequestParam("passwordConfirm") String passwordConfirm,
			@RequestParam("currentPassword") String currentPassword,
			Model model) {
		
		String flash = null;		
		UserModel user = userService.getAuthenticatedUser();
		if (!user.getPassword().equals(utilService.encodePassword(currentPassword))){
			flash = "Enter current password";
		} else if (!userService.validateFieldsNotEmpty(lname, fname, "-", password, passwordConfirm)){
			flash = "Fill all fields";
		} else if (!userService.validatePasswords(password, passwordConfirm)) {
			flash = "Password was not confirmed";
		}
		if (flash != null) {
			model.addAttribute("currentUser", user);
			return render(model, "editAccount", StaticPages.LAYOUT, null, flash);
		}
		user.setFname(fname);
		user.setLname(lname);
		user.setPassword(password);
		userDao.updateUser(user);
		flash = "Saved";

		return renderStd(model, "editAccount", flash, null);		
	}
}

