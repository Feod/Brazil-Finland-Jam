using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopPlayerWorld : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Transform cameraRoot;

    [SerializeField] private ParticleSystem walkParticles;

    private float loopX = 20f;
    private float loopY = 20f;


    private void Update()
    {

        if(player.position.x > loopX)
        {
            MovePlayer(-loopX * 1.9f, 0f);
        }

        if (player.position.x < -loopX)
        {
            MovePlayer(loopX * 1.9f, 0f);
        }

        if (player.position.y > loopY)
        {
            MovePlayer(0f,-loopY * 1.9f);
        }

        if (player.position.y < -loopY)
        {
            MovePlayer(0f,loopY * 1.9f);
        }

    }

    private void MovePlayer(float xAmount, float yAmount)
    {
        //walkParticles.simulationSpace = ParticleSystemSimulationSpace.Local;

        walkParticles.simulationSpace = ParticleSystemSimulationSpace.Local;
        ParticleSystem.MainModule mmainModule = walkParticles.main;
        mmainModule.simulationSpace = ParticleSystemSimulationSpace.Local;

        player.position += new Vector3(xAmount, yAmount);
        cameraRoot.position += new Vector3(xAmount, yAmount);

        walkParticles.simulationSpace = ParticleSystemSimulationSpace.World;
        ParticleSystem.MainModule mmainModuleB = walkParticles.main;
        mmainModuleB.simulationSpace = ParticleSystemSimulationSpace.World;

    }

}
