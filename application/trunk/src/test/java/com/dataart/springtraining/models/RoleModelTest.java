package com.dataart.springtraining.models;

import com.dataart.springtraining.models.RoleModel;
import com.dataart.springtraining.models.UserModel;
import com.dataart.springtraining.models.enums.RoleTypeEnum;
import org.junit.Test;

import static org.fest.assertions.Assertions.assertThat;

public class RoleModelTest {
    final String name = "name";
    final String title = "title";
    final String id = "id";

    @Test
    public void roleModelTest1(){
        RoleModel role = new RoleModel(name, title);

        assertThat(role.getName()).isEqualTo(name);
        assertThat(role.getTitle()).isEqualTo(title);
    }

    @Test
    public void roleModelTest2(){
        RoleModel role = new RoleModel(RoleTypeEnum.DEVELOPER.toString(), title);
        assertThat(role.isDeveloper()).isTrue();
    }

    @Test
    public void roleModelTest3(){
        RoleModel role = new RoleModel(RoleTypeEnum.USER.toString(), title);
        assertThat(role.isDeveloper()).isFalse();
    }

    @Test
    public void roleModelTest4(){
        RoleModel role = new RoleModel(null, null);
        role.setId(id);
        role.setName(name);
        role.setTitle(title);

        assertThat(role.getId()).isEqualTo(id);
        assertThat(role.getName()).isEqualTo(name);
        assertThat(role.getTitle()).isEqualTo(title);
    }

    @Test
    public void roleModelTest5(){
        RoleModel role = new RoleModel(name, title);
        assertThat(role.toString()).isEqualTo("RoleModel [title=title,name=name]");
    }
}
