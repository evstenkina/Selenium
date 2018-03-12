package com.dataart.springtraining.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.authentication.encoding.Md5PasswordEncoder;
import org.springframework.security.core.context.SecurityContext;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.stereotype.Service;

@Service
public class UtilService {

    @Autowired
    Md5PasswordEncoder passwordEncoder;

    public String encodePassword(String password){
        return passwordEncoder.encodePassword(password, null);
    }

    public double getAvg(long count, long sum){
        return count == 0 ? 0 : Math.round((sum * 10.0)/count)/10.0;
    }

    public SecurityContext getContext(){
        return SecurityContextHolder.getContext();
    }

}

