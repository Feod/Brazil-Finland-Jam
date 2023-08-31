using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickToAimer : MonoBehaviour
{
    private TouchJoystick joystickScript;
    [SerializeField] private Transform playerLookTarget;

    [SerializeField] private Vector3 lookTargetTargetPosition;
    [SerializeField] private bool useLerp;

    void Start()
    {
        joystickScript = this.gameObject.GetComponent<TouchJoystick>();
        joystickScript.OnJoystickPress += OnJoystickPress;
        joystickScript.OnJoystickRelease += OnJoystickRelease;

    }

    void LateUpdate()
    {
        if (useLerp)
        {
//            lookTargetTargetPosition = dbMovement.instance.myTransform.position + (Vector3)joystickScript.joystickSize * 5f;
            playerLookTarget.position = Vector3.Lerp(playerLookTarget.position, lookTargetTargetPosition, Time.unscaledDeltaTime * 10f);
            return;
        }

//        playerLookTarget.position = dbMovement.instance.myTransform.position + (Vector3)joystickScript.joystickSize*5f;
    }


    void OnJoystickPress()
    {
        if (useLerp)
        {
//            playerLookTarget.position = dbMovement.instance.myTransform.position + (Vector3)joystickScript.joystickSize * 5f;
        }

//        dbAimer.instance.AimOn(true);
    }

    void OnJoystickRelease()
    {
//        dbAimer.instance.AimOn(false);
    }




}
