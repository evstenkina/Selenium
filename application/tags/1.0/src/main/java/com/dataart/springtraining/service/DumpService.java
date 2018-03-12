package com.dataart.springtraining.service;

import com.dataart.springtraining.dao.ApplicationDao;
import com.dataart.springtraining.dao.CategoryDao;
import com.dataart.springtraining.dao.RoleDao;
import com.dataart.springtraining.dao.UserDao;
import com.dataart.springtraining.models.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class DumpService {
    @Autowired
    ApplicationDao applicationDao;

    @Autowired
    RoleDao roleDao;

    @Autowired
    UserDao userDao;

    @Autowired
    CategoryDao categoryDao;

    public Dump getDump(){
        return new Dump(
                applicationDao.getAllApplications(),
                categoryDao.getCategories(),
                userDao.getUsers(),
                roleDao.getRoles());
    }
}
