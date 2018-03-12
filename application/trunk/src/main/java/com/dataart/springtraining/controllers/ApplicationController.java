package com.dataart.springtraining.controllers;

import com.dataart.springtraining.models.ApplicationModel;
import com.dataart.springtraining.models.enums.MediaTypes;
import com.dataart.springtraining.models.enums.StaticPages;
import com.dataart.springtraining.service.ApplicationService;
import com.dataart.springtraining.service.ImageService;
import org.apache.commons.io.IOUtils;
import org.apache.commons.lang.StringUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.util.FileCopyUtils;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.multipart.MultipartFile;
import org.springframework.web.servlet.ModelAndView;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

@Controller
public class ApplicationController extends BasicController{

    @Autowired
    ImageService imageService;

    @Autowired
    ApplicationService applicationService;

    @RequestMapping(value = "/icon", method = RequestMethod.GET)
    public ModelAndView getIcon(@RequestParam("id") String title, HttpServletResponse response, HttpServletRequest request) throws Exception{
        ApplicationModel applicationModel = applicationDao.getApplication(title);
        response.setContentType(MediaTypes.JPEG);
        byte [] icon;
        if (applicationModel.getIconData() == null) {
            icon = IOUtils.toByteArray(getClass().getClassLoader().getResourceAsStream("icon_stub.jpeg"));
        } else {
            icon = applicationModel.getIconData();
        }

        FileCopyUtils.copy(icon, response.getOutputStream());
        return null;
    }

    @RequestMapping(value = "/image", method = RequestMethod.GET)
    public ModelAndView getImage(@RequestParam("id") String title, HttpServletResponse response, HttpServletRequest request) throws Exception{
        ApplicationModel applicationModel = applicationDao.getApplication(title);
        response.setContentType(MediaTypes.JPEG);
        byte [] image;
        if (applicationModel.getImageData() == null) {
            image = IOUtils.toByteArray(getClass().getClassLoader().getResourceAsStream("image_stub.jpeg"));
        } else {
            image = applicationModel.getImageData();
        }
        FileCopyUtils.copy(image, response.getOutputStream());
        return null;
    }

	@RequestMapping(value = "/my", method = RequestMethod.GET)
	public String my(Model model) {
        return renderStd(applicationService.getApplicationsForUser(model, userService.getAuthenticatedUser()), "viewMyApps");
	}

	@RequestMapping(value = "/edit", method = RequestMethod.GET)
	public String edit(@RequestParam("title") String title, Model model) {
		return renderStd(applicationService.getModelForEdit(model, title), "appEdit");
	}
	
	@RequestMapping(value = "/edit", method = RequestMethod.POST)
	public String update(@RequestParam("title") String title,
			@RequestParam("description") String description,
			@RequestParam("category") String categoryId,

            @RequestParam(value="image", required=false) MultipartFile image,
            @RequestParam(value="icon", required=false) MultipartFile icon,

            Model model) {
		ApplicationModel applicationModel = applicationDao.getApplication(title);

		if (!applicationModel.getAuthor().getName().equals(userService.getAuthenticatedUser().getName())){
			return StaticPages.SEC_DENIED_PAGE;
		}
		applicationModel.setDescription(description);
		applicationModel.setCategory(categoryDao.getCategory(categoryId));
		
		model.addAttribute("categories", categoryDao.getCategories());
		model.addAttribute("application", applicationModel);

        if (icon != null && imageService.validateImage(icon)) {
            applicationModel.setIconData(imageService.getIconBytes(icon));
        }
        if (image != null && imageService.validateImage(image)) {
            applicationModel.setImageData(imageService.getImageBytes(image));
        }

		if (StringUtils.isBlank(description) || StringUtils.isBlank(title)) {
			return renderStd(model, "appEdit", null, "Please fill all fields");
		}		
		
		applicationDao.updateApplication(applicationModel);

		return renderStd(model, "appEdited", "Application edited", null);
	}

	@RequestMapping(value = "/new", method = RequestMethod.GET)
	public String create(Model model) {
		model.addAttribute("categories", categoryDao.getCategories());		
		model.addAttribute("application", new ApplicationModel());
		return renderStd(model, "createNewApp");	
	}
	
	@RequestMapping(value = "/new", method = RequestMethod.POST)
	public String save(@RequestParam("title") String title,			
			@RequestParam("description") String description,
			@RequestParam("category") String categoryId,

            @RequestParam(value="image", required=false) MultipartFile image,
            @RequestParam(value="icon", required=false) MultipartFile icon,

            Model model) {
		
		ApplicationModel applicationModel= new ApplicationModel();				
		applicationModel.setTitle(title);				
		applicationModel.setCategory(categoryDao.getCategory(categoryId));
		applicationModel.setAuthor(userService.getAuthenticatedUser());
		applicationModel.setDescription(description);
		
		model.addAttribute("categories", categoryDao.getCategories());
		model.addAttribute("application", applicationModel);

        if (icon != null && imageService.validateImage(icon)) {
            applicationModel.setIconData(imageService.getIconBytes(icon));
        }
        if (image != null && imageService.validateImage(image)) {
            applicationModel.setImageData(imageService.getImageBytes(image));
        }

        if (StringUtils.isBlank(description) ||  StringUtils.isBlank(title)) {
			return renderStd(model, "createNewApp", null, "Please fill all fields");
		}

		if (applicationDao.createApplication(applicationModel) == null){
			return renderStd(model, "createNewApp", null, "Cannot save application. Maybe not unique application name/package values or title is too long");
		}

		return "redirect:/my";
	}
	
	@RequestMapping(value = "/app", method = RequestMethod.GET)
	public String show(@RequestParam("title") String title, Model model) {
		ApplicationModel app = applicationDao.getApplication(title);
		if (app == null )
			return "secDeniedPage";			
		model.addAttribute("app", app);		
		model.addAttribute("allowEdit", app.getAuthor().getName().equals(userService.getAuthenticatedUser().getName()));
		model.addAttribute("popularapps", applicationDao.getMostPopular());
		
		model.addAttribute("rateAvg", rateDao.getApplicationAvgRate(app));
		long myRate = rateDao.getRate(userService.getAuthenticatedUser(), app);
		model.addAttribute("canRate", myRate == 0);
		model.addAttribute("myRate", myRate);
		
		return renderStd(model, "appDetails");
	}
	
	@RequestMapping(value = "/app", method = RequestMethod.POST)
	public String rate(@RequestParam("title") String title, @RequestParam(value = "rate", required = false) Long rate, @RequestParam(value = "clear", required = false) String clear, Model model) {
        ApplicationModel app = applicationDao.getApplication(title);
		if (clear != null)
			rateDao.clearApplicationRate(userService.getAuthenticatedUser(), app);
		else
			rateDao.rateApplication(userService.getAuthenticatedUser(), app, rate);
		model.addAttribute("app", app);
		model.addAttribute("allowEdit", app.getAuthor().getName() == userService.getAuthenticatedUser().getName());
		model.addAttribute("popularapps", applicationDao.getMostPopular());
		model.addAttribute("rateAvg", rateDao.getApplicationAvgRate(app));
		long myRate = rateDao.getRate(userService.getAuthenticatedUser(), app);
		model.addAttribute("canRate", myRate == 0);
		model.addAttribute("myRate", myRate);
		
		return renderStd(model, "appDetails");		
	}
	
	@RequestMapping(value = "/delete", method = RequestMethod.GET)
	public String delete(@RequestParam("title") String title, Model model) {
		ApplicationModel applicationModel = applicationDao.getApplication(title);
		if (!applicationModel.getAuthor().getName().equals(userService.getAuthenticatedUser().getName())){
            return "secDeniedPage";
        }
		applicationDao.delete(applicationModel);
		return renderStd(model, "deleted", "Deleted", null);
	}	
	
	@RequestMapping(value = "/download", method = RequestMethod.GET, produces = MediaTypes.JSON)
    @ResponseBody
	public ApplicationModel download(@RequestParam("title") String title, Model model){
		return applicationDao.getBytesAndUpdateDownloadsNumber(title);
	}

	@RequestMapping(value = {"/"}, method = RequestMethod.GET)
	public String index(@RequestParam(required=false, value="category") String categoryId,
			Model model) {
        model = applicationService.getApplicationsForCategory(model, categoryId);
        model.addAttribute("popularapps", applicationDao.getMostPopular());
        return renderStd(model, "home");
	}
}

