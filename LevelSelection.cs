using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    // Start is called before the first frame update
    #region Intialization
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    #endregion

    #region Play Buttons Methods
    public void Level_1()
    {
        PlayerPrefs.SetFloat("Score", 0);
        SceneManager.LoadScene("Level 1");
    }

    public void Level_2()
    {
        PlayerPrefs.SetFloat("Score", 0);
        SceneManager.LoadScene("Level 2");
    }

    public void Level_3()
    {
        PlayerPrefs.SetFloat("Score", 0);
        SceneManager.LoadScene("Level 3");
    }

    public void Level_4()
    {
        PlayerPrefs.SetFloat("Score", 0);
        SceneManager.LoadScene("Level 4");
    }

    public void Level_5()
    {
        PlayerPrefs.SetFloat("Score", 0);
        SceneManager.LoadScene("Level 5");
    }

    public void Level_6()
    {
        PlayerPrefs.SetFloat("Score", 0);
        SceneManager.LoadScene("Level 6");
    }

    public void Play_Endless()
    {
        PlayerPrefs.SetFloat("Score", 0);
        SceneManager.LoadScene("Endless Mode");
    }
    #endregion

    #region Return to Menu
    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    #endregion
}
