package com.dataart.springtraining.service;

import org.springframework.stereotype.Service;
import org.springframework.web.multipart.MultipartFile;

import javax.imageio.ImageIO;
import java.awt.*;
import java.awt.geom.AffineTransform;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;

@Service
public class ImageService {

    public byte[] getIconBytes(MultipartFile icon){
        return resizeImage(icon, 128, 128);
    }
    public byte[] getImageBytes(MultipartFile image){
        return resizeImage(image, 512, 512);
    }

	/**
	 * Resize an image
	 * @param file
	 * @param w
	 * @param h
	 * @return
	 */
	public byte[] resizeImage(MultipartFile file, int w, int h) {
        BufferedImage bsrc, bdest;
        try
        {
            bsrc = ImageIO.read(file.getInputStream());
            bdest = new BufferedImage(w, h, BufferedImage.TYPE_INT_RGB);
            Graphics2D g = bdest.createGraphics();
            AffineTransform at = AffineTransform.getScaleInstance((double) w / bsrc.getWidth(),
                    (double) h / bsrc.getHeight());
            g.drawRenderedImage(bsrc, at);

            ByteArrayOutputStream baos = new ByteArrayOutputStream ();
            ImageIO.write(bdest, "jpg", baos);
            baos.flush();
            return baos.toByteArray();
        }
        catch (Exception e){
            return null;
        }
    }

	/**
	 * Validate the type of image
	 * @param image
	 * @return
	 */
	public boolean validateImage(MultipartFile image){
		return image.getContentType().equals("image/jpeg");
	}
}
