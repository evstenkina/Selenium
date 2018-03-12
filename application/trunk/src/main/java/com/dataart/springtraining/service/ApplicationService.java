package com.dataart.springtraining.service;

import com.dataart.springtraining.dao.ApplicationDao;
import com.dataart.springtraining.dao.CategoryDao;
import com.dataart.springtraining.models.UserModel;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.ui.Model;

@Service
public class ApplicationService {

    @Autowired
    CategoryDao categoryDao;

    @Autowired
    ApplicationDao applicationDao;

    public Model getApplicationsForCategory(Model model, String categoryId){
        model.addAttribute("categories", categoryDao.getCategories());
        model.addAttribute("apps", applicationDao.getApplications(null, categoryDao.getCategory(categoryId)));
        return model;
    }

    public Model getApplicationsForUser(Model model, UserModel userModel){
        model.addAttribute("apps", applicationDao.getApplications(userModel, null));
        return model;
    }

    public Model getModelForEdit(Model model, String title){
        model.addAttribute("categories", categoryDao.getCategories());
        model.addAttribute("application", applicationDao.getApplication(title));
        return model;
    }
}
