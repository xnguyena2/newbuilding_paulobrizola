//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
namespace AssemblyCSharp
{
	public class Point8_4handicap
	{
		
		
		static Vector3 o1 = new Vector3 (-0.8699951F, 1.5F, 20.64F);
		static Vector3 o2 = new Vector3 (-11.37997F, 1.5F, 8.799988F);
		static Vector3 o3 = new Vector3 (2.420013F, 1.5F, -3.529999F);
		static Vector3 o4 = new Vector3 (10.41F, 1.5F, 6.92F);
		static Vector3 o5 = new Vector3 (-5.07F, 1.5F, 12.12F);
		
		static Vector3 f1 = new Vector3 (-0.8099976F, 1.5F, 12.17F);
		static Vector3 f2 = new Vector3 (-6.02F, 1.5F, 8.799988F);
		static Vector3 f4 = new Vector3 (2.4F, 1.5F, 6.9F);
		static Vector3 f5 = new Vector3 (-5.14F, 1.5F, 8.5F);
		
		static Vector3 p1 = new Vector3 (1.599976F, 1.5F, 8.96F);
		static Vector3 p2 = new Vector3 (-2.91F, 1.5F, 13.07F);
		static Vector3 p3 = new Vector3 (-2.91F, 1.5F, 8.96F);
		
		public static Vector3 evelator = new Vector3 (1.01F, 1.5F, 13.07F);
		
		
		static Vector3[] office1 = new Vector3[] { evelator, p2, o1 };
		static Vector3[] office2 = new Vector3[] { evelator, p2, p3, f2, o2 };
		static Vector3[] office3 = new Vector3[] { evelator, p2, p3, p1, o3 };		
		static Vector3[] office4 = new Vector3[] { evelator, p2, p3, p1, f4, o4 };
		static Vector3[] office5 = new Vector3[] { evelator, p2, p3, f5, o5 };
		
		public Dictionary<string, Vector3[]> dictionary = new Dictionary<string, Vector3[]>();

		public Point8_4handicap ()
		{
			dictionary.Add("office1",office1);
			dictionary.Add("office2",office2);
			dictionary.Add("office3",office3);
			dictionary.Add("office4",office4);
			dictionary.Add("office5",office5);
		}
	}
}

