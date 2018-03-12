package com.dataart.springtraining.service;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

import com.dataart.springtraining.models.enums.SimpleGrantedAuthorityEnum;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.core.userdetails.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import com.dataart.springtraining.dao.UserDao;
import com.dataart.springtraining.models.UserModel;

@Service
public class CustomUserDetailsService implements UserDetailsService {
	
	@Autowired	
	private UserDao userDao;

	public UserDetails loadUserByUsername(String username)
			throws UsernameNotFoundException {
		
		UserDetails user;
		UserModel userModel = userDao.getUserByName(username);
		
		if (userModel == null){
			throw new UsernameNotFoundException("User not found");
        }
		user = new User(
				userModel.getName(),
				userModel.getPassword(),
				true,true,true,true,
				getAuthorities(userModel));
		return user;
	}
	
	public Collection<GrantedAuthority>getAuthorities(UserModel user){
		List<GrantedAuthority> authList = new ArrayList<GrantedAuthority>(2);
		authList.add(new SimpleGrantedAuthority(SimpleGrantedAuthorityEnum.ROLE_USER.toString()));
		if (user.getRoleModel().isDeveloper()){
			authList.add(new SimpleGrantedAuthority(SimpleGrantedAuthorityEnum.ROLE_DEVELOPER.toString()));
		}
		return authList;
	}
}
