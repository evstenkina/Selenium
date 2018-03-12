package com.dataart.springtraining.service;

import org.junit.Before;
import org.junit.Test;
import org.springframework.security.authentication.encoding.Md5PasswordEncoder;

import static org.fest.assertions.Assertions.assertThat;
import static org.fest.reflect.core.Reflection.field;
import static org.mockito.BDDMockito.given;
import static org.mockito.Mockito.mock;

public class UtilServiceTest {

    UtilService service = new UtilService();
    Md5PasswordEncoder encoder;

    @Before
    public void setup(){
        encoder = mock(Md5PasswordEncoder.class);
        field("passwordEncoder").ofType(Md5PasswordEncoder.class).in(service).set(encoder);
    }

    @Test
    public void getAvgTest(){
        assertThat(service.getAvg(2,10)).isEqualTo(5.0);
        assertThat(service.getAvg(10,0)).isEqualTo(0.0);
        assertThat(service.getAvg(0,10)).isEqualTo(0.0);
    }

    @Test
    public void encodeTest(){
        String password = "password";
        String encodedPassword = "encoded password";
        given(encoder.encodePassword(password, null)).willReturn(encodedPassword);
        assertThat(service.encodePassword(password)).isEqualTo(encodedPassword);
    }
}