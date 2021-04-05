using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InvantoryManiger : MonoBehaviour
{
    public InvantorySlot[] slots;
    public GameObject[] slotObj;
    public void Start()
    {
        slotObj = GameObject.FindGameObjectsWithTag("InvantroySlot");
        slots = new InvantorySlot[slotObj.Length];
        for (int i = 0; i < slotObj.Length; i++)
        {
            slots[i] = slotObj[i].GetComponent<InvantorySlot>();
        }
    }
    public void AddItemToNextSlot(GameObject ProposedItem)
    {
        for(int i=0; i < slots.Length;i++)
        {
            if(slots[i].CurrentItem == ProposedItem)
            {
                slots[i].amount += 1;
                break;
            }
            if(slots[i].CurrentItem == null)
            {
                slots[i].CurrentItem = ProposedItem;
                Image slotImg = slotObj[i].GetComponent<Image>();
                slotImg.enabled = true;
                slotImg.sprite = ProposedItem.GetComponent<SpriteRenderer>().sprite;
                break;
            }
        }
    }
}
