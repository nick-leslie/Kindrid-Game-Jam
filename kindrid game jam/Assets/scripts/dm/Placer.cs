using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Placer : MonoBehaviour
{
    public GameObject Item;
    private void dropItem(InputAction.CallbackContext contxt)
    {
        Instantiate(Item);
        Item = null;
    }
}
