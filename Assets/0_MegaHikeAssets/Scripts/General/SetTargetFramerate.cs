using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTargetFramerate : MonoBehaviour
{

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

}
