using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class CameraManager : MonoBehaviour
{
    public GameObject map;

    private static readonly int minZoom = -1;
    private static readonly int maxZoom = 1;
    private int currentZoom = 0;
    private Camera cam;
    private PixelPerfectCamera pix;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        pix = GetComponent<PixelPerfectCamera>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ZoomIn()
    {
        if(currentZoom > minZoom)
        {
            pix.enabled = false;
            cam.orthographicSize /= 2;
            Debug.Log(cam.orthographicSize);
            currentZoom--;
        }
        
    }

    public void ZoomOut()
    {
        if(currentZoom < maxZoom)
        {
            pix.enabled = false;
            Debug.Log(cam.orthographicSize);
            cam.orthographicSize *= 2;
            Debug.Log(cam.orthographicSize);
            currentZoom++;
        }
        
    }

    public void MapSwitch()
    {
        map.SetActive(!map.activeSelf);

    }
}
