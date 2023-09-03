using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleShakeAnim : MonoBehaviour
{

    [SerializeField] private Transform animRoot;

    void Start()
    {

        animRoot.localEulerAngles = new Vector3(0f, 0f, -10f);

        LeanTween.rotateLocal(animRoot.gameObject, new Vector3(0f, 0f, 10f), 0.5f).setEase(LeanTweenType.easeInOutQuad).setLoopPingPong();
        LeanTween.scale(animRoot.gameObject, animRoot.localScale * 1.1f, 0.25f).setEase(LeanTweenType.easeOutQuad).setLoopPingPong();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
