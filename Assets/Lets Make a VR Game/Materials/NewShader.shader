Shader "Custom/CircleRingsShader"
{
    Properties
    {
        _Color("Color", Color) = (1, 1, 1, 1)
        _Frequency("Frequency", Float) = 10.0
        _Thickness("Thickness", Float) = 0.05
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            fixed4 _Color;
            float _Frequency;
            float _Thickness;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv - 0.5;
                float dist = length(uv) * _Frequency;
                float rings = abs(sin(dist * 3.14159)) * smoothstep(_Thickness, 0.0, dist - floor(dist));
                return _Color * rings;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
