package com.dataart.springtraining.models;

import com.dataart.springtraining.models.*;
import org.junit.Before;
import org.junit.Test;

import java.util.LinkedList;

import static org.fest.assertions.Assertions.assertThat;
import static org.mockito.Mockito.mock;

public class CategoryModelTest {
    String id = "id";
    String title = "title";

    @Test
    public void generalTest1(){
        CategoryModel categoryModel = new CategoryModel(title);
        assertThat(categoryModel.getTitle()).isEqualTo(title);
    }

    @Test
    public void generalTest2(){
        CategoryModel categoryModel = new CategoryModel(null);
        categoryModel.setTitle(title);
        categoryModel.setId(id);

        assertThat(categoryModel.getTitle()).isEqualTo(title);
        assertThat(categoryModel.getId()).isEqualTo(id);
    }

    @Test
    public void generalTest3(){
        CategoryModel categoryModel = new CategoryModel(null);
        categoryModel.setTitle(title);
        categoryModel.setId(id);

        assertThat(categoryModel.toString()).isEqualTo("CategoryModel[title=title,id=id]");
    }
}
