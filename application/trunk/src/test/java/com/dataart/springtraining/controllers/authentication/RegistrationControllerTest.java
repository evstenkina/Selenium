package com.dataart.springtraining.controllers.authentication;

import com.dataart.springtraining.dao.RoleDao;
import com.dataart.springtraining.dao.UserDao;
import com.dataart.springtraining.models.RoleModel;
import com.dataart.springtraining.models.UserModel;
import com.dataart.springtraining.models.enums.StaticPages;
import com.dataart.springtraining.service.CustomUserDetailsService;
import com.dataart.springtraining.service.UserService;
import org.junit.Before;
import org.junit.Test;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.test.web.server.ResultActions;

import java.util.LinkedList;
import java.util.Map;

import static org.fest.assertions.Assertions.assertThat;
import static org.fest.reflect.core.Reflection.field;
import static org.mockito.BDDMockito.given;
import static org.mockito.Matchers.any;
import static org.mockito.Mockito.*;
import static org.springframework.test.web.server.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.server.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.server.setup.MockMvcBuilders.standaloneSetup;

public class RegistrationControllerTest {
    RegistrationController controller = new RegistrationController();
    UserDao userDao;
    RoleDao roleDao;
    CustomUserDetailsService userDetailsService;
    UserService userService;
    AuthenticationManager authenticationManager;

    @Before
    public void setup(){
        userDao = mock(UserDao.class);
        roleDao = mock(RoleDao.class);
        userDetailsService = mock(CustomUserDetailsService.class);
        userService = mock(UserService.class);
        authenticationManager = mock(AuthenticationManager.class);

        given(roleDao.getRoles()).willReturn(new LinkedList<RoleModel>());
        field("userDao").ofType(UserDao.class).in(controller).set(userDao);
        field("roleDao").ofType(RoleDao.class).in(controller).set(roleDao);
        field("customUserDetailsService").ofType(UserDetailsService.class).in(controller).set(userDetailsService);
        field("userService").ofType(UserService.class).in(controller).set(userService);
        field("authenticationManager").ofType(AuthenticationManager.class).in(controller).set(authenticationManager);
    }

    @Test
    public void registrationTest() throws Exception{
        ResultActions result = standaloneSetup(controller).build().perform((get("/register")));
        Map<String, Object> map = result.andReturn().getModelAndView().getModel();
        assertThat(map.get("template")).isEqualTo("register");
        verify(roleDao).getRoles();
        assertThat(result.andReturn().getModelAndView().getViewName()).isEqualTo(StaticPages.SMALL_LAYOUT);
    }

    @Test
    public void registerSaveTest1() throws Exception{
        given(userService.validateFieldsNotEmpty("lname", "fname", "name", "password", "password")).willReturn(false);
        ResultActions result = standaloneSetup(controller).build().perform((
                post("/register?lname=lname&fname=fname&name=name&password=password&passwordConfirm=password&role=role")
        ));

        Map<String, Object> map = result.andReturn().getModelAndView().getModel();
        assertThat(map.get("flash")).isEqualTo("Fill all fields");
        assertThat(map.get("template")).isEqualTo("register");
        assertThat(result.andReturn().getModelAndView().getViewName()).isEqualTo(StaticPages.SMALL_LAYOUT);
    }

    @Test
    public void registerSaveTest2() throws Exception{
        given(userService.validateFieldsNotEmpty("lname", "fname", "name", "password", "_password")).willReturn(true);
        given(userService.validatePasswords("password", "_password")).willReturn(false);

        ResultActions result = standaloneSetup(controller).build().perform((
                post("/register?lname=lname&fname=fname&name=name&password=password&passwordConfirm=_password&role=role")
        ));

        Map<String, Object> map = result.andReturn().getModelAndView().getModel();
        assertThat(map.get("flash")).isEqualTo("Password was not confirmed");
        assertThat(map.get("template")).isEqualTo("register");
        assertThat(result.andReturn().getModelAndView().getViewName()).isEqualTo(StaticPages.SMALL_LAYOUT);
    }

    @Test
    public void registerSaveTest3() throws Exception{
        given(userService.validateFieldsNotEmpty("lname", "fname", "name", "password", "password")).willReturn(true);
        given(userService.validatePasswords("password", "password")).willReturn(true);
        given(roleDao.getRoleByName("role")).willReturn(null);

        ResultActions result = standaloneSetup(controller).build().perform((
                post("/register?lname=lname&fname=fname&name=name&password=password&passwordConfirm=password&role=role")
        ));

        Map<String, Object> map = result.andReturn().getModelAndView().getModel();
        assertThat(map.get("flash")).isEqualTo("Role is incorrect");
        assertThat(map.get("template")).isEqualTo("register");
        assertThat(result.andReturn().getModelAndView().getViewName()).isEqualTo(StaticPages.SMALL_LAYOUT);
    }

    @Test
    public void registerSaveTest4() throws Exception{
        given(userService.validateFieldsNotEmpty("lname", "fname", "name", "password", "password")).willReturn(true);
        given(userService.validatePasswords("password", "password")).willReturn(true);
        RoleModel roleModel = mock(RoleModel.class);
        given(roleDao.getRoleByName("role")).willReturn(roleModel);

        doThrow(new RuntimeException()).when(userDao).createUser(any(UserModel.class));

        ResultActions result = standaloneSetup(controller).build().perform((
                post("/register?lname=lname&fname=fname&name=name&password=password&passwordConfirm=password&role=role")
        ));

        Map<String, Object> map = result.andReturn().getModelAndView().getModel();
        assertThat(map.get("flash")).isEqualTo("User with this name already registered");
        assertThat(map.get("template")).isEqualTo("register");
        assertThat(result.andReturn().getModelAndView().getViewName()).isEqualTo(StaticPages.SMALL_LAYOUT);
    }

    @Test
    public void registerSaveTest5() throws Exception{
        given(userService.validateFieldsNotEmpty("lname", "fname", "name", "password", "password")).willReturn(true);
        given(userService.validatePasswords("password", "password")).willReturn(true);
        RoleModel roleModel = mock(RoleModel.class);
        given(roleDao.getRoleByName("role")).willReturn(roleModel);
        given(userDetailsService.getAuthorities(any(UserModel.class))).willReturn(new LinkedList<GrantedAuthority>());

        ResultActions result = standaloneSetup(controller).build().perform((
                post("/register?lname=lname&fname=fname&name=name&password=password&passwordConfirm=password&role=role")
        ));

        Map<String, Object> map = result.andReturn().getModelAndView().getModel();
        verify(userDao).createUser(any(UserModel.class));
        assertThat(result.andReturn().getResponse().getRedirectedUrl()).isEqualTo("/");
    }

}
