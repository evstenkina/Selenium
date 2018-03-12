package com.dataart.springtraining.models;

import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

@Document
public class CategoryModel extends BasicModel {
    private String title;
    @Id
    private String id;

    public CategoryModel(String title) {
        this.title = title;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    @Override
    public String toString() {
        return "CategoryModel[title=" + title + ",id=" + id + "]";
    }

}
