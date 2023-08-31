using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTargetFramerate : MonoBehaviour
{

    void Start()
    {
        Application.targetFrameRate = 60;
    }

}
