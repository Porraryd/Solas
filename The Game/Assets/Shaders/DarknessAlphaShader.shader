Shader "Custom/DarknessAlphaShader" {
	Properties {
        _MainTex ("Texture", 2D) = "white" {} // Regular object texture 
        _PlayerPosition ("Player Position", vector) = (0,0,0,0) // The location of the player - will be set by script
        _VisibleDistance ("Visibility Distance", float) = 10.0 // How close does the player have to be to make object visible
        _OutlineWidth ("Outline Width", float) = 1.0 // Outline width
        //_OutlineColor ("Outline Color", color) = (1.0,1.0,0.0,1.0) // Colour of the outline - NOT USED
        _Darkness("Darkness", float) = 0.5 //Darkness outside of radius
        _DarknessAlpha("Darkness Alpha", Range(0.00, 1.00)) = 0.50
	}
	SubShader {
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		
		LOD 200
		
		ZWrite Off
		
		Blend SrcAlpha OneMinusSrcAlpha 
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		float4 _PlayerPosition;
        float _VisibleDistance;
        float _OutlineWidth;
        float _Darkness;
        //fixed4 _OutlineColor;
        float _DarknessAlpha;
         
		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			float dist = distance(IN.worldPos, _PlayerPosition.xyz);
		
			half4 c;
            
            //inside radius
            if (dist < _VisibleDistance) {
                c = tex2D (_MainTex, IN.uv_MainTex); 
            }
            
            //outline
            else if (dist < _VisibleDistance + _OutlineWidth) {
               	
               	c = tex2D (_MainTex, IN.uv_MainTex);
               	float gradient = ((dist-_VisibleDistance)/_OutlineWidth);
               		
               	float3 grayscale = _Darkness*((c.x+c.y+c.z)/3);
               	c.xyz = lerp(c.xyz, grayscale, gradient);
               	
               	c.a = lerp(1, _DarknessAlpha, gradient);
               	
            }
            
            //outside of radius
            else { 
                c = tex2D (_MainTex, IN.uv_MainTex);
                float grayscale = _Darkness*((c.x+c.y+c.z)/3);
                c.xyz = grayscale;
            	c.a = _DarknessAlpha;
            }
            
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
