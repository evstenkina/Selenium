package com.dataart.springtraining.models;

import com.dataart.springtraining.models.enums.RoleTypeEnum;
import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.index.Indexed;
import org.springframework.data.mongodb.core.mapping.Document;

@Document
public class RoleModel extends BasicModel {

    private String title;
    @Indexed
    private String name;

    public boolean isDeveloper() {
        return name.equals(RoleTypeEnum.DEVELOPER.toString());
    }

    @Id
    private String id;

    public RoleModel(String name, String title) {
        this.title = title;
        this.name = name;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    @Override
    public String toString() {
        return "RoleModel [title=" + title + ",name=" + name + "]";
    }
}
