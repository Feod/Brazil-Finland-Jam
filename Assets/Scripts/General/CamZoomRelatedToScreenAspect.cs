using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoomRelatedToScreenAspect : MonoBehaviour
{

    [SerializeField] private Camera targetCamera;
    private float defaultZoom;

    public float aspect;
    public float aspectReverse;


    // Start is called before the first frame update
    void Start()
    {
        defaultZoom = targetCamera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        aspect = (float)Screen.width / (float)Screen.height;
        aspectReverse = (float)Screen.height / (float)Screen.width;
        targetCamera.orthographicSize = defaultZoom * (0.333f + aspectReverse*0.666f);
        //targetCamera.orthographicSize = defaultZoom * aspectReverse;

    }
}
