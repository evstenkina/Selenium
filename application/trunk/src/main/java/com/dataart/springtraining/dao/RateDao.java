package com.dataart.springtraining.dao;

import java.util.List;

import com.dataart.springtraining.models.ApplicationModel;
import com.dataart.springtraining.models.RateModel;
import com.dataart.springtraining.models.UserModel;
import com.dataart.springtraining.service.UtilService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.mongodb.core.query.Criteria;
import org.springframework.data.mongodb.core.query.Query;
import org.springframework.stereotype.Component;

@Component
public class RateDao extends BasicDao {

    @Autowired
    UtilService utilService;

    public void rateApplication(UserModel userModel, ApplicationModel application, long rate) {
        RateModel rateModel = new RateModel();
        rateModel.setApplication(application);
        rateModel.setUser(userModel);
        rateModel.setRate(rate);
        mongoOperations.insert(rateModel);
    }

    public void clearApplicationRate(UserModel user, ApplicationModel application) {
        mongoOperations.remove(Query.query(Criteria.where("userModel").is(user).and("applicationModel").is(application)));
    }

    public double getApplicationAvgRate(ApplicationModel application) {
        List<RateModel> list = mongoOperations.find(Query.query(Criteria.where("applicationModel").is(application)), RateModel.class);
        long sum = 0;
        for (RateModel rate : list) {
            sum += rate.getRate();
        }
        return utilService.getAvg(list.size(), sum);
    }

    public long getRate(UserModel user, ApplicationModel application) {
        RateModel rate = mongoOperations.findOne(Query.query(Criteria.where("userModel").is(user).and("applicationModel").is(application)), RateModel.class);
        if (rate == null) {
            return 0;
        } else {
            return rate.getRate();
        }
    }
}
