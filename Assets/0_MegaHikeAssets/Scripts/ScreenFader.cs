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

    void FadeScreenBlack()
    {
        LeanTween.value(this.gameObject, OnTweenScreen, 0f, 1f, 3f).setOnComplete(OnCompleteScreenBlack);
    }

    void OnTweenScreen(float value)
    {
        screenFade.color = fadeGradient.Evaluate(value);
    }

    void OnCompleteScreenBlack()
    {
        if (OnScreenFadedBlack != null)
            OnScreenFadedBlack(true);

        LeanTween.value(this.gameObject, OnTweenScreen, 1f, 0f, 3f).setOnComplete(OnCompleteScreenSeeThrough).setDelay(0.5f);

    }

    void OnCompleteScreenSeeThrough()
    {
        if (OnScreenFadedBlack != null)
            OnScreenFadedBlack(false);
    }

}
