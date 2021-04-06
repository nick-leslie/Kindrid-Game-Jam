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
    [SerializeField]
    private float closeDistence;
    private bool lerpFOV;
    private float targetFOV;
    private float FOVLerpTime;
    [SerializeField]
    private float defaltFOVLerpTime;
    private GameObject player;
    private GameObject PlacementUI;
    // Start is called before the first frame update
    void Start()
    {
        dynamicLerp = lerpTime;
        tracked = defaltTracked;
        cam = gameObject.GetComponent<Camera>();
        defaltFOV = cam.fieldOfView;
        targetFOV = defaltFOV;
        FOVLerpTime = defaltFOVLerpTime;
        player = GameObject.FindGameObjectWithTag("Player");
        PlacementUI = GameObject.FindGameObjectWithTag("PlacementUI");
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
        if(targetFOV != Camera.main.fieldOfView)
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, targetFOV, FOVLerpTime * Time.deltaTime);
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
    public void ChangeFOV(float newFOV,float FOVlerp)
    {
        targetFOV = newFOV;
        FOVLerpTime = FOVlerp;
    }
    public void resetFOV()
    {
        targetFOV = defaltFOV;
        FOVLerpTime = defaltFOVLerpTime;
    }
    public void MoveCamera(Transform target, float heldTime)
    {
        smooth = true;
        tracked = target;
        StartCoroutine(ResetCammraAfterLook(heldTime));
    }
    public void MoveCamera(Transform target,float moveLerpTime, float heldTime)
    {
        smooth = true;
        dynamicLerp = moveLerpTime;
        tracked = target;
        StartCoroutine(ResetCammraAfterLook(heldTime));
    }
    public void MoveCamera(Transform target,float moveLerpTime ,float heldTime, float FOV,float FovLerpTime)
    {
        smooth = true;
        tracked = target;
        dynamicLerp = moveLerpTime;
        if (FOV > 0)
        {
            ChangeFOV(targetFOV + FOV, FovLerpTime);
        }
        StartCoroutine(ResetCammraAfterLook(heldTime));
    }
    IEnumerator ResetCammraAfterLook(float heldTime)
    {
        player.GetComponent<Movement>().disableMovement();
        PlacementUI.GetComponent<Canvas>().enabled = false;
        while (Vector2.Distance(transform.position, tracked.position) > closeDistence)
        {
            yield return null;
        }
        yield return new WaitForSecondsRealtime(heldTime);
        resetFOV();
        tracked = defaltTracked;
       
        while(Vector2.Distance(transform.position,defaltTracked.position) > closeDistence)
        {
            yield return null;
        }
        player.GetComponent<Movement>().EnableMovement();
        PlacementUI.GetComponent<Canvas>().enabled = true;
        //Debug.Log("should reset");
        smooth = false;
    }
    public void hardRest()
    {
        StopAllCoroutines();
        targetFOV = defaltFOV;
        Camera.main.fieldOfView = targetFOV;
        smooth = false;
        tracked = defaltTracked;
    }
}
