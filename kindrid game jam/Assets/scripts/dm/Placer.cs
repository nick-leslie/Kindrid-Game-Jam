using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Placer : MonoBehaviour
{
    public GameObject Item;
    public Vector3 screenPoint;
    private Vector2 screenPointRaw;
    public void Update()
    {
        //Debug.Log(context.ReadValue<float>());
        screenPointRaw = Input.mousePosition;
        screenPoint = new Vector3(screenPointRaw.x, screenPointRaw.y,Camera.main.nearClipPlane);
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            if (Item != null)
            {
                Vector3 camPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPoint.x, screenPoint.y, 10));
                Debug.Log(camPos);
                Vector3 pos = new Vector3(camPos.x, camPos.y, 0);
                Instantiate(Item, pos, Quaternion.identity);
                Item = null;
            }
        }
    }
}
