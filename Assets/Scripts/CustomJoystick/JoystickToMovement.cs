using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickToMovement : MonoBehaviour
{

    private TouchJoystick joystickScript;

    // Start is called before the first frame update
    void Start()
    {
        joystickScript = this.gameObject.GetComponent<TouchJoystick>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //dbMovement.instance.playerJoystick = joystickScript.joystickSize;
    }


}
