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
	public class theater
	{
		public Sprite sprite;
		public string title,genre,classification,schedules,season,other;
		public theater(Sprite s,string title,string genre, string classification, string schedules, string season, string other)
		{
			sprite = s;
			this.title = title;
			this.genre = genre;
			this.classification = classification;
			this.schedules = schedules;
			this.season = season;
			this.other = other;
		}
	}
}