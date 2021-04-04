using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControler : MonoBehaviour
{
    [SerializeField]
    private Transform defaltTracked;
    public Transform tracked;
    [SerializeField]
    private float lerpTime;
    private float dynamicLerp;
    public bool smooth;
    [SerializeField]
    public float defaltFOV;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        dynamicLerp = lerpTime;
        tracked = defaltTracked;
        cam = gameObject.GetComponent<Camera>();
        defaltFOV = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cam = new Vector3(tracked.position.x, tracked.position.y, -10);
        if (smooth == true)
        {
            Vector3 smoothed = Vector3.Lerp(transform.position, cam, dynamicLerp * Time.deltaTime);
            transform.position = smoothed;
        } else
        {
            transform.position = cam;
        }
    }
    public void SwapLerpTiming(float lerpValue)
    {
        dynamicLerp = lerpValue;
        
    }
    public void RestLerp()
    {
        dynamicLerp = lerpTime;
    }
    public void ChangeFOV(float newFOV)
    {
        cam.fieldOfView = newFOV;
    }
    public void resetFOV()
    {
        cam.fieldOfView = defaltFOV;
    }
}
