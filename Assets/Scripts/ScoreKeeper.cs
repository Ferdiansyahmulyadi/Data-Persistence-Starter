using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
	//make this object accessible from any scenes and sessions
    public static ScoreKeeper Instance;
	public string FirstPlayerName;
	public string SecondPlayerName;
	public int FirstHighestPoints = 0;
	public int SecondHighestPoints = 0;

	//make this object available in different scenes and sessions, don't destroy this object on loading
	private void Awake()
	{
		//start of new code, make this object as singleton
		if(Instance != null)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);

	}

	private void Start()
	{
		LoadBestPlayer();
	}
    
	[Serializable]
	class SaveData
	{
		public string RecPlayerName;
		public int RecHighestPoints;
	}

	public void SaveBestPlayer()
	{
		SaveData data = new SaveData();
		data.RecPlayerName = SecondPlayerName;
		data.RecHighestPoints = SecondHighestPoints;

		string json = JsonUtility.ToJson(data);

		File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
	}

	public void LoadBestPlayer()
	{
		string path = Application.persistentDataPath + "/savefile.json";
		if(File.Exists(path))
		{
			string json = File.ReadAllText(path);
			SaveData data = JsonUtility.FromJson<SaveData>(json);

			FirstPlayerName = data.RecPlayerName;
			FirstHighestPoints = data.RecHighestPoints;
		}

	}
}
