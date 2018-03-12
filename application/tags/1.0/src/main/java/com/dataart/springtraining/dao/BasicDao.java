package com.dataart.springtraining.dao;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.mongodb.core.MongoOperations;

public abstract class BasicDao {
    @Autowired
    MongoOperations mongoOperations;
}
