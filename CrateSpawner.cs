using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawner : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The bounds of the espawner")]
    private Vector2 m_Bounds;

    [SerializeField]
    [Tooltip("A list of all the enemies that can be spawned and their info.")]
    private SpawnManager[] m_Enemies;
    #endregion

    #region Intialization
    private void Awake()
    {
        StartSpawning();
    }
    #endregion

    #region Spawning Method

    public void StartSpawning()
    {
        for (int i = 0; i < m_Enemies.Length; i++)
        {
            StartCoroutine(Spawn(i));
        }
    }

    private IEnumerator Spawn(int enemyId)
    {
        SpawnManager info = m_Enemies[enemyId];
        int i = 0;
        bool alwaysSpawn = false;
        if (info.NumberToSpawn == 0)
        {
            alwaysSpawn = true;
        }
        while (alwaysSpawn || i < info.NumberToSpawn)
        {
            yield return new WaitForSeconds(info.TimeToNextSpawn);
            float xVal = m_Bounds.x / 2;
            float yVal = m_Bounds.y / 2;

            Vector3 spawnPos = new Vector2(
                Random.Range(-xVal, xVal),
                Random.Range(-yVal, yVal));

            spawnPos += transform.position;
            Instantiate(info.EnemyGo, spawnPos, Quaternion.identity);
            if (alwaysSpawn)
            {
                i++;
            }
        }
    }

    #endregion
}
