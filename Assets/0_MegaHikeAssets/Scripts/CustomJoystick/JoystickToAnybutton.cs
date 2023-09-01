using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickToAnybutton : MonoBehaviour
{


    void Start()
    {
        this.gameObject.GetComponent<TouchJoystick>().OnJoystickPress += OnJoystickPress;
    }

    void OnJoystickPress()
    {
        Anybutton.instance.SomethingPressedAnybutton();
    }


}
