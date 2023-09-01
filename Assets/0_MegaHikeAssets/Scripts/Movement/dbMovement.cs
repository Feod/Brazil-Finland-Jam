using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dbMovement : MonoBehaviour
{

    public Transform myTransform;
    [SerializeField] private Rigidbody2D playerRigid;

    public Vector2 playerJoystick;
    private float speed = 100f;
    private float speedVelocity = 20f;

    private float additionalSpeedScale = 1f;

    //For estimating player position for sharp-shooters
    public Transform playerPositionInFuture;


    public static dbMovement instance;
    private void Awake()
    {
        instance = this;
    }



    private void FixedUpdate()
    {

        /*
        if (GameState.instance.playerControlDissabled)
        {
            playerJoystick = Vector2.zero;
            return;
        }
            

        if (dbPlayer.instance.playerAlive == false)
            return;
        */


        //Estimate player position (This is before assignment, because sometimes. Player is just pushing wall)
        //playerPositionInFuture.position = playerRigid.position + playerRigid.velocity * 0.2f;
        playerPositionInFuture.position = playerRigid.position + playerRigid.velocity * 0.4f + playerJoystick;



        //If joystick is not in dead area. Move character to the direction.

        if (playerJoystick.sqrMagnitude > 0.05f)
        {

            //playerRigid.AddForce(playerJoystick * speed);

            playerRigid.velocity = playerJoystick * speedVelocity * additionalSpeedScale;


        }

        
    }



}
