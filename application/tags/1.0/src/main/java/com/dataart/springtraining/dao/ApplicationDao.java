package com.dataart.springtraining.dao;

import java.util.List;

import com.dataart.springtraining.models.ApplicationModel;
import com.dataart.springtraining.models.CategoryModel;
import com.dataart.springtraining.models.UserModel;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.data.mongodb.core.query.Criteria;
import org.springframework.data.mongodb.core.query.Order;
import org.springframework.data.mongodb.core.query.Query;
import org.springframework.data.mongodb.core.query.Update;
import org.springframework.stereotype.Component;

@Component
public class ApplicationDao extends BasicDao {

    public ApplicationModel getApplication(String title) {
        return mongoOperations.findById(title, ApplicationModel.class);
    }

    public List<ApplicationModel> getAllApplications(){
        return mongoOperations.findAll(ApplicationModel.class);
    }

    public List<ApplicationModel> getApplications(UserModel user, CategoryModel categoryModel) {
        if (user == null){
            if (categoryModel == null ){
                return mongoOperations.findAll(ApplicationModel.class);
            } else {
                return mongoOperations.find(
                        Query.query(Criteria.where("category").is(categoryModel)),
                                ApplicationModel.class);
            }
        } else {
            return mongoOperations.find(
                Query.query(Criteria.where("author").is(user)), ApplicationModel.class);
        }
    }

    @CacheEvict(value = "mostPopular", allEntries = true)
    public ApplicationModel createApplication(ApplicationModel applicationModel) {
        applicationModel.setNumberOfDownloads(0);
        applicationModel.setUploadedTimeStamp(System.currentTimeMillis());
        mongoOperations.insert(applicationModel);
        return mongoOperations.findById(applicationModel.getTitle(), ApplicationModel.class);
    }

    @CacheEvict(value = "mostPopular", allEntries = true)
    public ApplicationModel getBytesAndUpdateDownloadsNumber(String id) {
        ApplicationModel applicationModel = mongoOperations.findById(id, ApplicationModel.class);
        applicationModel.setNumberOfDownloads(applicationModel.getNumberOfDownloads() + 1);

        mongoOperations.updateFirst(Query.query(Criteria.where("title").is(applicationModel.getTitle())), Update.update("numberOfDownloads", applicationModel.getNumberOfDownloads()), ApplicationModel.class);
        return applicationModel;
    }

    @CacheEvict(value = "mostPopular", allEntries = true)
    public void delete(ApplicationModel applicationModel) {
        mongoOperations.remove(applicationModel);
    }

    @CacheEvict(value = "mostPopular", allEntries = true)
    public void updateApplication(ApplicationModel applicationModel) {
        mongoOperations.updateFirst(Query.query(Criteria.where("title").is(applicationModel.getTitle())), Update.update("description", applicationModel.getDescription()), ApplicationModel.class);
        mongoOperations.updateFirst(Query.query(Criteria.where("title").is(applicationModel.getTitle())), Update.update("category", applicationModel.getCategory()), ApplicationModel.class);
    }

    @Cacheable("mostPopular")
    public List<ApplicationModel> getMostPopular() {
        Query query = Query.query(
                Criteria.where("numberOfDownloads").gt(0));
        query.sort().on("numberOfDownloads", Order.DESCENDING).on("uploadedTimeStamp", Order.DESCENDING);
        return mongoOperations.find(query, ApplicationModel.class);
    }
}
