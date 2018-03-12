package com.dataart.springtraining.controllers.authentication;

import com.dataart.springtraining.models.enums.StaticPages;
import org.junit.Test;
import org.springframework.test.web.server.ResultActions;

import java.util.Map;

import static org.fest.assertions.Assertions.assertThat;
import static org.springframework.test.web.server.setup.MockMvcBuilders.standaloneSetup;
import static org.springframework.test.web.server.request.MockMvcRequestBuilders.get;

public class LoginLogoutControllerTest {
    LoginLogoutController controller = new LoginLogoutController();

    @Test
    public void loginOkPage() throws Exception{
        ResultActions result = standaloneSetup(controller).build().perform((get("/auth/login")));
        Map<String, Object> map = result.andReturn().getModelAndView().getModel();
        assertThat(map.get("flash")).isNull();
        assertThat(map.get("template")).isEqualTo("secLoginPage");
        assertThat(result.andReturn().getModelAndView().getViewName()).isEqualTo(StaticPages.SMALL_LAYOUT);
    }

    @Test
    public void loginOkPage2() throws Exception{
        ResultActions result = standaloneSetup(controller).build().perform((get("/auth/login?error=false")));
        Map<String, Object> map = result.andReturn().getModelAndView().getModel();
        assertThat(map.get("flash")).isNull();
        assertThat(map.get("template")).isEqualTo("secLoginPage");
        assertThat(result.andReturn().getModelAndView().getViewName()).isEqualTo(StaticPages.SMALL_LAYOUT);
    }

    @Test
    public void loginFailedPage() throws Exception{
        ResultActions result = standaloneSetup(controller).build().perform((get("/auth/login?error=true")));
        Map<String, Object> map = result.andReturn().getModelAndView().getModel();
        assertThat(map.get("flash")).isEqualTo("You have entered an invalid username or password!");
        assertThat(map.get("template")).isEqualTo("secLoginPage");
        assertThat(result.andReturn().getModelAndView().getViewName()).isEqualTo(StaticPages.SMALL_LAYOUT);
    }

    @Test
    public void deniedPage() throws Exception{
        ResultActions result = standaloneSetup(controller).build().perform((get("/auth/denied")));
        assertThat(result.andReturn().getModelAndView().getViewName()).isEqualTo(StaticPages.SEC_DENIED_PAGE);
    }
}
