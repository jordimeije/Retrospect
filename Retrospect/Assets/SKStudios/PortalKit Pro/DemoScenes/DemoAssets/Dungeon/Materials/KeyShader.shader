﻿
Shader "Portal/Demos/KeyShader" {
	Properties{
		_MainTex("Particle Texture", 2D) = "white" {}
	}

		Category{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" "PreviewType" = "Plane" }
		Blend DstColor SrcColor
		ColorMask RGB
		Cull Off Lighting Off ZWrite Off

		SubShader{
		Pass{

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma target 2.0
#pragma multi_compile_particles
#pragma multi_compile_fog

#include "UnityCG.cginc"

		sampler2D _MainTex;
		fixed4 _TintColor;

	struct appdata_t {
		float4 vertex : POSITION;
		fixed4 color : COLOR;
		float2 texcoord : TEXCOORD0;
		UNITY_VERTEX_INPUT_INSTANCE_ID
	};

	struct v2f {
		float4 vertex : SV_POSITION;
		fixed4 color : COLOR;
		float2 texcoord : TEXCOORD0;
		UNITY_FOG_COORDS(1)
		UNITY_VERTEX_OUTPUT_STEREO
	};

	float4 _MainTex_ST;

	v2f vert(appdata_t v)
	{
		v2f o;
		UNITY_SETUP_INSTANCE_ID(v);
		UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
		o.vertex = UnityObjectToClipPos(v.vertex);
		o.color = v.color;
		o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
		UNITY_TRANSFER_FOG(o,o.vertex);
		return o;
	}

	sampler2D_float _CameraDepthTexture;

	fixed4 frag(v2f i) : SV_Target
	{

	fixed4 col;
	fixed4 tex = tex2D(_MainTex, float2(i.texcoord.x + _Time.w / 5, i.texcoord.y));
	col.rgb = tex.rgb * i.color.rgb * 2;
	col.a = i.color.a * tex.a;
	col = lerp(fixed4(0.5f,0.5f,0.5f,0.5f), col, col.a);
	UNITY_APPLY_FOG_COLOR(i.fogCoord, col, fixed4(0.5,0.5,0.5,0.5)); // fog towards gray due to our blend mode
	return col;
	}
		ENDCG
	}
	}
	}
}
