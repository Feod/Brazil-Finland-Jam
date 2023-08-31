using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickDynamicSpriteColor : MonoBehaviour
{

    [SerializeField] private Color ColorOn;
    [SerializeField] private Color ColorOff;

    [SerializeField] private Image[] joystickImages;

    void Start()
    {
        TouchJoystick myJoystick = this.GetComponent<TouchJoystick>();
        myJoystick.OnJoystickPress += OnJoystickPress;
        myJoystick.OnJoystickRelease += OnJoystickRelease;

        OnJoystickRelease();
    }

    void OnJoystickPress()
    {
        if (LeanTween.isTweening(this.gameObject))
            LeanTween.cancel(this.gameObject);

        for(int i = 0; i < joystickImages.Length; i++)
        {
            joystickImages[i].color = ColorOn;
        }
    }

    void OnJoystickRelease()
    {
        LeanTween.value(this.gameObject, OnTweenImages, joystickImages[0].color, ColorOff, 0.2f).setEase(LeanTweenType.easeOutQuad);
    }

    void OnTweenImages(Color value)
    {
        for (int i = 0; i < joystickImages.Length; i++)
        {
            joystickImages[i].color = value;
        }
    }
}
