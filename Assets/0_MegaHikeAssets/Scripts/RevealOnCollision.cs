using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealOnCollision : MonoBehaviour
{

    [SerializeField] private Transform revealRoot;
    private float countDownTimer;

    private void Start()
    {
        revealRoot.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        revealRoot.gameObject.SetActive(true);
        countDownTimer = -1f;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        countDownTimer = 3f;

    }



    private void Update()
    {
        if(countDownTimer > 0f)
        {
            countDownTimer -= Time.deltaTime;

            if(countDownTimer < 0f)
            {
                revealRoot.gameObject.SetActive(false);
            }

        }
    }

}
