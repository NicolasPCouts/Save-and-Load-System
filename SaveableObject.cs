using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public abstract class SaveableObject 
{
	public abstract bool isInstantiatable();

	public abstract string GetKey ();

	public virtual string GetPrefabPath ()
	{
		Debug.LogError ("Method not implemented");

		return "";
	}
}
