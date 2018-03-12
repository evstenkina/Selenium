package com.dataart.springtraining.controllers.authentication;

import com.dataart.springtraining.models.enums.StaticPages;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.ui.Model;

@Controller
@RequestMapping(value = "/auth")
public class LoginLogoutController {
	
	@RequestMapping(value = "/login", method = RequestMethod.GET)
	public String getLoginPage(
				@RequestParam(value="error", required=false) boolean error,
				Model model) {
		if (error == true) {
			model.addAttribute("flash", "You have entered an invalid username or password!");
		} else {
			model.addAttribute("flash", null);
		}		
		model.addAttribute("template", "secLoginPage");
		return StaticPages.SMALL_LAYOUT;
	}
	
	@RequestMapping(value = "/denied", method = RequestMethod.GET)
	public String getDeniedPage() {
		return StaticPages.SEC_DENIED_PAGE;
	}
}
