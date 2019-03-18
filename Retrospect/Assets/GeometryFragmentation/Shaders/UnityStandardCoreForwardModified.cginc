// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

#ifndef UNITY_STANDARD_CORE_FORWARD_INCLUDED
#define UNITY_STANDARD_CORE_FORWARD_INCLUDED

#if defined(UNITY_NO_FULL_STANDARD_SHADER)
#   define UNITY_STANDARD_SIMPLE 1
#endif

#include "UnityStandardConfig.cginc"



#if UNITY_STANDARD_SIMPLE
    #include "UnityStandardCore.cginc"
    VertexOutputBaseSimple vertBase (VertexInput v) { return vertForwardBaseSimple(v); }
    VertexOutputForwardAddSimple vertAdd (VertexInput v) { return vertForwardAddSimple(v); }
    half4 fragBase (VertexOutputBaseSimple i) : SV_Target { return fragForwardBaseSimpleInternal(i); }
    half4 fragAdd (VertexOutputForwardAddSimple i) : SV_Target { return fragForwardAddSimpleInternal(i); }
#else
    #include "UnityStandardCore.cginc"
    VertexOutputForwardBase vertBase (VertexInput v) { return vertForwardBase(v); }
    VertexOutputForwardAdd vertAdd (VertexInput v) { return vertForwardAdd(v); }
    half4 fragBase (VertexOutputForwardBase i) : SV_Target { return fragForwardBaseInternal(i); }
    half4 fragAdd (VertexOutputForwardAdd i) : SV_Target { return fragForwardAddInternal(i); }
	
	float _Fragmentation;
	sampler2D _DirectionsMap;
	float _DirectionsMultiplier;

	//modes
	float _Overtension;
	float _Dezintegration;
	float _Disturbances;

	float _DisturbancesIntensity;
	

	[maxvertexcount(20)]
    void geomBase(triangle VertexOutputForwardBase t[3], inout TriangleStream<VertexOutputForwardBase> stream)
	{
		float4 uvPos = (t[0].tex + t[1].tex + t[2].tex)/3.0f;
		if(_Disturbances > 0)
		{
			uvPos = float4(uvPos.x + _Time.x * _DisturbancesIntensity
				,uvPos.y  - _Time.x * _DisturbancesIntensity, uvPos.zw);
		}
		
		float4 col = tex2Dlod(_DirectionsMap,uvPos);

		float4 vec = 2*(float4(0.5,0.5,0.5,0.5) - col);

		float4 center = (t[0].pos + t[1].pos + t[2].pos)/3; 
		
		for(int i = 0; i < 3;i++)
		{
			if(_Overtension)
			{
				vec *= _DirectionsMultiplier;
			}
			else
			{
				vec = normalize(vec) * _DirectionsMultiplier;
			}
			
			if(_Dezintegration)
			{
				t[i].pos += (center - t[i].pos) * _Fragmentation;
			}			

			t[i].pos += float4(vec.xyz * _Fragmentation,0);

			stream.Append(t[i]);
		}

		stream.RestartStrip();

		stream.Append(t[0]);
		stream.Append(t[2]);
		stream.Append(t[1]);

		stream.RestartStrip();
		
	}




	[maxvertexcount(20)]
    void geomAdd(triangle VertexOutputForwardAdd t[3], inout TriangleStream<VertexOutputForwardAdd> stream)
	{
		float4 uvPos = (t[0].tex + t[1].tex + t[2].tex)/3.0f;
		if(_Disturbances > 0)
		{
			uvPos = float4(uvPos.x + _Time.x * _DisturbancesIntensity
				,uvPos.y  - _Time.x * _DisturbancesIntensity, uvPos.zw);
		}
		
		float4 col = tex2Dlod(_DirectionsMap,uvPos);

		float4 vec = 2*(float4(0.5,0.5,0.5,0.5) - col);

		float4 center = (t[0].pos + t[1].pos + t[2].pos)/3; 
		
		for(int i = 0; i < 3;i++)
		{
			if(_Overtension)
			{
				vec *= _DirectionsMultiplier;
			}
			else
			{
				vec = normalize(vec) * _DirectionsMultiplier;
			}
			
			if(_Dezintegration)
			{
				t[i].pos += (center - t[i].pos) * _Fragmentation;
			}			

			t[i].pos += float4(vec.xyz * _Fragmentation,0);

			stream.Append(t[i]);
		}

		stream.RestartStrip();

		stream.Append(t[0]);
		stream.Append(t[2]);
		stream.Append(t[1]);

		stream.RestartStrip();
		
	}

#endif

#endif // UNITY_STANDARD_CORE_FORWARD_INCLUDED
