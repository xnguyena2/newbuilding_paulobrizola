using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using AssemblyCSharp;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.EventSystems;
namespace AssemblyCSharp
{
	public class cinema
	{
		public Sprite sprite;
		public string title,director,list,duration,room,schedules,other;
		public cinema(Sprite s,string title,string director, string list, string duration, string room, string schedules, string other)
		{
			sprite = s;
			this.title = title;
			this.director = director;
			this.list = list;
			this.duration = duration;
			this.room = room;
			this.schedules = schedules;
			this.other = other;
		}
	}
}