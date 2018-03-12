package com.dataart.springtraining.controllers;

import org.junit.Test;
import org.springframework.test.web.server.ResultActions;

import static org.fest.assertions.Assertions.assertThat;
import static org.springframework.test.web.server.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.server.setup.MockMvcBuilders.standaloneSetup;

public class JsControllerTest {
    JSController controller = new JSController();

    @Test
    public void jsPage() throws Exception{
        ResultActions result = standaloneSetup(controller).build().perform((get("/js/")));
        assertThat(result.andReturn().getModelAndView().getViewName()).isEqualTo("js");
    }
}