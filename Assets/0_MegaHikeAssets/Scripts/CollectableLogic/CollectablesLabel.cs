using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectablesLabel : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI label;

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
        label.text = CollectablesManager.instance.GetCollectedString();
    }
    
}
