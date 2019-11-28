using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{

    #region perspective_variables
    float horizontalLength = 20f;
    #endregion

    #region unity_functions
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<Camera>().transform.position.x - transform.position.x > horizontalLength)
        {
            RepositionBackground();
        }
    }
    #endregion

    #region perspective_functions
    void RepositionBackground()
    {
        Vector2 backgroundOffset = new Vector2(horizontalLength * 2f, 0);
        transform.position = (Vector2) transform.position + backgroundOffset;
    }
    #endregion
}
