using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockPickup : MonoBehaviour
{
    [SerializeField]
    private GameObject pickupObject;
    private InvantoryManiger IManiger;
    // Start is called before the first frame update
    void Start()
    {
        IManiger = GameObject.FindGameObjectWithTag("PlacementUI").GetComponent<InvantoryManiger>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IManiger.AddItemToNextSlot(pickupObject);
        Destroy(gameObject);
    }
}
