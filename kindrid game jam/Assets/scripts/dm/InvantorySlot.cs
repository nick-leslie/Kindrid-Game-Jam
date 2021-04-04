using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InvantorySlot : MonoBehaviour
{
    public GameObject currentItem;
    public int amount;
    public Placer Placement;
    public void grabItem(InputAction.CallbackContext context)
    {
        Debug.Log("riddle me piss")
        Placement.Item = currentItem;
        amount--;
        if(amount <= 0)
        {
            //add logic for deleting the 
        }
    }
}
