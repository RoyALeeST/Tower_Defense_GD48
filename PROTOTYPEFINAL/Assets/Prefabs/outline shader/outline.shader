﻿Shader "N3K/outline"
{
	Properties
	{
		_Color("Main Color", Color) = (0.5,0.5,0.5,1)
		_MainTex ("Texture", 2D) = "white" {}
		_OutlineColor ("Outline color", Color) = (0,0,1)
		_OutlineWidth("Outline width", Range(1.0,5.0)) = 1.01
	}

	// cgi code
	CGINCLUDE
	#include "UnityCG.cginc"


	 struct appdata
	 {
		 float4 vertex : POSITION;
		 float3 normal : NORMAL;
	 };
	 struct v2f
	 {
		 float4 pos : POSITION;
		 //float4 color : COLOR;
		 float3 normal : NROMAL;
	 };
	
	 float _OutlineWidth;
	 float4 _OutlineColor;
	 
	 v2f vert (appdata v) // render normal mesh but bigger
	 {
		 v.vertex.xyz *= _OutlineWidth; 

		 v2f o;
		 o.pos = UnityObjectToClipPos(v.vertex);
		 //o.color = _OutlineColor;
		 return o;
	 }
	ENDCG

	SubShader
	{
		Pass //render the outline
		{
			ZWrite off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			//float4 _OutlineColor;
			half4 frag(v2f i) : COLOR
			{
				return _OutlineColor;
			}
			
			ENDCG
		}
		Pass // normal render (render the object)
		{
			ZWrite On 

			Material
			{
				Diffuse[_Color] // the main color you see at the object
				Ambient [_Color]
			}

			Lighting On

			SetTexture[_MainTex]
			{
				ConstantColor[_Color]
			}

			SetTexture[_MainTex]
			{
				Combine previous * primary DOUBLE
			}


		}
	}
}