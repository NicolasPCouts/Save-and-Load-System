using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace survivalPrototype
{
	public static class SavingManager 
	{
		public static string SavingPath;
		
		public static void SaveData<T>(T dataToSave, int Save) where T : SavebleObject
		{
			if (!Directory.Exists (SavingPath))
				Directory.CreateDirectory (SavingPath);
			
			string path = SavingPath + "Save" + Save.ToString() + "/" + dataToSave.GetKey() +".banana";
			
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream fs = new FileStream (path, FileMode.Create);
			
			bf.Serialize (fs, dataToSave);
			fs.Close ();
		}
		
		public static T LoadData<T>(string key, int Save) where T : SavebleObject
		{
			string path = SavingPath + "Save" + Save.ToString() + "/" + key +".banana";
			
			if (File.Exists (path)) 
			{
				FileStream fs = new FileStream (path, FileMode.Open);
				BinaryFormatter bf = new BinaryFormatter ();
				
				T objectToReturn = (T)bf.Deserialize (fs);
				fs.Close ();
				
				return objectToReturn;
			}
			
			return default(T);
		}
		
		public static bool HasSaveFile(string key, int Save)
		{
			return System.IO.File.Exists(SavingPath + "Save" + Save.ToString() + "/" + key +".banana");
		}

		public static bool HasAnySaveFile(int save)
		{
			if (Directory.GetFiles (SavingPath + "Save" + save.ToString ()).Length > 0) 
			{
				return true;
			}

			return false;
		}

		public static string[] GetObjectsToInstantiate(int save)
		{
			string[] dirs = Directory.GetFiles (SavingPath + "Save" + save.ToString());

			List<string> objectsToInstantiatePath = new List<string> ();

			for (int i = 0; i < dirs.Length; i++)
			{
				FileStream fs = new FileStream (dirs[i], FileMode.Open);
				BinaryFormatter bf = new BinaryFormatter ();

				SavebleObject saveObject = (SavebleObject)bf.Deserialize (fs);
				fs.Close ();
				if (saveObject.isInstantiatable()) 
				{
					string pathToInstantiateObject = saveObject.GetPrefabPath ();
					objectsToInstantiatePath.Add (pathToInstantiateObject);
				}
			}

			return objectsToInstantiatePath.ToArray ();
		}
	}
}