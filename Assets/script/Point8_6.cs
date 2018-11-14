
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class Point8_6
	{
		public static Vector3 stair = new Vector3 (1.62f, 1.0F, 7.69f);
		public static Vector3 evelator = new Vector3 (22.6f, 1.0F, 1.31f);
		
		
		static Vector3 p1 = new Vector3 (-5.55F, 1.5F, 7.69F);
		static Vector3 p2 = new Vector3 (-5.55F, 1.5F, 13.04F);
		static Vector3 p3 = new Vector3 (-5.55F, 1.5F, -0.6F);
		static Vector3 p4 = new Vector3 (-19.7F, 1.5F, -0.6F);
		static Vector3 p5 = new Vector3 (-19.7F, 1.5F, -9.1F);
		static Vector3 p6 = new Vector3 (-5.55F, 1.5F, -18.6F);


		static Vector3 o1 = new Vector3 (1.81F, 1.5F, 13.04F);
		static Vector3 o2 = new Vector3 (-23.1F, 1.5F, -9.1F);
		static Vector3 o3 = new Vector3 (2.2F, 1.5F, -21.2F);
		
		static Vector3 pos1 = new Vector3 (294.2f, 75.3f, 239.4f);
		static Vector3 lookat1 = new Vector3 (294.0f, 31.1f, 195.0f);
		
		static Vector3[] office1 = new Vector3[] { stair, p1, p2, o1 };
		static Vector3[] office2 = new Vector3[] { stair, p1, p3, p4, p5, o2 };
		static Vector3[] office3 = new Vector3[] { stair, p1, p6, o3 };
		
		public Dictionary<string, Vector3[]> dictionary = new Dictionary<string, Vector3[]>();
		public Dictionary<string,Vector3> PositnCamera = new Dictionary<string, Vector3> ();
		public Dictionary<string,Vector3> LookatCamera = new Dictionary<string, Vector3> ();
		
		public Point8_6 ()
		{			
			LookatCamera.Add("office1",lookat1);
			LookatCamera.Add("office2",lookat1);
			LookatCamera.Add("office3",lookat1);
			
			PositnCamera.Add("office1",pos1);
			PositnCamera.Add("office2",pos1);
			PositnCamera.Add("office3",pos1);
			
			dictionary.Add("office1",office1);
			dictionary.Add("office2",office2);
			dictionary.Add("office3",office3);
		}
	}
}
