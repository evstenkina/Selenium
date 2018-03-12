package com.dataart.springtraining.db;

import com.dataart.springtraining.dao.ApplicationDao;
import com.dataart.springtraining.dao.CategoryDao;
import com.dataart.springtraining.dao.RoleDao;
import com.dataart.springtraining.dao.UserDao;
import com.dataart.springtraining.models.*;
import com.dataart.springtraining.models.enums.RoleTypeEnum;
import org.springframework.beans.factory.annotation.Autowired;

public class Boot {

    @Autowired
    UserDao userDao;

    @Autowired
    RoleDao roleDao;

    @Autowired
    CategoryDao categoryDao;

    @Autowired
    ApplicationDao applicationDao;

    public Boot(){}

    public void create() {
        if (roleDao.getRoleByName(RoleTypeEnum.DEVELOPER.toString()) != null) {
            return;
        }
        RoleModel devRole = new RoleModel(RoleTypeEnum.DEVELOPER.toString(), RoleTypeEnum.DEVELOPER.toString());
        RoleModel userRole = new RoleModel(RoleTypeEnum.USER.toString(), RoleTypeEnum.USER.toString());
        roleDao.createRole(devRole);
        roleDao.createRole(userRole);

        UserModel devUser = new UserModel("Ivan", "Petrov", "admin", "admin", devRole);
        userDao.createUser(devUser);

        CategoryModel infoCategory = new CategoryModel("Information");
        CategoryModel funCategory = new CategoryModel("Fun");
        CategoryModel mapsCategory = new CategoryModel("Maps");
        CategoryModel gamesCategory = new CategoryModel("Games");
        CategoryModel newsCategory = new CategoryModel("News");
        CategoryModel devCategory = new CategoryModel("Development");

        categoryDao.createCategory(infoCategory);
        categoryDao.createCategory(funCategory);
        categoryDao.createCategory(mapsCategory);
        categoryDao.createCategory(gamesCategory);
        categoryDao.createCategory(newsCategory);
        categoryDao.createCategory(devCategory);

        CategoryModel[] categories = new CategoryModel[] {infoCategory, funCategory, mapsCategory, gamesCategory, newsCategory, devCategory};

        for (int i = 0 ; i < categories.length; i ++) {
            for (int j = 0 ; j < Math.round(Math.random() * 4) + 2; j ++) {
                String title;
                ApplicationModel applicationModel = new ApplicationModel();
                applicationModel.setTitle(title = "Application " + categories[i].getTitle() + " " + j);
                applicationModel.setCategory(categories[i]);
                applicationModel.setAuthor(devUser);
                applicationModel.setDescription("Just a sample description for this application [" + title + "]");
                applicationDao.createApplication(applicationModel);
            }
        }
    }
}
