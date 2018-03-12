package com.dataart.springtraining.controllers;

import org.junit.Test;
import org.springframework.test.web.server.ResultActions;
import static org.fest.assertions.Assertions.assertThat;
import static org.springframework.test.web.server.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.server.setup.MockMvcBuilders.standaloneSetup;

public class CalcControllerTest {
    CalcController controller = new CalcController();

    @Test
    public void calcPage() throws Exception{
        ResultActions result = standaloneSetup(controller).build().perform((get("/calc/")));
        assertThat(result.andReturn().getModelAndView().getViewName()).isEqualTo("calc");
    }

    @Test
    public void calcValidTest() throws Exception{
        assertThat(call("1", "2").andReturn().getResponse().getContentAsString()).isEqualTo("{\"result\": \"3.0\"}");
        assertThat(call("-1", "2").andReturn().getResponse().getContentAsString()).isEqualTo("{\"result\": \"1.0\"}");
        assertThat(call("-1", "-2").andReturn().getResponse().getContentAsString()).isEqualTo("{\"result\": \"-3.0\"}");
        assertThat(call("-1", "0").andReturn().getResponse().getContentAsString()).isEqualTo("{\"result\": \"-1.0\"}");
    }

    @Test
    public void calcInvalidTest() throws Exception{
        assertThat(call("aa", "dd").andReturn().getResponse().getContentAsString()).isEqualTo("{\"result\": \"Incorrect data\"}");
    }

    private ResultActions call(String x, String y)  throws Exception{
        return standaloneSetup(controller).build().perform((get("/calc/sum?x=" + x + "&y=" + y + "&force=true")));
    }
}
