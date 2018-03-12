package com.dataart.springtraining.controllers;

import com.dataart.springtraining.dao.ApplicationDao;
import com.dataart.springtraining.dao.UserDao;
import com.dataart.springtraining.models.ApplicationModel;
import com.dataart.springtraining.models.CategoryModel;
import com.dataart.springtraining.models.UserModel;
import com.dataart.springtraining.models.enums.StaticPages;
import com.dataart.springtraining.service.ApplicationService;
import com.dataart.springtraining.service.UserService;
import com.dataart.springtraining.service.UtilService;
import org.junit.Before;
import org.junit.Test;
import org.springframework.test.web.server.ResultActions;
import org.springframework.ui.Model;

import java.util.LinkedList;
import java.util.Map;

import static org.fest.assertions.Assertions.assertThat;
import static org.fest.reflect.core.Reflection.field;
import static org.mockito.BDDMockito.given;
import static org.mockito.Matchers.any;
import static org.mockito.Matchers.eq;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.verify;
import static org.springframework.test.web.server.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.server.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.server.setup.MockMvcBuilders.standaloneSetup;

public class ApplicationControllerTest {
    ApplicationController controller = new ApplicationController();
    ApplicationService applicationService;
    UserService userService;
    ApplicationDao applicationDao;


    @Before
    public void setup(){
        applicationService = mock(ApplicationService.class);
        applicationDao = mock(ApplicationDao.class);
        userService = mock(UserService.class);
        given(userService.getAuthenticatedUser()).willReturn(mock(UserModel.class));
        field("applicationService").ofType(ApplicationService.class).in(controller).set(applicationService);
        field("userService").ofType(UserService.class).in(controller).set(userService);
        field("applicationDao").ofType(ApplicationDao.class).in(controller).set(applicationDao);
    }

    @Test
    public void myTest() throws Exception{
        given(applicationService.getApplicationsForUser(any(Model.class),any(UserModel.class))).willReturn(mock(Model.class));
        ResultActions result = standaloneSetup(controller).build().perform((get("/my")));
        assertThat(result.andReturn().getModelAndView().getViewName()).isEqualTo(StaticPages.LAYOUT);
        verify(applicationService).getApplicationsForUser(any(Model.class),any(UserModel.class));
    }

    @Test
    public void indexTest() throws Exception{
        given(applicationService.getApplicationsForCategory(any(Model.class), eq("category"))).willReturn(mock(Model.class));
        given(applicationDao.getMostPopular()).willReturn(mock(LinkedList.class));
        ResultActions result = standaloneSetup(controller).build().perform((get("/?category=category")));
        assertThat(result.andReturn().getModelAndView().getViewName()).isEqualTo(StaticPages.LAYOUT);
        verify(applicationService).getApplicationsForCategory(any(Model.class), eq("category"));
        verify(applicationDao).getMostPopular();
    }

    @Test
    public void editTest() throws Exception{
        given(applicationService.getModelForEdit(any(Model.class), eq("title"))).willReturn(mock(Model.class));
        ResultActions result = standaloneSetup(controller).build().perform((get("/edit?title=title")));
        assertThat(result.andReturn().getModelAndView().getViewName()).isEqualTo(StaticPages.LAYOUT);
        verify(applicationService).getModelForEdit(any(Model.class), eq("title"));
    }
}
