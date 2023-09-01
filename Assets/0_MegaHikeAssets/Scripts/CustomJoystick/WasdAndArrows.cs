using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasdAndArrows : MonoBehaviour
{

    public static WasdAndArrows instance;

    public Vector2 wasdDirection;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        wasdDirection.x = Input.GetAxis("Horizontal");
        wasdDirection.y = Input.GetAxis("Vertical");

        if(wasdDirection.magnitude > 1f)
        {
            wasdDirection = wasdDirection.normalized;
        }

    }
}
