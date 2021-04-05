using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class InvantorySlot : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public GameObject CurrentItem;
    public int amount;
    [SerializeField]
    public Vector3 screenPoint;
    private Vector2 screenPointRaw;
    private GameObject dragElement;
    private Canvas canvas;
    private Vector2 lastMousePosition;
    public void Start()
    {
        dragElement = GameObject.FindGameObjectWithTag("DragElement");
        canvas = GameObject.FindGameObjectWithTag("PlacementUI").GetComponent<Canvas>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (amount > 0)
        {
            Image imgElemnt = dragElement.GetComponent<Image>();
            imgElemnt.enabled = true;
            imgElemnt.sprite = gameObject.GetComponent<Image>().sprite;

            dragElement.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
            dragElement.transform.position = gameObject.transform.position;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (amount > 0)
        {
            dragElement.GetComponent<RectTransform>().anchoredPosition = eventData.delta / canvas.scaleFactor;
            dragElement.transform.position = Input.mousePosition;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Image imgElemnt = dragElement.GetComponent<Image>();
        imgElemnt.enabled = false;
        screenPointRaw = Input.mousePosition;
        screenPoint = new Vector3(screenPointRaw.x, screenPointRaw.y, Camera.main.nearClipPlane);
            if (CurrentItem != null)
            {
                Vector3 camPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPoint.x, screenPoint.y, 10));
                Vector3 pos = new Vector3(camPos.x, camPos.y, 0);
                Instantiate(CurrentItem, pos, Quaternion.identity);
            }
        if (amount-1 <= 0)
        {
            amount--;
            CurrentItem = null;
            gameObject.GetComponent<Image>().enabled = false;
            //add logic for deleting the 
        } 
        else
        {
            amount--;
        }
    }
    private bool IsRectTransformInsideSreen(RectTransform rectTransform)
    {
        bool isInside = false;
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        int visibleCorners = 0;
        Rect rect = new Rect(0, 0, Screen.width, Screen.height);
        foreach (Vector3 corner in corners)
        {
            if (rect.Contains(corner))
            {
                visibleCorners++;
            }
        }
        if (visibleCorners == 4)
        {
            isInside = true;
        }
        return isInside;
    }
}
