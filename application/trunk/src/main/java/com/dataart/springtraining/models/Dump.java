package com.dataart.springtraining.models;


import java.util.List;

public class Dump {
    List<ApplicationModel> applications;
    List<CategoryModel> categories;
    List<UserModel> users;
    List<RoleModel> roles;

    public Dump(List<ApplicationModel> applications,
                List<CategoryModel> categories,
                List<UserModel> users,
                List<RoleModel> roles) {
        this.applications = applications;
        this.categories = categories;
        this.users = users;
        this.roles = roles;
    }

    public List<ApplicationModel> getApplications() {
        return applications;
    }

    public void setApplications(List<ApplicationModel> applications) {
        this.applications = applications;
    }

    public List<CategoryModel> getCategories() {
        return categories;
    }

    public void setCategories(List<CategoryModel> categories) {
        this.categories = categories;
    }

    public List<UserModel> getUsers() {
        return users;
    }

    public void setUsers(List<UserModel> users) {
        this.users = users;
    }

    public List<RoleModel> getRoles() {
        return roles;
    }

    public void setRoles(List<RoleModel> roles) {
        this.roles = roles;
    }
}
