﻿// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

Shader "ToonTest" {
	Properties {
		_Color ("Diffuse Material Color", Color) = (1,1,1,1)
		_UnlitColor("Unlit Color", Color ) = (0.5,0.5,0.5,1)
		_DiffuseThreshold ("Lightning Threshold", Range(-1.1,1)) = 0.1
		_SpecColor("Specular Material Color",Color) = (1,1,1,1)
		_MainTex ("Main Texture" ,2D) = "AK47" {}
		_Shininess ("Shininess", Range(0.5,1)) = 1
		_OutlineThickness("Outline Thickness",Range(0,1)) = 0.1
 	}
	SubShader {
		Tags { "LightMode"="ForwardBase" }
		//pass for ambient light and 1st light source

		Pass{
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma vertex vert

		#pragma fragment frag


  		uniform float4 _Color;
		uniform float4 _UnlitColor;
		uniform float4 _DiffuseThreshold;
		uniform float4 _Shininess;
		uniform float4 _OutlineThickness;
		uniform float4 _SpecColor;

 		uniform float4 _LightColor0;
		uniform float4 _MainTex_ST;
		uniform sampler2D _MainTex;

		struct vertexInput {
			float4 vertex : POSITION;
			float3 normal : NORMAL;
			float4 texcoord : TEXCOORD0;
 		};
 		struct vertexOutput{
 		float4 pos:SV_POSITION;
 		float3 normalDir : TEXCOORD1;
 		float4 lightDir : TEXCOORD2;
 		float3 viewDir : TEXCOORD3;
 		float2 uv	:	TEXCOORD0;
 		};

		 vertexOutput vert(vertexInput input){
		 vertexOutput output;
		 //normal Direction 
		 output.normalDir = normalize(mul(float4(input.normal,0.0),unity_WorldToObject).xyz);
		 //World position 
		 float4 posWorld = mul(unity_ObjectToWorld,input.vertex);
		 //view direction
		 output.viewDir = normalize(_WorldSpaceCameraPos.xyz- posWorld.xyz);//Vector form the object to the Camera
		 //light Direction
		 float3 fragmentToLightSource = (_WorldSpaceCameraPos.xyz - posWorld.xyz);

		  output.lightDir = float4(
		 		normalize(lerp(_WorldSpaceLightPos0.xyz,fragmentToLightSource,_WorldSpaceLightPos0.w)),lerp (1.0,1.0/length(fragmentToLightSource),_WorldSpaceLightPos0.w));
		 		//fragmentInput output
		 		output.pos = mul(UNITY_MATRIX_MVP,input.vertex);
		 		//uvmap
		 		output.uv = input.texcoord;
		 		return output;
		    }

		    float4 frag(vertexOutput input):COLOR{

		    float nDotL = saturate(dot(input.normalDir,input.lightDir.xyz));

		     //diffuse threshold calculation
		     float diffuseCutoff = saturate((max(_DiffuseThreshold,nDotL)- _DiffuseThreshold)*500); 
		     //Specular threshold calculation
		     float specularCutoff = saturate(max(_Shininess,dot(reflect(-input.lightDir.xyz,input.normalDir),input.viewDir))-_Shininess * 500);
		     //calculate outlines
		     float outlineStrength = saturate((dot(input.normalDir,input.viewDir)-_OutlineThickness)*500);

		     float3 ambientLight= (0.5-diffuseCutoff) * _UnlitColor.xyz;

		     float3 diffuseReflection = (1-specularCutoff)*_Color.xyz*diffuseCutoff;

		     float3 specularReflection = _SpecColor.xyz * specularCutoff;

		     float3 combinedLight = (ambientLight + diffuseReflection)*outlineStrength+specularReflection;

		     return float4(combinedLight,1.0)+tex2D(_MainTex,input.uv);

		     }

 			ENDCG   

 			}
 			}
 			}