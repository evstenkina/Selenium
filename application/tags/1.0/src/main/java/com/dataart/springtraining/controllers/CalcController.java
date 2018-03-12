package com.dataart.springtraining.controllers;

import com.dataart.springtraining.models.enums.MediaTypes;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;

@Controller
@RequestMapping("/calc")
public class CalcController {

    @RequestMapping(value = "/sum", produces = MediaTypes.JSON)
    public @ResponseBody
    String sum(@RequestParam ("x") String x,
               @RequestParam ("y") String y,
               @RequestParam (value = "force", required = false) String force){
        try {
            if (force == null ){
                Thread.sleep(Math.round(Math.random() * 1000 * 3 + 2000));
            }
            String r = String.valueOf(Double.valueOf(x) + Double.valueOf(y));
            return "{\"result\": \"" + r + "\"}";
        } catch (Throwable t) {
            return "{\"result\": \"Incorrect data\"}";
        }
    }

    @RequestMapping("")
    public String calc(){
        return "calc";
    }
}
