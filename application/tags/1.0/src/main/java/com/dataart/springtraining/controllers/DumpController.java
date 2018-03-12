package com.dataart.springtraining.controllers;

import com.dataart.springtraining.models.Dump;
import com.dataart.springtraining.models.enums.MediaTypes;
import com.dataart.springtraining.service.DumpService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;

@Controller
public class DumpController {
    @Autowired
    DumpService dumpService;

    @RequestMapping(value="/dump", method = RequestMethod.GET, produces = MediaTypes.JSON)
    public @ResponseBody
    Dump getDump(){
        return dumpService.getDump();
    }

}
