using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{ 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetStage();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    private void ResetStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadNextStage());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void QuitGame()
    {

    }
    
    IEnumerator LoadNextStage()
    {
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
