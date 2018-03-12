package com.dataart.springtraining.service;

import com.dataart.springtraining.dao.UserDao;
import com.dataart.springtraining.models.RoleModel;
import com.dataart.springtraining.models.UserModel;
import com.dataart.springtraining.models.enums.RoleTypeEnum;
import com.dataart.springtraining.models.enums.SimpleGrantedAuthorityEnum;
import org.junit.Test;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UsernameNotFoundException;

import static org.fest.assertions.Assertions.assertThat;
import static org.fest.reflect.core.Reflection.field;
import static org.mockito.BDDMockito.given;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.verify;

public class CustomUserDetailsServiceTest {

    CustomUserDetailsService service = new CustomUserDetailsService();

    @Test
    public void getAuthoritiesTest(){
        UserModel userModel = mock(UserModel.class);
        RoleModel userRole = mock(RoleModel.class);
        given(userRole.getName()).willReturn(RoleTypeEnum.USER.toString());
        given(userModel.getRoleModel()).willReturn(userRole);

        assertThat(service.getAuthorities(userModel).size()).isEqualTo(1);
        assertThat(((GrantedAuthority)(service.getAuthorities(userModel).toArray()[0])).getAuthority()).isEqualTo(SimpleGrantedAuthorityEnum.ROLE_USER.toString());
    }

    @Test
    public void getAuthorities2Test(){
        UserModel userModel = mock(UserModel.class);
        RoleModel devRole = mock(RoleModel.class);
        given(devRole.isDeveloper()).willReturn(true);
        given(userModel.getRoleModel()).willReturn(devRole);

        assertThat(service.getAuthorities(userModel).size()).isEqualTo(2);
        assertThat(((GrantedAuthority)(service.getAuthorities(userModel).toArray()[0])).getAuthority()).isEqualTo(SimpleGrantedAuthorityEnum.ROLE_USER.toString());
        assertThat(((GrantedAuthority)(service.getAuthorities(userModel).toArray()[1])).getAuthority()).isEqualTo(SimpleGrantedAuthorityEnum.ROLE_DEVELOPER.toString());
    }

    @Test
    public void loadUserByUsernameTest(){
        UserDao userDao = mock(UserDao.class);
        String username = "user";
        RoleModel role = new RoleModel(RoleTypeEnum.DEVELOPER.toString(), "title");
        UserModel user = new UserModel("1", "2", username, "4", role);
        field("userDao").ofType(UserDao.class).in(service).set(userDao);

        given(userDao.getUserByName(username)).willReturn(user);

        UserDetails result = service.loadUserByUsername(username);

        verify(userDao).getUserByName(username);

        assertThat(result.getPassword()).isEqualTo("4");
        assertThat(result.getUsername()).isEqualTo(username);
        assertThat(result.getAuthorities().size()).isEqualTo(service.getAuthorities(user).size());
    }

    @Test(expected = UsernameNotFoundException.class)
    public void loadUserByUsernameTest2() throws UsernameNotFoundException{
        UserDao userDao = mock(UserDao.class);
        String username = "username";
        given(userDao.getUserByName(username)).willReturn(null);
        field("userDao").ofType(UserDao.class).in(service).set(userDao);

        service.loadUserByUsername(username);
    }
}