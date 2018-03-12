package com.dataart.springtraining.models;

import com.dataart.springtraining.models.*;
import org.junit.Before;
import org.junit.Test;

import java.util.LinkedList;
import java.util.List;

import static org.fest.assertions.Assertions.assertThat;
import static org.mockito.Mockito.mock;

public class DumpModelTest {
    LinkedList<ApplicationModel> apps;
    LinkedList<CategoryModel> cats;
    LinkedList<UserModel> users;
    LinkedList<RoleModel> roles;

    @Before
    public void setup(){
        LinkedList<ApplicationModel> apps = new LinkedList<ApplicationModel>();
        LinkedList<CategoryModel> cats = new LinkedList<CategoryModel>();
        LinkedList<UserModel> users = new LinkedList<UserModel>();
        LinkedList<RoleModel> roles = new LinkedList<RoleModel>();

        apps.add(mock(ApplicationModel.class));
        cats.add(mock(CategoryModel.class));
        users.add(mock(UserModel.class));
        roles.add(mock(RoleModel.class));
    }

    @Test
    public void generalTest1(){
        Dump dump = new Dump(null, null, null, null);

        dump.setApplications(apps);
        dump.setCategories(cats);
        dump.setRoles(roles);
        dump.setUsers(users);

        assertThat(dump.getApplications()).isEqualTo(apps);
        assertThat(dump.getCategories()).isEqualTo(cats);
        assertThat(dump.getRoles()).isEqualTo(roles);
        assertThat(dump.getUsers()).isEqualTo(users);
    }

    @Test
    public void generalTest2(){
        Dump dump = new Dump(apps, cats, users, roles);

        assertThat(dump.getApplications()).isEqualTo(apps);
        assertThat(dump.getCategories()).isEqualTo(cats);
        assertThat(dump.getRoles()).isEqualTo(roles);
        assertThat(dump.getUsers()).isEqualTo(users);
    }
}
