package com.dataart.springtraining.models;

import com.dataart.springtraining.models.ApplicationModel;
import com.dataart.springtraining.models.RateModel;
import com.dataart.springtraining.models.RoleModel;
import com.dataart.springtraining.models.UserModel;
import com.dataart.springtraining.models.enums.RoleTypeEnum;
import org.junit.Test;

import static org.fest.assertions.Assertions.assertThat;
import static org.mockito.Mockito.mock;

public class RateModelTest {
    final long rateval = 5;
    final UserModel user = mock(UserModel.class);
    final ApplicationModel app = mock(ApplicationModel.class);
    final String id = "id";

    @Test
    public void generalTest1(){
        RateModel rate = new RateModel();
        rate.setApplication(app);
        rate.setRate(rateval);
        rate.setUser(user);
        rate.setId(id);

        assertThat(rate.getApplication()).isEqualTo(app);
        assertThat(rate.getRate()).isEqualTo(rateval);
        assertThat(rate.getId()).isEqualTo(id);
        assertThat(rate.getUser()).isEqualTo(user);
    }


    @Test
    public void rateTest2(){
        RateModel rate = new RateModel();
        rate.setApplication(app);
        rate.setRate(rateval);
        rate.setUser(user);
        rate.setId(id);

        assertThat(rate.toString()).isEqualTo("RateModel [id=id, rate=5]");
    }
}
