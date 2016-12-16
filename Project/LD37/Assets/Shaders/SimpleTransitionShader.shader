Shader "Custom Sprites/SimpleTransitionShader"
{
	Properties
	{
		[PerRendererData] _MainTex 	("Sprite Texture", 2D) 				= "white" {}
		_RenderTexture				("RenderTexture", 2D)				= "white" {}
		_Delta						("Delta", Range(0, 1.1))			= 1
		_DefaultColor				("Default color", Color)			= (0,0,0,1)
	}

	SubShader
	{
		Tags
		{ 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Blend One OneMinusSrcAlpha

		Pass
		{
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile _ PIXELSNAP_ON
			#include "UnityCG.cginc"
			
			struct appdata_t
			{
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				fixed4 color    : COLOR;
				float2 texcoord  : TEXCOORD0;
			};
			
			fixed4 _Color;

			v2f vert(appdata_t IN)
			{
				v2f OUT;
				OUT.vertex = mul(UNITY_MATRIX_MVP, IN.vertex);
				OUT.texcoord = IN.texcoord;
				OUT.color = IN.color * _Color;
				#ifdef PIXELSNAP_ON
				OUT.vertex = UnityPixelSnap (OUT.vertex);
				#endif

				return OUT;
			}

			sampler2D _MainTex;
			sampler2D _RenderTexture;
			fixed _Delta;
			fixed4 _DefaultColor;
			
			fixed4 ApplyTextureWithDelta(fixed4 trueColor, sampler2D tex, float2 texcoord, float delta){
				fixed4 color = tex2D(tex, texcoord);
				return lerp(trueColor, color, delta);
			}
			
			fixed4 frag(v2f IN) : SV_Target
			{
				fixed4 color = tex2D(_RenderTexture, IN.texcoord);
				fixed value = (color[0]+color[1]+color[2])/3;
				if (value>_Delta) color.rgb = _DefaultColor.rgb;
				color.a = 1;
				return color;
			}
		ENDCG
		}
	}
}
