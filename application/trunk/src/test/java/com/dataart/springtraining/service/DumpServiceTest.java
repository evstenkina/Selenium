package com.dataart.springtraining.service;

import com.dataart.springtraining.dao.ApplicationDao;
import com.dataart.springtraining.dao.CategoryDao;
import com.dataart.springtraining.dao.RoleDao;
import com.dataart.springtraining.dao.UserDao;
import org.junit.Test;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContext;

import static org.fest.assertions.Assertions.assertThat;
import static org.fest.reflect.core.Reflection.field;
import static org.mockito.BDDMockito.given;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.verify;

public class DumpServiceTest {

    DumpService service = new DumpService();

    @Test
    public void getDumpTest(){
        ApplicationDao applicationDao = mock(ApplicationDao.class);
        RoleDao roleDao = mock(RoleDao.class);
        UserDao userDao = mock(UserDao.class);
        CategoryDao categoryDao = mock(CategoryDao.class);

        field("applicationDao").ofType(ApplicationDao.class).in(service).set(applicationDao);
        field("roleDao").ofType(RoleDao.class).in(service).set(roleDao);
        field("userDao").ofType(UserDao.class).in(service).set(userDao);
        field("categoryDao").ofType(CategoryDao.class).in(service).set(categoryDao);

        service.getDump();

        verify(userDao).getUsers();
        verify(applicationDao).getAllApplications();
        verify(categoryDao).getCategories();
        verify(roleDao).getRoles();
    }
}