Shader "Hidden/CatVisionColor"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Pass
        {
            ZTest Always Cull Off ZWrite Off
            Fog { Mode Off }

            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;

            float4 frag(v2f_img i) : COLOR
            {
                float4 c = tex2D(_MainTex, i.uv);

                // Convert the RGB color to the grayscale equivalent perceived by cats
                float gray = dot(c.rgb, float3(0.299, 0.587, 0.114)); // Luminance
                float3 catColor = lerp(float3(gray, gray, gray), c.rgb, float3(0.5, 0.5, 0.5));
                
                // Reduce the red component
                catColor.r *= 0.5;

                return float4(catColor, c.a);
            }
            ENDCG
        }
    }
}
