using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour
{

    public Button playButton;
    public Button quitButton;

	void Start () {
		playButton = playButton.GetComponent<Button>();
        quitButton = playButton.GetComponent<Button>();

		playButton.onClick.AddListener(PlayGame);
		playButton.onClick.AddListener(QuitGame);
	}

    void PlayGame(){
        SceneManager.LoadScene(0);
    }

    void QuitGame(){
        Application.Quit();
    }
}
