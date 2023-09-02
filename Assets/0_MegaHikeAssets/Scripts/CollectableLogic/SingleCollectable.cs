using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCollectable : MonoBehaviour
{

    private bool collected;

    void Start()
    {
        CollectablesManager.instance.ReportNewCollectable(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if(collected == false)
            {
                collected = true;
                CollectablesManager.instance.ReportCollectableCollected(this);
                this.gameObject.SetActive(false);
            }

        }
    }
}
