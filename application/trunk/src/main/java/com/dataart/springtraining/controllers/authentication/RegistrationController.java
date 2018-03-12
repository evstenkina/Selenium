package com.dataart.springtraining.controllers.authentication;

import com.dataart.springtraining.dao.*;
import com.dataart.springtraining.models.RoleModel;
import com.dataart.springtraining.models.UserModel;
import com.dataart.springtraining.models.enums.StaticPages;
import com.dataart.springtraining.service.CustomUserDetailsService;
import com.dataart.springtraining.service.UserService;

import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.User;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;

@Controller
@RequestMapping(value = "/register")
public class RegistrationController {
	
	@Autowired
	UserDao userDao;
	
	@Autowired
	RoleDao roleDao;
	
	@Autowired
	UserDetailsService customUserDetailsService;

	@Autowired
	UserService userService;

	@Autowired
	@Qualifier("authenticationManager")
	AuthenticationManager authenticationManager;
    
	@RequestMapping(value = "", method = RequestMethod.GET)
	public String register(Model model) {		
		model.addAttribute("roles", roleDao.getRoles());
		model.addAttribute("template", "register");
		return StaticPages.SMALL_LAYOUT;
	}
	
	@RequestMapping(value = "", method = RequestMethod.POST)
	public String registerSave(
			@RequestParam("lname") String lname,
			@RequestParam("fname") String fname,
			@RequestParam("name") String name,
			@RequestParam("password") String password,
			@RequestParam("passwordConfirm") String passwordConfirm,
			@RequestParam("role") String roleName,
			Model model) {
		String flash = null;
		RoleModel roleModel = null;
		if (!userService.validateFieldsNotEmpty(lname, fname, name, password, passwordConfirm)){
			flash = "Fill all fields";
		} else if (!userService.validatePasswords(password, passwordConfirm)) {
			flash = "Password was not confirmed";
		} else if ((roleModel = roleDao.getRoleByName(roleName)) == null){
			flash = "Role is incorrect";
		}
		if (flash != null) {
			model.addAttribute("lname", lname);
			model.addAttribute("fname", fname);
			model.addAttribute("name", name);
			model.addAttribute("roleName", roleName);
			model.addAttribute("roles", roleDao.getRoles());
			model.addAttribute("flash", flash);
			model.addAttribute("template", "register");
			return StaticPages.SMALL_LAYOUT;
		} else {
			UserModel userModel = new UserModel(fname, lname, name, password);
			userModel.setRoleModel(roleModel);
			try{
				userDao.createUser(userModel);			
			}
			catch(Throwable t) {
				flash = "User with this name already registered";
				model.addAttribute("roles", roleDao.getRoles());
				model.addAttribute("flash", flash);				
				model.addAttribute("template", "register");
                return StaticPages.SMALL_LAYOUT;
            }

			UserDetails userDetails = new User(
					userModel.getName(),
					userModel.getPassword(),
					true,true,true,true,
					((CustomUserDetailsService)customUserDetailsService).getAuthorities(userModel));
			
			Authentication authentication = new UsernamePasswordAuthenticationToken(
			                userDetails, userDetails.getPassword(), userDetails.getAuthorities());
			SecurityContextHolder.getContext().setAuthentication(authentication);
			
			return "redirect:/";
		}
	}
}

