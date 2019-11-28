using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    #region Intialization
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    #endregion

    #region Play Buttons Methods
    public void PlayLevel_1()
    {
        PlayerPrefs.SetFloat("Score", 0);
        SceneManager.LoadScene("Level 1");
    }

    public void Play_Endless()
    {
        SceneManager.LoadScene("Level Selector");
    }
    #endregion

    #region General Application Button Methods
    public void Quit()
    {
        Application.Quit();
    }
    #endregion
}
