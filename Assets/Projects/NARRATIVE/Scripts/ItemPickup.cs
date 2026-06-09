using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    private bool canPickUp;
    [SerializeField] private InputActionReference pickUp;

    void Update()
    {
        bool Input = pickUp.action.WasPressedThisFrame();
        if (Input == true && canPickUp)
        {
            Debug.Log("PickedUp Item");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp")) 
        { 
            canPickUp = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
            canPickUp = false;
    }
}
