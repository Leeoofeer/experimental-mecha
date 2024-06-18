Shader "Custom/SimpleTransparent"
{
    Properties
    {
        _Color ("Color", Color) = (.5,.5,.5,0.5)
        _MainTex ("Base (RGB)", 2D) = "white" { }
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert alpha

        sampler2D _MainTex;
        fixed4 _Color;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Transparent/Cutout/Diffuse"
}

