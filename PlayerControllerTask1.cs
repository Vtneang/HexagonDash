using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControllerTask1: MonoBehaviour {

    #region Editor Variables
    public float movespeed;
	public float maxspeed;
	public float jumpforce;
	int FloorLayer;
	Rigidbody2D playerRB;
    #endregion

    #region Movement Variables
    public bool canDash; 
    public bool isChargingDash;
    public float chargeCounter;
    public float maxChargeCounter = 50;
    public float currentTimer;
    public float maxTimer; 
    #endregion

    bool canJump;


	void Awake() {
		FloorLayer = LayerMask.NameToLayer ("Floor");
		playerRB = gameObject.GetComponent<Rigidbody2D> ();
        canJump = false;
	}

	void Update () {

        currentTimer += Time.deltaTime; 
		//Movement
		float MoveHor = Input.GetAxisRaw ("Horizontal");
		Vector2 movement = new Vector2 (MoveHor * movespeed, 0);
		movement = movement * Time.deltaTime;

		playerRB.AddForce(movement);
		if (playerRB.velocity.x > maxspeed) {
			playerRB.velocity = new Vector2 (maxspeed, playerRB.velocity.y);
		}
		if (playerRB.velocity.x < -maxspeed) {
			playerRB.velocity = new Vector2 (-maxspeed, playerRB.velocity.y);
		}

		//TASK 1: If someone pushes the space button and?
		if (Input.GetKeyDown(KeyCode.Space) & canJump) {
			playerRB.velocity = new Vector2 (playerRB.velocity.x, 0).normalized;
			playerRB.AddForce ( new Vector2(0, jumpforce));
		}

        if (Input.GetKey(KeyCode.LeftShift))
        { 
            isChargingDash = true;
            chargeCounter = Mathf.Clamp(chargeCounter + 10, 0, maxChargeCounter);
            playerRB.AddForce(new Vector2(-chargeCounter / 8, 0)); 
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift) && isChargingDash && canDashNow())
        {
            Debug.Log("Charge!!");
            Debug.Log(chargeCounter); 
            float chargeVal = Mathf.Min(chargeCounter, maxChargeCounter);
            playerRB.AddForce(new Vector2(chargeVal * 3, 0));
        } else
        {
            chargeCounter = 0;
            isChargingDash = false;
            canDash = false;
        }
	}
	// Returns if the given GameObject is a floor, platform, or wall
	bool isFloor(GameObject obj) {
		return obj.layer == FloorLayer;
	}

    bool canDashNow()
    {
        return currentTimer >= maxTimer; 
    }

    // This function is called whenever the Collider2D attached to the gameobject comes into contact with another collider
    // use coll.gameObject if you need a reference coll's GameObject
    void OnCollisionEnter2D(Collision2D coll) {
        canJump = true; 
	}

    void OnCollisionStay2D(Collision2D coll)
    {
        canJump = true;
        canDash = true; 
    }

    // This function is called whenever the Collider2D attached to the gameobject leaves contact with another collider
    void OnCollisionExit2D(Collision2D coll) {
        canJump = false;
	}
}
