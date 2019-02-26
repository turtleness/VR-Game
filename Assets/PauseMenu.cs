using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    // Use this for initialization
    public static bool GameStopped = false;

    public GameObject pauseMenuUI;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameStopped)
            {
                Resume();
            } else
            {
                Pause();
            }
            }
        }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameStopped = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameStopped = true;
    }

    public void QuitGame()
    {
        Debug.Log("Game Has Quit!");
        Application.Quit();
    }

    public void Options()
    {

    }
}

//add to audieManager
//if (PauseMenu.GameStopped)
//    {
//    s.source.pitch *=.5f;
//    }