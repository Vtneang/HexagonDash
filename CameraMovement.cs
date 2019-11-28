using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    #region camera_move_variables
    public float speed = 1;
    #endregion

    #region unity_functions
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed*Time.deltaTime, 0f, 0f);
    }
    #endregion
}
