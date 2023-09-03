using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesManager : MonoBehaviour
{

    public System.Action OnUpdateCollectablesCounter;
    public System.Action OnAllCollected;

    public static CollectablesManager instance;
    public int maxAmountOfCollectables;
    public int collectablesCollected;

    void Awake()
    {
        instance = this;
        
    }


    public void ReportNewCollectable(SingleCollectable thisCollectable)
    {
        maxAmountOfCollectables++;

        if (OnUpdateCollectablesCounter != null)
            OnUpdateCollectablesCounter();
    }

    //Collected happening!
    public void ReportCollectableCollected(SingleCollectable thisCollectable)
    {
        collectablesCollected++;

        ScreenFader.instance.FadeScreenBlack();

        if (OnUpdateCollectablesCounter != null)
            OnUpdateCollectablesCounter();

        if(collectablesCollected >= maxAmountOfCollectables)
        {

            ScreenFader.instance.neverFadeBack = true;


            if (OnAllCollected != null)
                OnAllCollected();

        }
    }


    public string GetCollectedString()
    {
        return collectablesCollected + "/" + maxAmountOfCollectables;
    }

}
