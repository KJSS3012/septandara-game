using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour
{

    public Button playButton;
    public Button quitButton;
    public Button reset;

    public StatusGame status;

	void Start () {
		playButton = playButton.GetComponent<Button>();
        quitButton = quitButton.GetComponent<Button>();
        reset = reset.GetComponent<Button>();

		playButton.onClick.AddListener(PlayGame);
		quitButton.onClick.AddListener(QuitGame);
        reset.onClick.AddListener(eraseProgress);
	}

    void PlayGame(){
        SceneManager.LoadScene(status.scene);
    }

    void QuitGame(){
        Application.Quit();
    }

    public void eraseProgress(){
        status.scene = 1;
        status.scoreCoins = 0;
        status.quantLife = 100;
        status.consecutiveQuestion = 0;
        for (int i = 0; i < status.chances.Length; i++) {
            status.chances[i] = true;
        }
    }
}
