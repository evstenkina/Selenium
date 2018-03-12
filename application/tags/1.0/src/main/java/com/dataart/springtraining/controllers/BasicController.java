package com.dataart.springtraining.controllers;

import com.dataart.springtraining.dao.*;
import com.dataart.springtraining.models.enums.StaticPages;
import com.dataart.springtraining.service.UtilService;
import org.springframework.ui.Model;
import org.springframework.beans.factory.annotation.Autowired;
import com.dataart.springtraining.service.UserService;

public class BasicController {
	
	@Autowired
	protected ApplicationDao applicationDao;
	
	@Autowired
	protected UserService userService;
	
    @Autowired
    protected CategoryDao categoryDao;
    
    @Autowired
    protected RateDao rateDao;
    
    @Autowired
    protected UserDao userDao;

    @Autowired
    protected UtilService utilService;

    protected String renderStd(Model model, String template, String flash, String error){
    	model.addAttribute("currentUser", userService.getAuthenticatedUser());
		return render(model, template, StaticPages.LAYOUT, flash, error);
	}
    
    protected String renderStd(Model model, String template){
		return renderStd(model, template, null, null);
	}

	protected String render(Model model, String template, String layout, String flash, String error) {
		model.addAttribute("error", error);
		model.addAttribute("flash", flash);
		model.addAttribute("template", template);
		return layout;
	}

}

