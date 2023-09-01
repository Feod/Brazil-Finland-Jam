using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform cameraRoot;

    [SerializeField] private Transform playerRoot;


    void LateUpdate()
    {
        cameraRoot.position = Vector3.Lerp(cameraRoot.position, playerRoot.position, Time.deltaTime * 3f);
    }


}
