using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TouchJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    public System.Action OnJoystickPress;
    public System.Action OnJoystickRelease;

    [SerializeField] private bool lockJoystickCenter;

    [SerializeField] private bool resetJoystickPositionOnRelease;


    [SerializeField] private RectTransform touchArea = default;
    [SerializeField] private Camera uiCam = default;


    [SerializeField] private RectTransform touchStart = default;
    [SerializeField] private RectTransform touchDrag = default;

    private Vector2 startPosition;
    private Vector2 dragPosition;

    private Vector2 uiFingerPosition;


    private float maxDragDistance = 50f;
    public Vector2 joystickSize;

    //----

    public static TouchJoystick instance;
    void Awake()
    {
        instance = this;
    }

    //---

    public void OnPointerDown(PointerEventData eventData)
    {

        //Not sure if this conversion is too expensive, but it works.
        RectTransformUtility.ScreenPointToLocalPointInRectangle(touchArea, eventData.position, uiCam, out uiFingerPosition);
        dragPosition = uiFingerPosition;
        touchDrag.anchoredPosition = uiFingerPosition;

        if (lockJoystickCenter)
        {
            startPosition = touchStart.anchoredPosition;
            OnDrag(eventData);
        }
        else
        {
            //startPosition = eventData.position;
            touchStart.anchoredPosition = uiFingerPosition;
            startPosition = uiFingerPosition;
        }

        if (OnJoystickPress != null)
            OnJoystickPress();

    }

    public void OnDrag(PointerEventData eventData)
    {

        //Another probably expensive conversion.
        RectTransformUtility.ScreenPointToLocalPointInRectangle(touchArea, eventData.position, uiCam, out uiFingerPosition);
        dragPosition = uiFingerPosition;

        //Joystick size in UI
        joystickSize = dragPosition - startPosition;

        //Cap the drag distance if too much.
        if(joystickSize.magnitude > maxDragDistance)
        {

            //Drag start point with the finger, like in BrawlStars
            if(lockJoystickCenter == false)
            {

                //Only on 120% have the base follow, so that we don't lose joystick max value to finger jitter
                if (joystickSize.magnitude > 1.2f * maxDragDistance)
                {
                    joystickSize = joystickSize.normalized * 1.2f * maxDragDistance;

                    startPosition = dragPosition - joystickSize;
                    touchStart.anchoredPosition = startPosition;
                }
                else
                {
                    joystickSize = joystickSize.normalized * maxDragDistance;
                }

                

            }
            else
            {
                joystickSize = joystickSize.normalized * maxDragDistance;
                dragPosition = startPosition + joystickSize;
            }

        }

        //So that the joystick will always remain between 0f and 1f
        joystickSize = joystickSize / maxDragDistance;

        touchDrag.anchoredPosition = dragPosition;


    }

    public void OnPointerUp(PointerEventData eventData)
    {

        //Another probably expensive conversion.
        RectTransformUtility.ScreenPointToLocalPointInRectangle(touchArea, eventData.position, uiCam, out uiFingerPosition);

        dragPosition = startPosition;
        joystickSize = Vector2.zero;

        touchDrag.anchoredPosition = startPosition;

        if (OnJoystickRelease != null)
            OnJoystickRelease();

        if (resetJoystickPositionOnRelease)
        {
            //Reset joystick positions back to normal start position.
            touchStart.anchoredPosition = Vector2.zero;
            touchDrag.anchoredPosition = Vector2.zero;
        }
        else
        {
            touchDrag.anchoredPosition = touchStart.anchoredPosition;
        }

    }


}
