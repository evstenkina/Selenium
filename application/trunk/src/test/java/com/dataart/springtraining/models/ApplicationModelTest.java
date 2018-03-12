package com.dataart.springtraining.models;

import com.dataart.springtraining.models.ApplicationModel;
import com.dataart.springtraining.models.CategoryModel;
import com.dataart.springtraining.models.UserModel;
import org.junit.Before;
import org.junit.Test;

import static org.fest.assertions.Assertions.assertThat;
import static org.mockito.Mockito.mock;

public class ApplicationModelTest {
    String title = "title";
    String desc = "description";
    CategoryModel cat;
    UserModel user;
    long number = 1;
    long time = 2;

    @Before
    public void setup(){
        cat = mock(CategoryModel.class);
        user = mock(UserModel.class);
    }

    @Test
    public void generalTest1(){
        ApplicationModel app = new ApplicationModel();
        app.setUploadedTimeStamp(time);
        app.setTitle(title);
        app.setDescription(desc);
        app.setAuthor(user);
        app.setCategory(cat);
        app.setNumberOfDownloads(number);

        assertThat(app.getAuthor()).isEqualTo(user);
        assertThat(app.getCategory()).isEqualTo(cat);
        assertThat(app.getTitle()).isEqualTo(title);
        assertThat(app.getDescription()).isEqualTo(desc);
        assertThat(app.getUploadedTimeStamp()).isEqualTo(time);
        assertThat(app.getNumberOfDownloads()).isEqualTo(number);
    }

    @Test
    public void generalTest2(){
        ApplicationModel app = new ApplicationModel();
        app.setUploadedTimeStamp(time);
        app.setTitle(title);
        app.setDescription(desc);
        app.setAuthor(user);
        app.setCategory(cat);
        app.setNumberOfDownloads(number);

        assertThat(app.toString()).isEqualTo("ApplicationModel[title=title]");
    }
}
