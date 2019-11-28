using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneTransition : MonoBehaviour
{
    #region scene_variables
    Scene currentScene;
    [SerializeField]
    [Tooltip("The next scene which should be loaded on exiting the level.")]
    string nextScene = "";
    #endregion

    #region Private Variables

    // Keeps track of score after starting a level(if reset score = this).
    private float m_scorekeeper;
    #endregion

    #region unity_functions
    // Start is called before the first frame update
    void Start()
    {
        m_scorekeeper = PlayerPrefs.GetFloat("Score");
        currentScene = SceneManager.GetActiveScene();
        if (nextScene == "")
        {
            nextScene = currentScene.name;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    #region trigger_function
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(nextScene);
        }
    }
    #endregion

    #region level_functions
    public void restart_level()
    {
        Debug.Log("You died!");
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(currentScene.name);
        PlayerPrefs.SetFloat("Score", 0);
    }
    #endregion
}