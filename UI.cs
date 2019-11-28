using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{

    #region Editor Variables
    [SerializeField]
    [Tooltip("Show the score per seconds since the start.")]
    public float m_ScorePerSec;

    [SerializeField]
    [Tooltip("The UI that keeps track of score")]
    public Text m_Score_Tracker;
    #endregion

    #region Private Variables
    //Show the current score.
    private float m_CurrScore;
    #endregion

    #region Intialization
    private void Awake()
    {
        m_CurrScore = PlayerPrefs.GetFloat("Score");
    }
    #endregion

    #region Main Update
    private void Update()
    {
        m_CurrScore += m_ScorePerSec * Time.deltaTime;
        score(Mathf.Round(m_CurrScore));
    }
    #endregion

    #region ScoreKeeping
    public void score(float num)
    {
        m_Score_Tracker.text = num.ToString();
        PlayerPrefs.SetFloat("Score", num);
    }
    #endregion

    #region Quit Button
    public void Quit_to_Menu()
    {
        PlayerPrefs.SetFloat("Score", 0);
        SceneManager.LoadScene("Main Menu");
    }
    #endregion


}
