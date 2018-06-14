using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class SavebleObject 
{
	public abstract bool isInstantiatable();

	public abstract string GetKey ();

	public virtual string GetPrefabPath ()
	{
		Debug.LogError ("Method not implemented");

		return "";
	}
}
