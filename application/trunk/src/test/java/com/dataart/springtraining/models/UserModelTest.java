package com.dataart.springtraining.models;

import com.dataart.springtraining.models.RoleModel;
import com.dataart.springtraining.models.UserModel;
import org.junit.Test;

import static org.fest.assertions.Assertions.assertThat;

public class UserModelTest {
    final String fname = "fname";
    final String lname = "lname";
    final String name = "name";
    final String password = "password";
    final RoleModel role = new RoleModel("rname", "rtitle");

    @Test
    public void userModelTest1(){
        UserModel user = new UserModel(fname,lname, name,password);

        assertThat(user.getName()).isEqualTo(name);
        assertThat(user.getFname()).isEqualTo(fname);
        assertThat(user.getLname()).isEqualTo(lname);
        assertThat(user.getPassword()).isEqualTo(password);
    }

    @Test
    public void userModelTest11(){
        UserModel user = new UserModel(fname,lname, name,password, role);

        assertThat(user.getName()).isEqualTo(name);
        assertThat(user.getFname()).isEqualTo(fname);
        assertThat(user.getLname()).isEqualTo(lname);
        assertThat(user.getPassword()).isEqualTo(password);
        assertThat(user.getRoleModel()).isEqualTo(role);
    }

    @Test
    public void userModelTest2(){
        UserModel user = new UserModel(null, null, null, null);
        user.setFname(fname);
        user.setLname(lname);
        user.setPassword(password);
        user.setName(name);
        user.setRoleModel(role);

        assertThat(user.getName()).isEqualTo(name);
        assertThat(user.getFname()).isEqualTo(fname);
        assertThat(user.getLname()).isEqualTo(lname);
        assertThat(user.getPassword()).isEqualTo(password);
        assertThat(user.getRoleModel()).isEqualTo(role);
    }

    @Test
    public void userModelTest3(){
        UserModel user = new UserModel(fname,lname, name,password);
        assertThat(user.toString()).isEqualTo("UserModel [fname=fname, lname=lname]");
    }
}
