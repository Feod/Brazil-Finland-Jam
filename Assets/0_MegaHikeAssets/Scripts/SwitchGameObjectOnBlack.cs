using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGameObjectOnBlack : MonoBehaviour
{

    
    [SerializeField] private GameObject[] switchables;
    private int currentSelected;

    // Start is called before the first frame update
    void Start()
    {
        ScreenFader.instance.OnScreenFadedBlack += OnBlack;
    }

    // Update is called once per frame
    void OnBlack(bool value)
    {
        if (value == false)
            return;

        switchables[currentSelected].SetActive(false);

        currentSelected++;
        if (currentSelected >= switchables.Length)
            currentSelected = 0;

        switchables[currentSelected].SetActive(true);


    }
}
