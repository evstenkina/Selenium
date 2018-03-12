package com.dataart.springtraining.dao;

import com.dataart.springtraining.models.UserModel;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.mongodb.core.query.Criteria;
import org.springframework.data.mongodb.core.query.Query;
import org.springframework.data.mongodb.core.query.Update;
import org.springframework.stereotype.Component;
import com.dataart.springtraining.service.UtilService;

import java.util.List;

@Component
public class UserDao extends BasicDao {

    @Autowired
    UtilService utilService;

    public UserModel getUserByName(String name) {
        return mongoOperations.findOne(Query.query(Criteria.where("name").is(name)), UserModel.class);
    }

    public void createUser(UserModel userModel) {
        userModel.setPassword(utilService.encodePassword(userModel.getPassword()));
        mongoOperations.insert(userModel);
    }

    public void updateUser(UserModel userModel) {
        userModel.setPassword(utilService.encodePassword(userModel.getPassword()));
        mongoOperations.updateFirst(Query.query(Criteria.where("name").is(userModel.getName())), Update.update("fname", userModel.getFname()), UserModel.class);
        mongoOperations.updateFirst(Query.query(Criteria.where("name").is(userModel.getName())), Update.update("lname", userModel.getLname()), UserModel.class);
        mongoOperations.updateFirst(Query.query(Criteria.where("name").is(userModel.getName())), Update.update("password", userModel.getPassword()), UserModel.class);
    }

    public int getCount() {
        return mongoOperations.findAll(UserModel.class).size();
    }

    public List<UserModel> getUsers(){
        return mongoOperations.findAll(UserModel.class);
    }
}
