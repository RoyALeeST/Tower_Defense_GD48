Shader "Unlit/NewUnlitShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		//_SecondaryText("This is a second texture", 2D) = "white" {}
		//_ColorTint("Tint",Color) = (1,0.5,1,1)
		//_CharacterPosition("Character's Position", Vector) = (0,0,0,0)
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" } //Dictionary to set the parameters that I want to change
		//Google them for more information
		
		LOD 100 //Level of Detail

		Pass
		{
			CGPROGRAM//Program must be in between this 
// Upgrade NOTE: excluded shader from DX11; has structs without semantics (struct v2f members intensity)
#pragma exclude_renderers d3d11
			#pragma vertex vert // These are the functions that are gonna be called on each vertex
			#pragma fragment frag// same for ths one
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata 
			{
				float4 vertex : POSITION;//Vector 4 - Store the position of the vertex on a 3d world
				float3 norlam : NORMAL;// Normal on the vertex
				float2 uv : TEXCOORD0; // UV for that vertex
				float4 color : COLOR;//Coloro
			};

			struct v2f//Inout for pixel shader
			{
				float2 uv : TEXCOORD0; //
				float4 vertex : SV_POSITION;
				float intensity;
			};

			sampler2D _MainTex; 
			//float4 tint;
			//This is gonna be called 8 times per frame for a cube(8 vertex)
			//7000 thousand times per frame on a 7000 vertex mesh
			v2f vert (appdata v)
			{
				v2f o;
				o.intensity = 5;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			

			//Pixel shader
			//1980x1080 resolution screen It's gonna be called 	2Million times per frame
			//RUNS ON GPU!!!
			fixed4 frag (v2f i) : SV_Target //Variables defined above as structs
			{
				// sample the texture
				//i.intensity
				fixed4 col = tex2D(_MainTex, i.uv);
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG // And this... LMAO
		}
	}
}
