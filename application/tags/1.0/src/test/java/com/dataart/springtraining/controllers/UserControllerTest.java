package com.dataart.springtraining.controllers;

import com.dataart.springtraining.dao.UserDao;
import com.dataart.springtraining.models.UserModel;
import com.dataart.springtraining.models.enums.StaticPages;
import com.dataart.springtraining.service.UserService;
import com.dataart.springtraining.service.UtilService;
import org.junit.Before;
import org.junit.Test;
import org.springframework.test.web.server.ResultActions;

import java.util.Map;

import static org.fest.assertions.Assertions.assertThat;
import static org.fest.reflect.core.Reflection.field;
import static org.mockito.BDDMockito.given;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.verify;
import static org.springframework.test.web.server.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.server.setup.MockMvcBuilders.standaloneSetup;
import static org.springframework.test.web.server.request.MockMvcRequestBuilders.get;

/**
 * Created with IntelliJ IDEA.
 * User: ygubin
 * Date: 17/10/12
 * Time: 09:07
 * To change this template use File | Settings | File Templates.
 */
public class UserControllerTest {
    UserService userService;
    UserDao userDao;
    UtilService utilService;

    UserController controller = new UserController();
    UserModel user;

    @Before
    public void setup(){
        userService = mock(UserService.class);
        utilService = mock(UtilService.class);
        userDao = mock(UserDao.class);
        field("userDao").ofType(UserDao.class).in(controller).set(userDao);
        field("userService").ofType(UserService.class).in(controller).set(userService);
        field("utilService").ofType(UtilService.class).in(controller).set(utilService);
        given(userService.getAuthenticatedUser()).willReturn(user = mock(UserModel.class));
    }

    @Test
    public void editTest() throws Exception{
        ResultActions result = standaloneSetup(controller).build().perform((get("/account")));
        Map<String, Object> map = result.andReturn().getModelAndView().getModel();
        assertThat(map.get("template")).isEqualTo("editAccount");
        assertThat(result.andReturn().getModelAndView().getViewName()).isEqualTo(StaticPages.LAYOUT);
    }

    @Test
    public void updateTest1() throws Exception{
        given(user.getPassword()).willReturn("password");
        given(utilService.encodePassword("password")).willReturn("!password");
        ResultActions result = standaloneSetup(controller).build().perform((
                post("/account?lname=lname&fname=fname&password=password&passwordConfirm=password&currentPassword=password")
        ));

        Map<String, Object> map = result.andReturn().getModelAndView().getModel();
        assertThat(map.get("error")).isEqualTo("Enter current password");
        assertThat(map.get("template")).isEqualTo("editAccount");
        assertThat(result.andReturn().getModelAndView().getViewName()).isEqualTo(StaticPages.LAYOUT);
    }


    @Test
    public void updateTest2() throws Exception{
        given(user.getPassword()).willReturn("password");
        given(utilService.encodePassword("password")).willReturn("password");
        given(userService.validateFieldsNotEmpty("lname","fname", "-", "password", "password")).willReturn(false);

        ResultActions result = standaloneSetup(controller).build().perform((
                post("/account?lname=lname&fname=fname&password=password&passwordConfirm=password&currentPassword=password")
        ));

        Map<String, Object> map = result.andReturn().getModelAndView().getModel();
        assertThat(map.get("error")).isEqualTo("Fill all fields");
        assertThat(map.get("template")).isEqualTo("editAccount");
        assertThat(result.andReturn().getModelAndView().getViewName()).isEqualTo(StaticPages.LAYOUT);
    }

    @Test
    public void updateTest3() throws Exception{
        given(user.getPassword()).willReturn("password");
        given(utilService.encodePassword("password")).willReturn("password");
        given(userService.validateFieldsNotEmpty("lname","fname", "-", "password", "password")).willReturn(true);
        given(userService.validatePasswords("password", "password")).willReturn(false);

        ResultActions result = standaloneSetup(controller).build().perform((
                post("/account?lname=lname&fname=fname&password=password&passwordConfirm=password&currentPassword=password")
        ));

        Map<String, Object> map = result.andReturn().getModelAndView().getModel();
        assertThat(map.get("error")).isEqualTo("Password was not confirmed");
        assertThat(map.get("template")).isEqualTo("editAccount");
        assertThat(result.andReturn().getModelAndView().getViewName()).isEqualTo(StaticPages.LAYOUT);
    }

    @Test
    public void updateTest4() throws Exception{
        given(user.getPassword()).willReturn("password");
        given(utilService.encodePassword("password")).willReturn("password");
        given(userService.validateFieldsNotEmpty("lname", "fname", "-", "password", "password")).willReturn(true);
        given(userService.validatePasswords("password", "password")).willReturn(true);

        ResultActions result = standaloneSetup(controller).build().perform((
                post("/account?lname=lname&fname=fname&password=password&passwordConfirm=password&currentPassword=password")
        ));

        Map<String, Object> map = result.andReturn().getModelAndView().getModel();
        assertThat(map.get("error")).isNull();
        assertThat(map.get("flash")).isEqualTo("Saved");
        assertThat(map.get("template")).isEqualTo("editAccount");
        assertThat(result.andReturn().getModelAndView().getViewName()).isEqualTo(StaticPages.LAYOUT);
        verify(userDao).updateUser(user);
    }
}
