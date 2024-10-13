using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void StarGame()
    {
        SceneManager.LoadScene("Gamelv2");
    }

    public void QuitGame()
    {
        Application.Quit();
        print("Game Close");
    }

    public void ContinuarGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void FinalGame()
    {
        SceneManager.LoadScene("Final");
    }

    public void MenuGame()
    {
        SceneManager.LoadScene("MainPrincipal");
    }
}
