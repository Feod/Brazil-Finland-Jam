using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkParticles : MonoBehaviour
{

    [SerializeField] private Rigidbody2D playerRigid;

    public ParticleSystem walkParticles;
    private ParticleSystem.EmissionModule emissionModule;

    private int walkState;

    private void Start()
    {
        CharacterIddle();
    }

    private void FixedUpdate()
    {
        if(playerRigid.velocity.sqrMagnitude > 0.2f && walkState == 0)
        {
            CharacterRunning();
        }
        else if (playerRigid.velocity.sqrMagnitude < 0.2f && walkState == 1)
        {
            CharacterIddle();
        }
    }

    void CharacterRunning()
    {
        walkState = 1;
        //Particles:
        if (walkParticles != null)
        {
            emissionModule = walkParticles.emission;
            emissionModule.enabled = true;
        }
    }

    void CharacterIddle()
    {
        walkState = 0;
        //Particles:
        if (walkParticles != null)
        {
            emissionModule = walkParticles.emission;
            emissionModule.enabled = false;
        }
    }

}
