package com.dataart.springtraining.service;

import com.dataart.springtraining.dao.UserDao;
import org.junit.Test;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContext;
import org.springframework.security.core.context.SecurityContextHolder;

import static org.fest.assertions.Assertions.assertThat;
import static org.fest.reflect.core.Reflection.field;
import static org.mockito.BDDMockito.given;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.verify;

public class UserServiceTest {

    UserService service = new UserService();

    @Test
    public void validatePasswordsTest(){
        assertThat(service.validatePasswords("password", "password")).isTrue();
        assertThat(service.validatePasswords("password", "notpassword")).isFalse();
    }

    @Test
    public void validateFieldsNotEmptyTest(){
        assertThat(service.validateFieldsNotEmpty("", "", "", "", "")).isFalse();
        assertThat(service.validateFieldsNotEmpty("a", "b", "c", "d", "")).isFalse();
        assertThat(service.validateFieldsNotEmpty("a", "b", "c", "", "e")).isFalse();
        assertThat(service.validateFieldsNotEmpty("a", "b", "", "d", "e")).isFalse();
        assertThat(service.validateFieldsNotEmpty("a", "", "c", "d", "e")).isFalse();
        assertThat(service.validateFieldsNotEmpty("", "b", "c", "d", "e")).isFalse();
        assertThat(service.validateFieldsNotEmpty("a", "b", "c", "d", "e")).isTrue();
    }

    @Test
    public void getAuthenticatedUserTest(){
        String name = "name";
        SecurityContext context = mock(SecurityContext.class);
        Authentication auth = mock(Authentication.class);
        UserDao userDao = mock(UserDao.class);
        UtilService utilService = mock(UtilService.class);

        given(utilService.getContext()).willReturn(context);
        given(context.getAuthentication()).willReturn(auth);
        given(auth.getName()).willReturn(name);

        field("userDao").ofType(UserDao.class).in(service).set(userDao);
        field("utilService").ofType(UtilService.class).in(service).set(utilService);

        service.getAuthenticatedUser();

        verify(userDao).getUserByName(name);
    }

}