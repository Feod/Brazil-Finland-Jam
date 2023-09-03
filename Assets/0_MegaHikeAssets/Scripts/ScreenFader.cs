using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{

    public Action<bool> OnScreenFadedBlack;

    [SerializeField] private Gradient fadeGradient;
    [SerializeField] private Image screenFade;

    private float timerGoingDown;
    public bool neverFadeBack;

    public static ScreenFader instance;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        timerGoingDown = 3f;
    }

    /*
    // Update is called once per frame
    void Update()
    {
        timerGoingDown -= Time.deltaTime;

        if(timerGoingDown < 0f)
        {
            timerGoingDown = UnityEngine.Random.Range(7f, 15f);
            FadeScreenBlack();
        }

    }
    */



    //------

    public void FadeScreenBlack()
    {
        LeanTween.value(this.gameObject, OnTweenScreen, 0f, 1f, 0.333f).setOnComplete(OnCompleteScreenBlack).setEase(LeanTweenType.easeOutQuad);
    }

    void OnTweenScreen(float value)
    {
        screenFade.color = fadeGradient.Evaluate(value);
    }

    void OnCompleteScreenBlack()
    {
        if (OnScreenFadedBlack != null)
            OnScreenFadedBlack(true);

        if(neverFadeBack == false)
            LeanTween.value(this.gameObject, OnTweenScreen, 1f, 0f, 0.6f).setOnComplete(OnCompleteScreenSeeThrough).setDelay(0.05f).setEase(LeanTweenType.easeInOutQuad);

    }

    void OnCompleteScreenSeeThrough()
    {
        if (OnScreenFadedBlack != null)
            OnScreenFadedBlack(false);
    }

    //------
    /*
    public void FadeScreenBlack_Forever()
    {
        LeanTween.value(this.gameObject, OnTweenScreen, 0f, 1f, 0.8f).setOnComplete(OnCompleteScreenBlack_Forever).setEase(LeanTweenType.easeOutQuad);
    }

    void OnCompleteScreenBlack_Forever()
    {
        if (OnScreenFadedBlack != null)
            OnScreenFadedBlack(true);

    }
    */

}
