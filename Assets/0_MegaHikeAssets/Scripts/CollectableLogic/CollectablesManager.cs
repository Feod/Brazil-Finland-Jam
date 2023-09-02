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

    public void ReportCollectableCollected(SingleCollectable thisCollectable)
    {
        collectablesCollected++;

        if (OnUpdateCollectablesCounter != null)
            OnUpdateCollectablesCounter();

        if(collectablesCollected >= maxAmountOfCollectables)
        {

            if (OnAllCollected != null)
                OnAllCollected();

        }
    }


    public string GetCollectedString()
    {
        return collectablesCollected + "/" + maxAmountOfCollectables;
    }

}
