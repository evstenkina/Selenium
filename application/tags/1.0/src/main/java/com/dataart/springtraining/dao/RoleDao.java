package com.dataart.springtraining.dao;

import java.util.List;

import com.dataart.springtraining.models.RoleModel;
import org.springframework.data.mongodb.core.query.Criteria;
import org.springframework.data.mongodb.core.query.Query;
import org.springframework.stereotype.Component;

@Component
public class RoleDao extends BasicDao{

    public void createRole(RoleModel role){
        mongoOperations.insert(role);
    }
	
    public RoleModel getRoleByName(String name) {
        return mongoOperations.findOne(Query.query(Criteria.where("name").is(name)), RoleModel.class);
    }

    public RoleModel getRoleById(String id) {
        return mongoOperations.findById(id, RoleModel.class);
    }
    
    public List <RoleModel> getRoles() {
        return mongoOperations.findAll(RoleModel.class);
    }
}
