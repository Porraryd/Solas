Shader "Custom/SurfShader" {
	Properties {
        _MainTex ("Texture", 2D) = "white" {} // Regular object texture 
        _PlayerPosition ("Player Position", vector) = (0,0,0,0) // The location of the player - will be set by script
        _VisibleDistance ("Visibility Distance", float) = 10.0 // How close does the player have to be to make object visible
        _OutlineWidth ("Outline Width", float) = 1.0 // Outline width
        _OutlineColor ("Outline Color", color) = (1.0,1.0,0.0,1.0) // Colour of the outline - NOT USED
        _Darkness("Darkness", float) = 0.3 //Darkness outside of radius
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		float4 _PlayerPosition;
        float _VisibleDistance;
        float _OutlineWidth;
        float _Darkness;
        fixed4 _OutlineColor;
         
		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			float4 tempPos = (0.0, 0.0, 0.0, 0.0);
			float dist = distance(IN.worldPos, _PlayerPosition);
			
			// Return appropriate colour
			half4 c;
            //inside radius
            if (dist < _VisibleDistance) {
                c = tex2D (_MainTex, IN.uv_MainTex); 
                c *= 1;
            }
            
            //outline
            else if (dist < _VisibleDistance + _OutlineWidth) {
               c = tex2D (_MainTex, IN.uv_MainTex);
               float3 grayscale = _Darkness*((c.x+c.y+c.z)/3);
               float gradient = ((dist-_VisibleDistance)/_OutlineWidth);
               c.xyz = lerp(c.xyz, grayscale, gradient);
            }
            
            //outside of radius
            else { 
                c = tex2D (_MainTex, IN.uv_MainTex);
                float grayscale = _Darkness*((c.x+c.y+c.z)/3);
                c.xyz = grayscale;
            }
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
