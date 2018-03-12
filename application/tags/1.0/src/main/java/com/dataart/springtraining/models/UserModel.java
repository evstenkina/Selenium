package com.dataart.springtraining.models;

import org.springframework.data.annotation.Id;
import org.springframework.data.annotation.PersistenceConstructor;
import org.springframework.data.mongodb.core.mapping.Document;

@Document
public class UserModel extends BasicModel {
    private String fname, lname;
    @Id
    private String name;
    private String password;

    private RoleModel roleModel;

    public UserModel(String fname, String lname, String name, String password) {
        this.fname = fname;
        this.lname = lname;
        this.name = name;
        this.password = password;
    }

    @PersistenceConstructor
    public UserModel(String fname, String lname, String name, String password, RoleModel roleModel) {
        this(fname, lname, name, password);
        this.roleModel = roleModel;
    }

    public String getFname() {
        return fname;
    }

    public void setFname(String fname) {
        this.fname = fname;
    }

    public String getLname() {
        return lname;
    }

    public void setLname(String lname) {
        this.lname = lname;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public RoleModel getRoleModel() {
        return roleModel;
    }

    public void setRoleModel(RoleModel roleModel) {
        this.roleModel = roleModel;
    }

    @Override
    public String toString() {
        return "UserModel [fname=" + fname + ", lname=" + lname + "]";
    }
}