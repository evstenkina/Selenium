package com.dataart.springtraining.models;

import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

@Document
public class RateModel extends BasicModel{
    @Id
    private String id;
    private UserModel user;
    private long rate;
    private ApplicationModel application;

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public UserModel getUser() {
        return user;
    }

    public void setUser(UserModel user) {
        this.user = user;
    }

    public long getRate() {
        return rate;
    }

    public void setRate(long rate) {
        this.rate = rate;
    }

    public ApplicationModel getApplication() {
        return application;
    }

    public void setApplication(ApplicationModel application) {
        this.application = application;
    }

    @Override
    public String toString() {
        return "RateModel [id=" + id + ", rate=" + rate + "]";
    }

}