using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectablesLabel : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI label;

    [SerializeField] private Transform tweenRoot;


    // Start is called before the first frame update
    void Start()
    {
        CollectablesManager.instance.OnUpdateCollectablesCounter += UpdateLabel;
        UpdateLabel();
    }

    private void OnDestroy()
    {
        CollectablesManager.instance.OnUpdateCollectablesCounter -= UpdateLabel;
    }


    void UpdateLabel()
    {

        if(LeanTween.isTweening(tweenRoot.gameObject) == false)
        {
            LeanTween.scale(tweenRoot.gameObject, tweenRoot.localScale * 1.2f, 0.8f).setEase(LeanTweenType.punch);
        }

        label.text = CollectablesManager.instance.GetCollectedString();
    }
    
}
