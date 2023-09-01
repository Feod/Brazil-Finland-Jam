using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anybutton : MonoBehaviour
{

    public System.Action OnAnybuttonPressed;

    public static Anybutton instance;
    private void Awake()
    {
        instance = this;
    }

    public void SomethingPressedAnybutton()
    {
        if (OnAnybuttonPressed != null)
            OnAnybuttonPressed();
    }

}
