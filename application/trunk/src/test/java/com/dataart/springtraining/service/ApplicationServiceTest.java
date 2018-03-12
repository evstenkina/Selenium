package com.dataart.springtraining.service;

import com.dataart.springtraining.dao.ApplicationDao;
import com.dataart.springtraining.dao.CategoryDao;
import com.dataart.springtraining.models.ApplicationModel;
import com.dataart.springtraining.models.CategoryModel;
import com.dataart.springtraining.models.UserModel;
import org.junit.Before;
import org.junit.Test;
import org.springframework.ui.Model;

import java.util.Collection;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;

import static org.fest.reflect.core.Reflection.field;
import static org.mockito.BDDMockito.given;
import static org.mockito.Matchers.any;
import static org.mockito.Matchers.eq;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.verify;

public class ApplicationServiceTest {
    CategoryDao categoryDao;
    ApplicationDao applicationDao;
    ApplicationService service;
    Model model;

    @Before
    public void setup(){
        service = new ApplicationService();
        categoryDao = mock(CategoryDao.class);
        applicationDao = mock(ApplicationDao.class);
        model = mock(Model.class);
        field("categoryDao").ofType(CategoryDao.class).in(service).set(categoryDao);
        field("applicationDao").ofType(ApplicationDao.class).in(service).set(applicationDao);
    }

    @Test
    public void getApplicationsForCategoryTest(){
        CategoryModel categoryModel = new CategoryModel("title");
        given(categoryDao.getCategory("category")).willReturn(categoryModel);
        service.getApplicationsForCategory(model, "category");
        verify(categoryDao).getCategories();
        verify(categoryDao).getCategory("category");
        verify(applicationDao).getApplications(null, categoryModel);
        verify(model).addAttribute(eq("categories"), any(Object.class));
        verify(model).addAttribute(eq("apps"), any(LinkedList.class));
    }

    @Test
    public void getApplicationsForUserTest(){
        UserModel userModel = mock(UserModel.class);
        given(applicationDao.getApplications(userModel, null)).willReturn(new LinkedList<ApplicationModel>());
        service.getApplicationsForUser(model, userModel);
        verify(applicationDao).getApplications(userModel, null);
        verify(model).addAttribute(eq("apps"), any(LinkedList.class));
    }

    @Test
    public void getModelForEditTest(){
        given(applicationDao.getApplication("title")).willReturn(mock(ApplicationModel.class));
        service.getModelForEdit(model, "title");
        verify(categoryDao).getCategories();
        verify(applicationDao).getApplication("title");
        verify(model).addAttribute(eq("categories"), any(LinkedList.class));
        verify(model).addAttribute(eq("application"), any(Object.class));

    }
}


