using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCredits : MonoBehaviour
{

    [SerializeField] private CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        CollectablesManager.instance.OnAllCollected += AllCollected;
    }

    // Update is called once per frame
    void AllCollected()
    {
        CollectablesManager.instance.OnAllCollected -= AllCollected;


        ScreenFader.instance.OnScreenFadedBlack += WaitBlackScreen;
    }

    void WaitBlackScreen(bool screenState)
    {
        ScreenFader.instance.OnScreenFadedBlack -= WaitBlackScreen;

        canvasGroup.alpha = 0f;
        canvasGroup.gameObject.SetActive(true);

        LeanTween.value(this.gameObject, OnTweenCanvasGroupAlpha, 0f, 1f, 2f).setEase(LeanTweenType.easeOutQuad).setDelay(2f);

    }

    void OnTweenCanvasGroupAlpha(float value)
    {
        canvasGroup.alpha = value;

    }
}
