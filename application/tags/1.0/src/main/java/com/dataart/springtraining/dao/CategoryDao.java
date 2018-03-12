package com.dataart.springtraining.dao;

import java.util.List;

import com.dataart.springtraining.models.CategoryModel;
import org.springframework.stereotype.Component;

@Component
public class CategoryDao extends BasicDao {

    public void createCategory(CategoryModel categoryModel) {
        mongoOperations.insert(categoryModel);
    }

    public CategoryModel getCategory(String id) {
        return mongoOperations.findById(id, CategoryModel.class);
    }

    public List<CategoryModel> getCategories() {
        return mongoOperations.findAll(CategoryModel.class);
    }
}
