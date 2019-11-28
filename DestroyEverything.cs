using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEverything : MonoBehaviour
{

    #region unity_functions
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    #region trigger_functions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<ZoneTransition>().restart_level();
        }
        if (collision.tag == "Floor")
        {
            return;
        }
        if (collision.tag == "GameController")
        {
            return;
        }
        Destroy(collision.gameObject);
    }
    #endregion
}
