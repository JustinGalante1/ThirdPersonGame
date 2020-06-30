using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject pickupSprite;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("GameController").GetComponent<Inventory>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            for(int x = 0; x < inventory.slots.Length; x++)
            {
                if(inventory.isFull[x] == false)
                {
                    Instantiate(pickupSprite, inventory.slots[x].transform, false);
                    inventory.isFull[x] = true;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
