package com.dataart.springtraining.models;

import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

@Document
public class ApplicationModel extends BasicModel{
    @Id
    private String title;
    private String description;
    private CategoryModel category;
    private UserModel author;
    private long numberOfDownloads;
    private long uploadedTimeStamp;
    private byte[] imageData = null;
    private byte[] iconData = null;

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public long getUploadedTimeStamp() {
        return uploadedTimeStamp;
    }

    public void setUploadedTimeStamp(long uploadedTimeStamp) {
        this.uploadedTimeStamp = uploadedTimeStamp;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public CategoryModel getCategory() {
        return category;
    }

    public void setCategory(CategoryModel category) {
        this.category = category;
    }

    public UserModel getAuthor() {
        return author;
    }

    public void setAuthor(UserModel author) {
        this.author = author;
    }

    public long getNumberOfDownloads() {
        return numberOfDownloads;
    }

    public void setNumberOfDownloads(long numberOfDownloads) {
        this.numberOfDownloads = numberOfDownloads;
    }

    public byte[] getImageData() {
        return imageData;
    }

    public void setImageData(byte[] imageData) {
        this.imageData = imageData;
    }

    public byte[] getIconData() {
        return iconData;
    }

    public void setIconData(byte[] iconData) {
        this.iconData = iconData;
    }

    @Override
    public String toString() {
        return "ApplicationModel[title=" + title + "]";
    }
}
