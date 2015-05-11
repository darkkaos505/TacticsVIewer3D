Shader "Custom/Grid"{
    SubShader
	 {
	 Tags { "Queue"="Transparent" "RenderType"="Transparent" }

        Pass 
		{
		    Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert_img 
            #pragma fragment frag 
 
            #include "UnityCG.cginc"

            fixed4 frag(v2f_img i) : SV_Target
			 {

			float width = 0.001;
			float num = 10000;

				float x = fmod(i.uv.x*num ,100.0);
				float y = fmod(i.uv.y*num ,100.0);

                bool p = x <  width || x > 1 - width;
                bool q = y <  width  || y > 1 - width;
                
			

                return fixed4(1,1,1, !( p && q)   * 0.1 );// fixed3 ((p && q)  || !(p || q)) ,1.0);
            }
            ENDCG
        }
    }

}