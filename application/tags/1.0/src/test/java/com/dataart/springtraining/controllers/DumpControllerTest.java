package com.dataart.springtraining.controllers;

import com.dataart.springtraining.service.DumpService;
import org.junit.Test;
import org.springframework.test.web.server.ResultActions;

import static org.fest.reflect.core.Reflection.field;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.verify;
import static org.springframework.test.web.server.setup.MockMvcBuilders.standaloneSetup;
import static org.springframework.test.web.server.request.MockMvcRequestBuilders.get;

public class DumpControllerTest {
    DumpController controller = new DumpController();
    DumpService service = mock(DumpService.class);

    @Test
    public void getDumpTest() throws Exception{
        field("dumpService").ofType(DumpService.class).in(controller).set(service);
        ResultActions result = standaloneSetup(controller).build().perform((get("/dump")));
        verify(service).getDump();
    }
}