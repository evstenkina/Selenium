package com.dataart.springtraining.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
public class JSController {

    @RequestMapping(value = "/js")
    public String js(){
        return "js";
    }
}
