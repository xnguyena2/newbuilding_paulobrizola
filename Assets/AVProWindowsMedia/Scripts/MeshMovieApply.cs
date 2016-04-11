using UnityEngine;
using System.Collections;

[AddComponentMenu("AV Pro Windows Media/MeshMovieApply")]
public class MeshMovieApply : MonoBehaviour 
{
	public Material _material;
	public bool _allMaterials;
	public MoviePlayer _moviePlayer;
	
	void Start()
	{
		if (_moviePlayer != null)
			ApplyMapping(_moviePlayer.OutputTexture);
	}
	
	void Update()
	{
		if (_moviePlayer != null)
			ApplyMapping(_moviePlayer.OutputTexture);
	}
	
	public void ApplyMapping(Texture texture)
	{
		if (_allMaterials)
		{
			MeshRenderer mr = this.GetComponent(typeof(MeshRenderer)) as MeshRenderer;
			
			if (mr != null)
			{
				foreach (Material m in mr.materials)
				{
					m.mainTexture = texture;
				}
			}
		}
		else
		{
			if (_material != null)
			{
				_material.mainTexture = texture;
			}
		}		
	}
	
	public void OnApplicationQuit()
	{
		ApplyMapping(null);
	}
}
