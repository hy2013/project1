Shader "Hidden/Unlit/Transparent Colored HSVCover 1"
{
	Properties
	{
		_MainTex("Base (RGB), Alpha (A)", 2D) = "black" {}
		_AlphaTex("Alpha (RGB), Alpha (A)", 2D) = "white" {}
	}

	SubShader
	{
		LOD 200

		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
		}
		
		Pass
		{
			Cull Off
			Lighting Off
			ZWrite Off
			Offset -1, -1
			Fog { Mode Off }
			ColorMask RGB
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
			#pragma target 3.0
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
			#include "ColorSpace.cginc"

			sampler2D _MainTex;
			sampler2D _AlphaTex;
			float4 _ClipRange0 = float4(0.0, 0.0, 1.0, 1.0);
			float2 _ClipArgs0 = float2(1000.0, 1000.0);
			float4 _ClipConer = float4(0.0, 0.0, 1000.0, 0.0);

			struct appdata_t
			{
				float4 vertex : POSITION;
				half4 color : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : POSITION;
				half4 color : COLOR;
				float2 texcoord : TEXCOORD0;
				float2 worldPos : TEXCOORD1;
			};

			v2f o;

			v2f vert (appdata_t v)
			{
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.color = v.color;
				o.texcoord = v.texcoord;
				o.worldPos = v.vertex.xy * _ClipRange0.zw + _ClipRange0.xy;
				return o;
			}

			half4 frag (v2f IN) : COLOR
			{
				// Sample the texture
				fixed4 col = tex2D(_MainTex, IN.texcoord);
				col.a *= tex2D(_AlphaTex, IN.texcoord).r * IN.color.a;

				fixed3 hsvBase = RGBtoHSV(col.rgb);
				fixed3 hsvCover = RGBtoHSV(IN.color.rgb);
				hsvBase.r = hsvCover.r;
				hsvBase.gb *= hsvCover.gb;
				col.rgb = HSVtoRGB(hsvBase);

				if (_ClipConer.x > 0 && _ClipConer.y > 0)
				{
					// Softness factor
					float2 factor = max(float2(0, 0), abs(IN.worldPos) + _ClipConer.xy - float2(1.0, 1.0)) / _ClipConer.xy;
					float dis = factor.x * factor.x + factor.y * factor.y;
					if (_ClipConer.w > 0)
					{
						float center = 0.5 + _ClipConer.w * 0.5;
						dis = abs((dis - center) / (1 - center));
					}
					col.a *= clamp((1 - dis) * _ClipConer.z, 0.0, 1.0);
				}
				else
				{
					// Softness factor
					float2 factor = (float2(1.0, 1.0) - abs(IN.worldPos)) * _ClipArgs0;
					col.a *= clamp(min(factor.x, factor.y), 0.0, 1.0);
				}

				return col;
			}
			ENDCG
		}
	}
	
	SubShader
	{
		LOD 100

		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
		}
		
		Pass
		{
			Cull Off
			Lighting Off
			ZWrite Off
			Fog { Mode Off }
			ColorMask RGB
			Blend SrcAlpha OneMinusSrcAlpha
			ColorMaterial AmbientAndDiffuse
			
			SetTexture [_MainTex]
			{
				Combine Texture * Primary
			}
		}
	}
}