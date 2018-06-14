using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using survivalPrototype.GameManagement;

namespace survivalPrototype
{
	public class Saver : MonoBehaviour 
	{
		public static Saver instance;

		public delegate void LoadAndSaveDelegate(int save);
		public event LoadAndSaveDelegate LoadEvent;
		public event LoadAndSaveDelegate SaveEvent;

		public int savesLenght;
		public int currentSave;

		public float timeToSave = 10f;
		public float currentTimeToSave = 0f;

		// Use this for initialization
		public void Start ()
		{
			instance = this;

			DirectoryInfo info = new DirectoryInfo (SavingManager.SavingPath);
			int saves = info.GetDirectories ().Length;
			print (saves.ToString ());

			savesLenght = saves;
		}

		void Update()
		{
			currentTimeToSave += Time.deltaTime;

			if (GameManager.instance.gameState == GameState.Running) 
			{
				if (currentTimeToSave >= timeToSave) 
				{
					currentTimeToSave = 0f;
					SaveEvent (currentSave);
					print ("progress saved");
				}
			}
		}

		public void CreateNewSaveDirectory()
		{
			savesLenght++;
			currentSave = savesLenght; 
			string path = SavingManager.SavingPath + "Save" + currentSave.ToString();
			Directory.CreateDirectory (path);
		}

		public void CreateNewSaveFiles(int save)
		{
			if(SaveEvent != null)
				SaveEvent (save);
		}

		public void LoadFiles(int save)
		{
			currentSave = save;
			string[] objToInstantiate = SavingManager.GetObjectsToInstantiate (save);

			for (int i = 0; i < objToInstantiate.Length; i++) 
			{
				GameObject GO = Resources.Load (objToInstantiate [i]) as GameObject;
				print (GO.name + " instantiated");
				Instantiate (GO);
				//GO.GetComponent<ISaveAndLoad> ().Load (save);
			}

			LoadEvent (save);
		}
	}
	
}