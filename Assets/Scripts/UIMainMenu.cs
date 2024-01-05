using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
	[SerializeField] TMP_InputField playerName;
	[SerializeField] TextMeshProUGUI bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        bestScoreText.text = $"Best Score : {ScoreKeeper.Instance.FirstPlayerName} : {ScoreKeeper.Instance.FirstHighestPoints}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void StartApplication()
	{
		//this method will start the game and call the main manager object
		SetPlayerName(playerName.text);
		SceneManager.LoadScene("main");
	}

	public void ApplicationExit()
	{
#if UNITY_EDITOR
		EditorApplication.ExitPlaymode();
#else
		Application.Quit();
#endif

	}

	private void SetPlayerName(string name)
	{
		ScoreKeeper.Instance.SecondPlayerName = name;
	}
}
