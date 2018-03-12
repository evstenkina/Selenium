package com.dataart.springtraining.service;

import com.dataart.springtraining.dao.*;

import com.dataart.springtraining.models.UserModel;
import org.apache.commons.lang.StringUtils;
import org.springframework.security.core.context.SecurityContext;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.stereotype.Service;
import org.springframework.beans.factory.annotation.Autowired;

@Service
public class UserService {
	
	@Autowired
	UserDao userDao;

    @Autowired
    UtilService utilService;


    public UserModel getAuthenticatedUser(){
    	return userDao.getUserByName(utilService.getContext().getAuthentication().getName());
	}
    
    public boolean validateFieldsNotEmpty(String lname,
			String fname,
			String email,
			String password,
			String passwordConfirm){
    	boolean hasEmpty = StringUtils.isBlank(lname) || StringUtils.isBlank(fname) || StringUtils.isBlank(email) || StringUtils.isBlank(password) || StringUtils.isBlank(passwordConfirm);
    	return !hasEmpty;
    }
    
    public boolean validatePasswords(String password, String passwordConfirm){
    	return password.equals(passwordConfirm);
    }
}

