uniform sampler2D texture_opacityMap;

vec3 rgb2hsv(vec3 rgb)
{
	float Cmax = max(rgb.r, max(rgb.g, rgb.b));
	float Cmin = min(rgb.r, min(rgb.g, rgb.b));
    float delta = Cmax - Cmin;

	vec3 hsv = vec3(0., 0., Cmax);
	
	if (Cmax > Cmin)
	{
		hsv.y = delta / Cmax;

		if (rgb.r == Cmax)
			hsv.x = (rgb.g - rgb.b) / delta;
		else
		{
			if (rgb.g == Cmax)
				hsv.x = 2. + (rgb.b - rgb.r) / delta;
			else
				hsv.x = 4. + (rgb.r - rgb.g) / delta;
		}
		hsv.x = fract(hsv.x / 6.);
	}
	return hsv;
}


void getOpacity() {
	
	vec3 color = texture2D(texture_opacityMap, $UV).rgb;
    
	vec3 backgroundColor = vec3(0.196,0.992,0.196);
	vec3 weights = vec3(4., 1., 2.);

	vec3 hsv = rgb2hsv(color);
	vec3 target = rgb2hsv(backgroundColor);
	float dist = length(weights * (target - hsv));
	float alpha = 1. - clamp(3. * dist - 1.5, 0., 1.);
    
    if( alpha < 0.7 ){
        dAlpha = 1.0;    
    }else{
        dAlpha = 0.0;
    }
    
}