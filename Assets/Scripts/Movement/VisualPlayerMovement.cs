using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualPlayerMovement : MonoBehaviour
{

    [SerializeField] private SpriteRenderer playerSpriteRenderer;

    [SerializeField] private Sprite[] playerSprites;

    [SerializeField] private Transform rotateRoot;


    //Unity animations
    [SerializeField] private Animator bunnyAnimator;
    private bool runstate;
    

    // Update is called once per frame
    void FixedUpdate()
    {

        //When player is not aiming. Have joystick direction be the viz direction.
        //When player is aiming. Have aim direction be the viz

        float angle = 0f;

        if (dbMovement.instance.playerJoystick.y > 0.65f)
        {

            //angle = Vector2.SignedAngle(new Vector2(0f, 1f), dbMovement.instance.playerJoystick);

            playerSpriteRenderer.sprite = playerSprites[1];
        }
        else if (dbMovement.instance.playerJoystick.y < -0.65f)
        {

            //angle = -Vector2.SignedAngle(new Vector2(0f, -1f), dbMovement.instance.playerJoystick);

            playerSpriteRenderer.sprite = playerSprites[0];
        }
        else if (dbMovement.instance.playerJoystick.x < -0.1f)
        {

            //angle = Vector2.SignedAngle(new Vector2(-1f, 0f), dbMovement.instance.playerJoystick);

            playerSpriteRenderer.flipX = true;
            playerSpriteRenderer.sprite = playerSprites[2];
        }
        else if (dbMovement.instance.playerJoystick.x > 0.1f)
        {

            //angle = Vector2.SignedAngle(new Vector2(1f, 0f), dbMovement.instance.playerJoystick);

            playerSpriteRenderer.flipX = false;
            playerSpriteRenderer.sprite = playerSprites[2];
        }

        //rotateRoot.localEulerAngles = new Vector3(0f, 0f, angle*0.25f);

        //Rotate character based on how much left or right movement.
        angle = dbMovement.instance.playerJoystick.x * 15f;
        rotateRoot.localEulerAngles = new Vector3(0f, 0f, -angle);

        //----------

        // solve run state and report to animator
        if(dbMovement.instance.playerJoystick.sqrMagnitude > 0.1f)
        {
            if(runstate == false)
            {
                runstate = true;
                bunnyAnimator.SetBool("running", true);
            }
        }
        else if(runstate == true)
        {
            runstate = false;
            bunnyAnimator.SetBool("running", false);

        }


    }

    /// <summary>
    /// Snaps the input Vector2 to the nearest angle, starting from Vector2.right and circling counterclockwise
    /// </summary>
    /// <param name="vector">The vector to be processed</param>
    /// <param name="increments">Number of increments (recommended: power of 2, value of 4 or greater)</param>
    /// <returns></returns>
    public static Vector2 SnapAngle(Vector2 vector, int increments)
    {
        float angle = Mathf.Atan2(vector.y, vector.x);
        float direction = ((angle / Mathf.PI) + 1) * 0.5f; // Convert to [0..1] range from [-pi..pi]
        float snappedDirection = Mathf.Round(direction * increments) / increments; // Snap to increment
        snappedDirection = ((snappedDirection * 2) - 1) * Mathf.PI; // Convert back to [-pi..pi] range
        Vector2 snappedVector = new Vector2(Mathf.Cos(snappedDirection), Mathf.Sin(snappedDirection));
        return vector.magnitude * snappedVector;
    }


}
