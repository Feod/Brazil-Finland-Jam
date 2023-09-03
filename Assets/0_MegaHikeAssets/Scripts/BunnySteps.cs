using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnySteps : MonoBehaviour
{

    public float sqrVelocity;

    [SerializeField] private Rigidbody2D myRb;
    [SerializeField] private Transform myTrans;
    private float timeUntilNextStepSound = 1f;

    private void Update()
    {

        sqrVelocity = myRb.velocity.sqrMagnitude;

        timeUntilNextStepSound -= Time.deltaTime* Mathf.Clamp(sqrVelocity,0f,1f);

        if(timeUntilNextStepSound <= 0f)
        {
            //AudioControlBulletTime.instance.PlayAudio("bunnyStep", myTrans.position);
            AudioController.Play("walkStep");
            timeUntilNextStepSound = 0.1f;
        }

    }
}
