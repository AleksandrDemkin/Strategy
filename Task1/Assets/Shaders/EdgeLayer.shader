Shader "Unlit/EdgeLayer"
{
    Properties
	{
		 _MainTex ("Texture", 2D) = "white" {}
		 _SceneTex ("Scene Text", 2D) = "white" {}
		 _Color ("Color", Color) = (1,1,1,1)
		 _Width ("Ширина", Float) = 1
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100
 
		Pass
		{
 
			ZTest Always ZWrite Off Cull Off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
 
			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};
 
			struct v2f
			{
				float2 uv[9] : TEXCOORD0;
				float4 vertex : SV_POSITION;				
			};
 
			sampler2D _MainTex;
			float4 _MainTex_ST;
			float2 _MainTex_TexelSize;
			sampler2D _SceneTex;
			float _Width;
			fixed4 _Color;			
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv[0] = v.uv + _MainTex_TexelSize.xy * float2(-1, -1) * _Width;
				o.uv[1] = v.uv + _MainTex_TexelSize.xy * float2(0, -1) * _Width;
				o.uv[2] = v.uv + _MainTex_TexelSize.xy * float2(1, -1) * _Width;
				o.uv[3] = v.uv + _MainTex_TexelSize.xy * float2(-1, 0) * _Width;
				o.uv[4] = v.uv + _MainTex_TexelSize.xy * float2(0, 0) * _Width;
				o.uv[5] = v.uv + _MainTex_TexelSize.xy * float2(1, 0) * _Width;
				o.uv[6] = v.uv + _MainTex_TexelSize.xy * float2(-1, 1) * _Width;
				o.uv[7] = v.uv + _MainTex_TexelSize.xy * float2(0, 1) * _Width;
				o.uv[8] = v.uv + _MainTex_TexelSize.xy * float2(1, 1) * _Width;
				return o;
			}
			fixed luminance(fixed4 color) {
				return 0.2125 * color.r + 0.7154 * color.g + 0.0721 * color.b;
			}

			half Sobel(v2f input) {				
				half Gx[9] = {
					-1,-2,-1,
					0,0,0,
					1,2,1
				};
				half Gy[9] = {
						-1,0,1,
						-2,0,2,
						-1,0,1
				};
				half edgeX = 0;
				half edgeY = 0;
				half lum;
				for (int i = 0; i < 9; i++)
				{
					 lum = Luminance (tex2D (_MainTex, input.uv [i]));
					edgeX += lum * Gx[i];
					edgeY += lum * Gy[i];
				}
				return (abs(edgeX) + abs(edgeY));
			}
			
			fixed4 frag (v2f i) : SV_Target
			{				
				half edge = min(1, Sobel(i));
				fixed4 col = tex2D(_SceneTex, i.uv[4]);
				return lerp(col, _Color, edge);
			}
			ENDCG
		}
	}
}
